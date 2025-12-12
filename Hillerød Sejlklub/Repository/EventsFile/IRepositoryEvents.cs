using Hillerød_Sejlklub.Models;

namespace Hillerød_Sejlklub.Repository.EventsFile;

public interface IRepositoryEvents
{
    void AddEvent(Event events);
    void DeleteEvent(int eventid);
    List <Event> GetAllEvents();
    Event? SearchEvents(int eventid);
    void AddParticipant(int eventId, string memberName);
    void RemoveParticipant( int eventId, string memberName);

}
