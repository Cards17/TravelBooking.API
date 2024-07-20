using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TravelBooking.API.Models
{
    public class Booking
    {
        [Key]
        public  int BookingId { get; set; }
        public required string DistinationAddress { get; set; }
        public required string TourPackage { get; set; }
        public required DateTime TravelDate { get; set; }
        public required DateTime ReturnDate { get; set; }

        [ForeignKey(nameof(UserAccountId))]
        public int UserAccountId { get; set; }
    }
}
