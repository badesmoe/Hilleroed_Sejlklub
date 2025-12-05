using System.Data;
using System.Numerics;
using System.Xml.Linq;

namespace Hillerød_Sejlklub.Models
{
    public class Booking
    #region Properties
    {
        private static int _nextId;
        public int Id { get; private set; }
        public string Destination { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool StartInvestigation { get; set; }
        public int BoatId { get; set; }
        public Boat? Boat { get; }
        public User? User { get; }
        public bool InvalidBooking
        {
            get
            {
                
                if (EndTime <= StartTime || StartTime <= DateTime.Now)
                    return true;
                
                else
                    return false;

            }
        }
        #endregion

    #region Constructor
        public Booking(User user, Boat boat, DateTime startTime, DateTime endTime, string destination)
        {
            Id = _nextId;
            _nextId++;
            Boat = boat;
            BoatId = boat.Id;
            Destination = destination;
            StartTime = startTime;
            EndTime = endTime;
            boat.IsBooked = true;
            StartInvestigation = false;
        }
        #endregion

    #region Methods
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
        #endregion


}
