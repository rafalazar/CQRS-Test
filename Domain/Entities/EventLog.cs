namespace Domain.Entities;

public class EventLog : BaseEntity
{
    public string EventType { get; set; }
    public DateTime Date { get; set; }
}