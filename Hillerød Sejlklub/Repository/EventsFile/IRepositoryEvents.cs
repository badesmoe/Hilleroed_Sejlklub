using Hillerød_Sejlklub.Models;

namespace Hillerød_Sejlklub.Repository.EventsFile;

public interface IRepositoryEvents
{
    void AddEvent(Event events);
    void DeleteEvent(int eventid);
    List <Event> GetAllEvents();
    Event? SearchEvents(int eventid);

    bool AddParticipant(int eventId, EventParticipant participant, out string message);
    void RemoveParticipant(int eventId, EventParticipant participant);

}
