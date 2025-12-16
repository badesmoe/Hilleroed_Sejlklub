using System.Reflection;

namespace Hillerød_Sejlklub.Models;

public class Event
{

    public int EventId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public int MaxParticipants { get; set; }
    public List<EventParticipant> Participants { get; set; } = new();
    public string ImagePath { get; set; } = string.Empty;

    public Event()
    {
        
        Date = DateTime.Today;
    }

    public Event(string name, string description, DateTime date, int maxParticipants, string imagePath)
    {
        Name = name;
        Description = description;
        Date = date;
        MaxParticipants = maxParticipants;
        ImagePath = imagePath;
    }

    public override string ToString()
    {
        return
                $"Event ID: {EventId}\n" +
                $"Event Name: {Name}\n" +
                $"Description: {Description}\n" +
                $"Date: {Date}\n" +
                $"Max Participants: {MaxParticipants}\n" +
                $"Participants: {Participants}\n";
                
    }

}
