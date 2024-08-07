﻿using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using TravelBooking.API.Core.DTOs;
using TravelBooking.API.Models;

namespace TravelBooking.API.Data.Services
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public BookingRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;

        }

        public async Task<IEnumerable<BookingDto>> GetBookings(int userAccountId)
        {
            var bookings = await _dataContext.Bookings
                                         .Where(b => b.UserAccountId == userAccountId)
                                         .ToListAsync();
            return _mapper.Map<IEnumerable<BookingDto>>(bookings);
        }

        public async Task<BookingDto> GetBookingById(int id)
        {
            var bookingById = await _dataContext.Bookings.FindAsync(id);
            return _mapper.Map<BookingDto>(bookingById);
        }

        public async Task AddBooking(int userAccountId, BookingDto bookingDto)
        {
            if (!await UserAccountExist(userAccountId))
            {
                throw new InvalidOperationException($"UserAccountId {userAccountId} does not exist.");
            }
            var booking = _mapper.Map<Booking>(bookingDto);
            booking.UserAccountId = userAccountId;
            await _dataContext.Bookings.AddAsync(booking);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<bool> UserAccountExist(int userAccountId)
        {
            return await _dataContext.UserAccounts
                .AnyAsync(ua => ua.UserAccountId == userAccountId);
        }


        public async Task UpdateBooking(int id, BookingDto bookingDto)
        {
            var booking = _mapper.Map<Booking>(bookingDto);
            _dataContext.Entry(booking).State = EntityState.Modified;
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteBooking(int id)
        {
            var booking = await _dataContext.Bookings.FindAsync(id);
            if (booking != null)
            {
                _dataContext.Bookings.Remove(booking);
                await _dataContext.SaveChangesAsync();
            }
        }

    }
}
