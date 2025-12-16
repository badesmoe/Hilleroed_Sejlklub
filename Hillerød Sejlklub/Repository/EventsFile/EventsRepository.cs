using Hillerød_Sejlklub.Models;

namespace Hillerød_Sejlklub.Repository.EventsFile;

public class EventsRepository : IRepositoryEvents
{
    private int _nextId = 1;

    private readonly List<Event> _events = new List<Event>();

    public void AddEvent(Event events)
    {
        events.EventId = _nextId++;
        _events.Add(events);
    }

    public void DeleteEvent (int eventId)
    {
        var events = SearchEvents(eventId);
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

    public bool AddParticipant(int eventId, EventParticipant participant, out string message)
    {
        var events = SearchEvents(eventId);
        if (events == null)
        {
            message = "Event findes ikke.";
            return false;
        }

        if (events.Participants.Count >= events.MaxParticipants)
        {
            message = "Eventet er fuldt booket.";
            return false;
        }

        if (events.Participants.Any(p => p.Email == participant.Email))
        {
            message = "Denne email er allerede tilmeldt.";
            return false;
        }

        events.Participants.Add(participant);
        message = "Du er nu tilmeldt eventet!";
        return true;
    }
    
    public void RemoveParticipant(int eventId, EventParticipant participant)
    {
        var events = SearchEvents(eventId);
        if (events == null) return;

        events.Participants.Remove(participant);
    }
}
