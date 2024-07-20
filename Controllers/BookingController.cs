using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelBooking.API.Core.DTOs;
using TravelBooking.API.Data.Services;
using TravelBooking.API.Models;

namespace TravelBooking.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        public BookingController(IBookingRepository bookingRepository, IMapper mapper)   
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDto>>> GetBookings()
        {
            return Ok(await _bookingRepository.GetBookings());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDto>> GetBookingById(int id)
        {
            var booking = await _bookingRepository.GetBookingById(id);
            if (booking == null)
            {
                return NotFound();
            }
            var bookingDto = _mapper.Map<BookingDto>(booking);
            return bookingDto;
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking(BookingDto bookingDto)
        {
            await _bookingRepository.AddBooking(bookingDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateApplicant(int id, BookingDto bookingDto)
        {
            try
            {
                if (id != bookingDto.BookingId)
                {
                    return BadRequest();
                }

                await _bookingRepository.UpdateBooking(id, bookingDto);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            try
            {
                var booking = await _bookingRepository.GetBookingById(id);
                if (booking == null)
                {
                    return NotFound();
                }

                await _bookingRepository.DeleteBooking(id);

            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting booking with ID {id}: {ex.Message}", ex);
            }
            return NoContent();
        }

    }
}
