using Hillerød_Sejlklub.Models;

namespace Hillerød_Sejlklub.Repository
{
    public interface IRepositoryBookings
    {
        bool AddBooking(Booking booking);
        void EndBooking(int id);
        Booking? SearchBookings(int id);
        Booking? SearchBookingLog(int id);
        List<Booking> GetAllActiveBookings();
        List<Booking> GetAllPreviousBookings();
    }
}
