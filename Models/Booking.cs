namespace TravelBooking.API.Models
{
    public class Booking
    {
        public  int BookingId { get; set; }
        public string FullName  { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string DistinationAddress { get; set; } = string.Empty;
    }
}
