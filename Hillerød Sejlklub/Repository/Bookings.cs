using Hillerød_Sejlklub.Models;

namespace Hillerød_Sejlklub.Repository
{
    public class Bookings
    {
        public List<Booking> BookingsList = new List<Booking>();

        public void AddBooking(Booking booking)
        {
            BookingsList.Add(booking);
        }

        public void EndBooking(int id)
        {
            for (int i = 0; i < BookingsList.Count; i++)
            {
                if (BookingsList[i].Id == id)
                {
                    BookingsList[i].Boat.IsBooked = false;
                    BookingsList.RemoveAt(i);
                    
                    return;
                }
            }
            ;
        }
        public Booking? Search(int id)
        {
            foreach (Booking booking in BookingsList)
            {
                if (id == booking.Id)
                    return booking;
            }
            return null;
        }
    }
}
