namespace TravelBooking.API.Core.DTOs
{
    public class UserAccountDto
    {
        public int UserAccountId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Gender { get; set; }
        public required string HomeAddress { get; set; }
        public required string EmailAddress { get; set; }
        public required string PhoneNumber { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
