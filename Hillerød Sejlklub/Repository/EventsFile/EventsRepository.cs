using Hillerød_Sejlklub.Models;

namespace Hillerød_Sejlklub.Repository.EventsFile;

public class EventsRepository : IRepositoryEvents
{
    private readonly List<Event> _events = new List<Event>();

    public void AddEvent (Event events)
    {
        _events.Add(events);
    }

    public void DeleteEvent (int eventid)
    {
        var events = SearchEvents(eventid);
        if (events != null)
        {
            _events.Remove(events);
        }
    }

    public List<Event> GetAllEvents()
    {
        return _events;
    }

    public Event? SearchEvents(int eventId)
    {
        foreach (Event events in _events)
        {
            if (eventId == events.EventId)
                return events;
        }
        return null;
    }
    
    public void AddParticipant (int eventId, string memberName)
    {
        var events = SearchEvents(eventId);
        if (events == null) return;

        events.Participants += $"{memberName}";
    }
    public void RemoveParticipant(int eventId, string memberName)
    {
        var events = SearchEvents(eventId);
        if (events == null) return;

        events.Participants = events.Participants.Replace($"{memberName},", "");
    }
}
