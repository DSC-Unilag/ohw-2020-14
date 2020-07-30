using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TRAVEL_PLANNER.Data;
using TRAVEL_PLANNER.Models.ViewModels;

namespace TRAVEL_PLANNER.Controllers
{
    public class TravelPlanController : Controller
    {
        private readonly ApplicationDbContext _context;

        private List<ResultTravelPlan> resultTravelPlans { get; set; } = new List<ResultTravelPlan>();

        public TravelPlanController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ResultTravelPlan(List<ResultTravelPlan> resultPlans)
        {
            ViewData["Result"] = resultPlans;

            return View();
        }

        [HttpGet]
        public IActionResult SearchPlan()
        {
            PopulateAssignedData();

            ViewData["SeasonID"] = new SelectList(_context.seasons.OrderBy(m => m.Name), "Id", "Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SearchPlan(string[] selectedActivities, SearchParameter parameter)
        {
            SearchActivies(selectedActivities, parameter);

            PopulateAssignedData();

            ViewData["SeasonID"] = new SelectList(_context.seasons.OrderBy(m => m.Name), "Id", "Name");

            if(resultTravelPlans != null)
            {
                ViewData["Result"] = resultTravelPlans;
            }

            return View();
        }
        
        private void PopulateAssignedData()
        {
            var viewModel = new List<AssignedActivityData>();

            foreach (var activity in _context.activities)
            {
                viewModel.Add(new AssignedActivityData
                {
                    Id = activity.Id,
                    Name = activity.Name,
                    Assigned = false
                });
            }

            ViewData["Activitys"] = viewModel;
        }
        
        private async void SearchActivies(string[] selectedActivities, SearchParameter parameter)
        {
            var selectedActivityHS = new HashSet<string>(selectedActivities);
            
            foreach (var activity in _context.activities)
            {
                if (selectedActivityHS.Contains(activity.Id.ToString()))
                {
                    var items =  await _context.travelPlaces
                                            .Include(s => s.SeasonTravelBudget)
                                            .Include(s => s.TravelActivities)
                                                .ThenInclude(s => s.Activity)
                                            .Where(s => s.SeasonTravelBudget.Any(s => (s.Budget.Equals(parameter.Budget)) & (s.SeasonId.Equals(parameter.SeasonName))))
                                                .Where(s => s.TravelActivities.Any(s => s.ActivityId.Equals(activity.Id)))
                                            .SingleOrDefaultAsync();

                    var findseason = _context.seasons.SingleOrDefault(s => s.Id == parameter.SeasonName);

                    var findactivities = _context.activities.SingleOrDefault(s => s.Id == activity.Id);

                    if(items == null)
                    {
                        continue;
                    }

                    if(resultTravelPlans.Where(s => s.Name.Equals(items.Name)).ToList().Count()  < 1)
                    {
                        resultTravelPlans.Add(new ResultTravelPlan
                        {
                            Id = items.Id,
                            ImageUrl = items.ImageUrl,
                            Name = items.Name,
                            Country = items.Country,
                            OperationHour = items.OperationHour,
                            Season = findseason.Name,
                            State = items.State,
                            Activities = findactivities.Name
                        });
                    }
                }
            }
        }
    }
}