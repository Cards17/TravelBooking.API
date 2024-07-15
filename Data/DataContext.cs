using Microsoft.EntityFrameworkCore;
using TravelBooking.API.Models;

namespace TravelBooking.API.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }

        public DbSet<Booking> Bookings { get; set; }
    }
}
