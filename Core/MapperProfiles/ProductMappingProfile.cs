using AutoMapper;
using TravelBooking.API.Core.DTOs;
using TravelBooking.API.Models;

namespace TravelBooking.API.Core.MapperProfiles
{
    public class ProductMappingProfile: Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<BookingDto, Booking>();
            CreateMap<Booking, BookingDto>();
            CreateMap<UserAccountDto, UserAccount>();
            CreateMap<UserAccount, UserAccountDto>();
        }
    }
}
