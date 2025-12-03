using System.Data;
using System.Numerics;
using System.Xml.Linq;

namespace Hillerød_Sejlklub.Models
{
    public class Booking
    {
        private static int _nextId;
        public int Id { get; private set; }
        public string Destination { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsActive { get; set; }

        public Booking(int id, string destination, DateTime startTime, DateTime endTime, bool isActive)
        {
            Id = id;
            Destination = destination;
            StartTime = startTime;
            EndTime = endTime;
            IsActive = isActive;
        }

        public bool EndBooking()
        {
            if (!IsActive)
                return false;

            IsActive = false;
            EndTime = DateTime.Now;
            return true;
        }

        public override string ToString()
        {
            return
                $"Booking ID: {Id}\n" +
                $"Destination: {Destination}\n" +
                $"Start time: {StartTime}\n" +
                $"End time: {EndTime}\n" +
                $"Booking status: {IsActive}\n";
        }


    }



}
