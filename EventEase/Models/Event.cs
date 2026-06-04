namespace EventEase.Models
{
    public class Event
    {
        public string EventId { get; set; }
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public int EventTypeId { get; set; }
        public EventType? EventType { get; set; }
    }
}
