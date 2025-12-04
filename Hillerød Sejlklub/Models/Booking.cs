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
        public bool StartInvestigation { get; set; }

        public Booking(User user, Boat boat, DateTime startTime, DateTime endTime, string destination)
        {
            Id = _nextId;
            _nextId++;
            Destination = destination;
            StartTime = startTime;
            EndTime = endTime;
            StartInvestigation = false;

        }

        public override string ToString()
        {
            return
                $"Booking ID: {Id}\n" + 
                $"Destination: {Destination}\n" +
                $"Start time: {StartTime}\n" +
                $"End time: {EndTime}\n" +
                $"Investigation status: {StartInvestigation}\n";
        }


    }



}
