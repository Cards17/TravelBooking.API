namespace TravelBooking.API.Core.DTOs
{
    public class BookingDto
    {
        public int BookingId { get; set; }
        public required string DistinationAddress { get; set; }
        public required string TourPackage { get; set; }
        public required DateTime TravelDate { get; set; }
        public required DateTime ReturnDate { get; set; }
    }
}
