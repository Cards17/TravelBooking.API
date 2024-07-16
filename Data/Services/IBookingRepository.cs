using TravelBooking.API.Core.DTOs;
using TravelBooking.API.Models;

namespace TravelBooking.API.Data.Services
{
    public interface IBookingRepository
    {
        Task<IEnumerable<BookingDto>> GetBookings();
        Task<BookingDto> GetBookingById(int id);
        Task AddBooking(BookingDto booking);
        Task UpdateBooking(int id, BookingDto booking);
    }
}
