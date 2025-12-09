using Hillerød_Sejlklub.Models;

namespace Hillerød_Sejlklub.Repository
{
    public interface IRepositoryBookings
    {
        bool AddBooking(Booking booking);
        List<Booking> GetAllBookings();
    }
}
