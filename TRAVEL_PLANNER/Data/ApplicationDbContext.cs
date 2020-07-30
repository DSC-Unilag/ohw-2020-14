using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TRAVEL_PLANNER.Models;

namespace TRAVEL_PLANNER.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUsers>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TravelPlace> travelPlaces { get; set; }

        public DbSet<Season> seasons { get; set; }

        public DbSet<Activity> activities { get; set; }

        public DbSet<TravelActivity> travelActivities { get; set; }

        public DbSet<SeasonTravelBudget> seasonTravelBudgets { get; set; }
    }
}