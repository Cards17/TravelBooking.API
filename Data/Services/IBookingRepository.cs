using TravelBooking.API.Core.DTOs;
using TravelBooking.API.Models;

namespace TravelBooking.API.Data.Services
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetBookings(); // change to BookingDto
    }
}
