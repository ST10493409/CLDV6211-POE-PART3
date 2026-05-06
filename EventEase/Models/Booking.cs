namespace EventEase.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int VenueId { get; set; }
        public int EventId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }



    }
}
