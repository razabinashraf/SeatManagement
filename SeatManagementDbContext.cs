using Microsoft.EntityFrameworkCore;
using SeatManagement.Models;

namespace SeatManagement
{
    public class SeatManagementDbContext : DbContext
    {
        public SeatManagementDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<AllocatedAsset> AllocatedAssets { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<CabinRoom> CabinRooms { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<MeetingRoom> MeetingRooms { get; set;}
        public DbSet<Seat> Seats { get; set; }
    }
}
