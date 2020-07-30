using TRAVEL_PLANNER.Data;
using TRAVEL_PLANNER.Models;
using TRAVEL_PLANNER.Models.Enum;

namespace TRAVEL_PLANNER
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext db)
        {
            var activities = new Activity[]
            {
                new Activity()
                {
                    Id = 1,
                    Name = "Go Sky Diving"
                },
                new Activity()
                {
                    Id = 2,
                    Name = "Go Hiking"
                },
                new Activity()
                {
                    Id = 3,
                    Name = "Go to the Beach"
                },
                new Activity()
                {
                    Id = 4,
                    Name = "Visit An Art Gallery"
                },
                new Activity()
                {
                    Id = 5,
                    Name = "Wild Life Conservation"
                },
                new Activity()
                {
                    Id = 6,
                    Name = "Water Fall"
                },
                new Activity()
                {
                    Id = 7,
                    Name = "Parks"
                }
            };

            var seasons = new Season[]
            {
                new Season()
                {
                    Id = 1,
                    Name = "Autumn"
                },
                new Season()
                {
                    Id = 2,
                    Name = "Spring"
                },
                new Season()
                {
                    Id = 3,
                    Name = "Summer"
                },
                new Season()
                {
                    Id = 4,
                    Name = "Winter"
                }
            };

            var travelPlaces = new TravelPlace[]
            {
                new TravelPlace()
                {
                    Id = 1,
                    Name = "Grand Canyon",
                    Country = CountryEnum.US,
                    State = StateEnum.Colorado,
                    ImageUrl = "https://travel.usnews.com/images/grand_canyon_main_2014_-_shutterstock-kojihirano_kUxSzuP.jpg",
                    OperationHour = "EveryDay 8am - 10pm"
                },
                new TravelPlace()
                {
                    Id = 2,
                    Name = "Maui",
                    Country = CountryEnum.US,
                    State = StateEnum.Missouri,
                    ImageUrl = "https://travel.usnews.com/images/2016-main-getty-cropped_445x280_HzgMOMV.jpg",
                    OperationHour = "EveryDay 8am - 10pm"
                },
                new TravelPlace()
                {
                    Id = 3,
                    Name = "New York City",
                    Country = CountryEnum.US,
                    State = StateEnum.NewYork,
                    ImageUrl = "https://travel.usnews.com/images/main_image_september_2013_cropped_445x280_uNdHVwH.jpg",
                    OperationHour = "EveryDay 8am - 10pm"
                },
                new TravelPlace()
                {
                    Id = 4,
                    Name = "Grand Teton National Park",
                    Country = CountryEnum.US,
                    State = StateEnum.Texas,
                    ImageUrl = "https://travel.usnews.com/images/sunset_getty_resized_445x280_YKWzliy.jpg",
                    OperationHour = "WeekDay Only 8am - 10pm"
                },
                new TravelPlace()
                {
                    Id = 5,
                    Name = "Miami",
                    Country = CountryEnum.US,
                    State = StateEnum.Florida,
                    ImageUrl = "https://travel.usnews.com/images/miami_skyline_boat_p44KuSM.jpg",
                    OperationHour = "EveryDay Only 8am - 10pm"
                }
            };

            var seasonTravelBudgets = new SeasonTravelBudget[]
            {
                new SeasonTravelBudget()
                {
                    Id = 1,
                    SeasonId = 2,
                    TravelPlaceId = 1,
                    Budget = BudgetEnum.Free
                },
                new SeasonTravelBudget()
                {
                    Id = 2,
                    SeasonId = 3,
                    TravelPlaceId = 1,
                    Budget = BudgetEnum.Free
                },
                new SeasonTravelBudget()
                {
                    Id = 3,
                    SeasonId = 2,
                    TravelPlaceId = 2,
                    Budget = BudgetEnum.FourThousand
                },
                new SeasonTravelBudget()
                {
                    Id = 4,
                    SeasonId = 1,
                    TravelPlaceId = 2,
                    Budget = BudgetEnum.OneThousand
                },
                new SeasonTravelBudget() {
                    Id = 5,
                    SeasonId = 1,
                    TravelPlaceId = 3,
                    Budget = BudgetEnum.ThreeThousand
                },
                new SeasonTravelBudget()
                {
                    Id = 6,
                    SeasonId = 2,
                    TravelPlaceId = 3,
                    Budget = BudgetEnum.FourThousand
                },
                new SeasonTravelBudget()
                {
                    Id = 7,
                    SeasonId = 3,
                    TravelPlaceId = 3,
                    Budget = BudgetEnum.ThreeThousand
                },
                new SeasonTravelBudget()
                {
                    Id = 8,
                    SeasonId = 4,
                    TravelPlaceId = 3,
                    Budget = BudgetEnum.OneThousand
                },
                new SeasonTravelBudget()
                {
                    Id = 9,
                    SeasonId = 2,
                    TravelPlaceId = 4,
                    Budget = BudgetEnum.OneThousand
                },
                new SeasonTravelBudget()
                {
                    Id = 10,
                    SeasonId = 3,
                    TravelPlaceId = 4,
                    Budget = BudgetEnum.TwoThousand
                },
                new SeasonTravelBudget()
                {
                    Id = 11,
                    SeasonId = 4,
                    TravelPlaceId = 5,
                    Budget = BudgetEnum.FourThousand
                },
                new SeasonTravelBudget()
                {
                    Id = 12,
                    SeasonId = 1,
                    TravelPlaceId = 5,
                    Budget = BudgetEnum.ThreeThousand
                },
                new SeasonTravelBudget()
                {
                    Id = 13,
                    SeasonId = 2,
                    TravelPlaceId = 5,
                    Budget = BudgetEnum.FourThousand
                },
            };

            var travelActivties = new TravelActivity[]
            {
                new TravelActivity()
                {
                    Id = 1,
                    ActivityId = 1,
                    TravelPlaceId = 1
                },
                new TravelActivity()
                {
                    Id = 2,
                    ActivityId = 2,
                    TravelPlaceId = 1
                },
                new TravelActivity()
                {
                    Id = 3,
                    ActivityId = 3,
                    TravelPlaceId = 2
                },
                new TravelActivity()
                {
                    Id = 4,
                    ActivityId = 7,
                    TravelPlaceId = 2
                },
                new TravelActivity()
                {
                    Id = 5,
                    ActivityId = 2,
                    TravelPlaceId = 3
                },
                new TravelActivity()
                {
                    Id = 6,
                    ActivityId = 4,
                    TravelPlaceId = 3
                },
                new TravelActivity()
                {
                    Id = 7,
                    ActivityId = 6,
                    TravelPlaceId = 4
                },
                new TravelActivity()
                {
                    Id = 8,
                    ActivityId = 7,
                    TravelPlaceId = 4
                },
                new TravelActivity()
                {
                    Id = 9,
                    ActivityId = 7,
                    TravelPlaceId = 4
                },
                new TravelActivity()
                {
                    Id = 10,
                    ActivityId = 7,
                    TravelPlaceId = 5
                },
                new TravelActivity()
                {
                    Id = 11,
                    ActivityId = 7,
                    TravelPlaceId = 5
                },
            };

            db.activities.AddRange(activities);

            db.seasons.AddRange(seasons);

            db.travelPlaces.AddRange(travelPlaces);

            db.seasonTravelBudgets.AddRange(seasonTravelBudgets);

            db.travelActivities.AddRange(travelActivties);

            db.SaveChanges();
        }
    }
}