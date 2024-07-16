using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using TravelBooking.API.Core.DTOs;
using TravelBooking.API.Models;

namespace TravelBooking.API.Data.Services
{   
    public class BookingRepository : IBookingRepository
    {
        private readonly DataContext _dataContext;
        public BookingRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IEnumerable<Booking>> GetBookings() // Change to BookingDto
        {
            return await _dataContext.Bookings.ToListAsync();
        }
    }
}
