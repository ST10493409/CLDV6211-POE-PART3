namespace EventEase.Models
{
    public class BookingView
    {
        public int BookingId { get; set; }
        public string VenueName { get; set; }
        public string EventName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
