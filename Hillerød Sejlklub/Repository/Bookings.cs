using Hillerød_Sejlklub.Models;
using System.Diagnostics.Eventing.Reader;

namespace Hillerød_Sejlklub.Repository
{
    public class Bookings
    {
        public List<Booking> BookingsList = new List<Booking>();
        public List<Booking> BookingLog = new List<Booking>();

     public bool CheckAvailability(Boat boat, DateTime startTime, DateTime endTime)
        {
            foreach (Booking booking in BookingsList)
            {
                if (booking.Boat.Id == boat.Id)
                {
                    if (startTime >= booking.StartTime && startTime <= booking.EndTime)
                    {
                        return false;
                    }
                    
                }
                
            }
            return true;
        }
        public void AddBooking(Booking booking)
        {
            if (booking.InvalidBooking)
                return;
            else if (CheckAvailability(booking.Boat, booking.StartTime, booking.EndTime)==false)
            {
                return;
            }
            else
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
                    BookingLog.Add(BookingsList[i]);
                    return;
                }
            }
        }
        public Booking? SearchBookings(int id)
        {
            foreach (Booking booking in BookingsList)
            {
                if (id == booking.Id)
                    return booking;
            }
            return null;
        }

        public Booking? SearchBookingLog(int id)
        {
            foreach (Booking booking in BookingLog)
            {
                if (id == booking.Id)
                    return booking;
            }
            return null;
        }
    }
}
