namespace TRAVEL_PLANNER.Models
{
    public class TravelActivity
    {
        public int Id { get; set; }

        public int ActivityId { get; set; }

        public int TravelPlaceId { get; set; }

        public TravelPlace TravelPlace { get; set; }

        public Activity Activity { get; set; }
    }
}