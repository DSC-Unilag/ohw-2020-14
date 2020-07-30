using TRAVEL_PLANNER.Models.Enum;

namespace TRAVEL_PLANNER.Models
{
    public class SeasonTravelBudget
    {
        public int Id { get; set; }

        public int SeasonId { get; set; }

        public int TravelPlaceId { get; set; }

        public BudgetEnum Budget { get; set; }

        public Season Season { get; set; }

        public TravelPlace TravelPlace { get; set; }
    }
}