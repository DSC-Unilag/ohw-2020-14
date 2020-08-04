using TRAVEL_PLANNER.Models.Enum;

namespace TRAVEL_PLANNER.Models.ViewModels
{
    public class ResultTravelPlan
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Url { get; set; }

        public CountryEnum Country { get; set; }

        public StateEnum State { get; set; }

        public string OperationHour { get; set; }

        public string Season { get; set; }

        public string Activities { get; set; }
    }
}