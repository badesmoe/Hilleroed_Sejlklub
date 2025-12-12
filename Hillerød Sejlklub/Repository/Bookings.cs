using Hillerød_Sejlklub.Models;
using System.Diagnostics.Eventing.Reader;

namespace Hillerød_Sejlklub.Repository
{
    public class Bookings: IRepositoryBookings
    {
        private List<Booking> _bookingsList = new List<Booking>();
        private List<Booking> _bookingLog = new List<Booking>();

        // This method goes through all existing bookings to see if the boat is already booked for the requested time period.
        public bool CheckAvailability(Boat boat, DateOnly startTime, DateOnly endTime)
        {
            foreach (Booking booking in _bookingsList)
            {
                if (booking.Boat?.Id == boat.Id)
                {
                    if (startTime < booking.EndTime && endTime > booking.StartTime)
                    {
                        return false;
                    }
                    
                }
                
            }
            return true;
        }
        // This method adds a booking to the bookings list if the booking is valid and the boat is available at the given time.
        public bool AddBooking(Booking booking)
        {
            if (booking.InvalidBooking)
                return false;
            else if (CheckAvailability(booking.Boat, booking.StartTime, booking.EndTime)==false)
            {
                return false;
            }
            else
            {
                _bookingsList.Add(booking);
                return true;
            }
        }
        // This method ends a booking by its ID, marking the boat as not booked and moving the booking to the booking log.
        public void EndBooking(int id)
        {
            for (int i = 0; i < _bookingsList.Count; i++)
            {
                if (_bookingsList[i].Id == id)
                {
                    _bookingsList[i].Boat.IsBooked = false;
                    _bookingLog.Add(_bookingsList[i]);
                    _bookingsList.RemoveAt(i);
                    return;
                }
            }
        }
        // This method searches for a booking by its ID in the current bookings list.
        public Booking? SearchBookings(int id)
        {
            foreach (Booking booking in _bookingsList)
            {
                if (id == booking.Id)
                    return booking;
            }
            return null;
        }
        // This method searches for a booking by its ID in the booking log.
        public Booking? SearchBookingLog(int id)
        {
            foreach (Booking booking in _bookingLog)
            {
                if (id == booking.Id)
                    return booking;
            }
            return null;
        }
        // This method return the contents of the entire list.
        public List<Booking> GetAllActiveBookings()
        {
            return _bookingsList;
        }
        public List<Booking> GetAllPreviousBookings()
        {
            return _bookingLog;
        }
    }
}