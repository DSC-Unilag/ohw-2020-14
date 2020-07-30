using System.Collections.Generic;
using TRAVEL_PLANNER.Models.Enum;

namespace TRAVEL_PLANNER.Models
{
    public class TravelPlace
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public CountryEnum Country { get; set; }

        public StateEnum State { get; set; }

        public string OperationHour { get; set; }

        public ICollection<SeasonTravelBudget> SeasonTravelBudget { get; set; }

        public ICollection<TravelActivity> TravelActivities { get; set; }
    }
}