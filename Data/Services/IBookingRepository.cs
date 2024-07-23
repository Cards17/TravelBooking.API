using TravelBooking.API.Core.DTOs;
using TravelBooking.API.Models;

namespace TravelBooking.API.Data.Services
{
    public interface IBookingRepository
    {
        Task<IEnumerable<BookingDto>> GetBookings(int userAccountId);
        Task<BookingDto> GetBookingById(int id);
        Task AddBooking(int userAccountId, BookingDto booking);
        Task UpdateBooking(int id, BookingDto booking);
        Task DeleteBooking(int id);
    }
}
