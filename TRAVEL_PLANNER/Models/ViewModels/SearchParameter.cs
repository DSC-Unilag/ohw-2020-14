using System.ComponentModel.DataAnnotations;
using TRAVEL_PLANNER.Models.Enum;

namespace TRAVEL_PLANNER.Models.ViewModels
{
    public class SearchParameter
    {
        [Required]
        public BudgetEnum Budget { get; set; }

        [Required]
        public int SeasonName { get; set; }
    }
}