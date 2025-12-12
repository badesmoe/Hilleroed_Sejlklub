using System.Reflection;

namespace Hillerød_Sejlklub.Models;

public class Event
{
    private static int _nextId= 1; 

    public int EventId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Date { get; set; }
    public int MaxParticipants { get; set; }
    public string Participants { get; set; }

    public Event()
    {
        EventId = _nextId++;
    }

    public Event(string name, string description, string date, int maxParticipants, string participants)
    {
        EventId = _nextId;
        _nextId++;
        Name = name;
        Description = description;
        Date = date;
        MaxParticipants = maxParticipants;
        Participants = participants;
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
