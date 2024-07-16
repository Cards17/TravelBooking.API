namespace TravelBooking.API.Core.DTOs
{
    public class BookingDto
    {
        public int BookingId { get; set; }
        public required string FullName { get; set; }
        public required string EmailAddress { get; set; }
        public required string PhoneNumber { get; set; }
        public string DistinationAddress { get; set; } = string.Empty;
    }
}
