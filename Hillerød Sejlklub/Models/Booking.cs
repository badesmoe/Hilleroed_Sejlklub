using System.Data;
using System.Numerics;
using System.Xml.Linq;

namespace Hillerød_Sejlklub.Models
{
    public class Booking
    #region Properties
    {
        private static int _nextId = 1;
        public int Id { get; private set; }
        public string Destination { get; set; }
        public DateOnly StartTime { get; set; }
        public DateOnly EndTime { get; set; }
        public bool StartInvestigation { get; set; }
        public int BoatId { get; set; }
        public string? BoatName { get; set; }
        public Boat Boat { get; private set; }
        public User? User { get; }
        public bool InvalidBooking
        {
            get
            {
                
                if (EndTime <= StartTime || StartTime <= DateOnly.FromDateTime(DateTime.Today))
                    return true;
                
                else
                    return false;

            }
        }
        #endregion

    #region Constructor
        public Booking(User user, Boat boat, DateOnly startTime, DateOnly endTime, string destination)
        {
            Id = _nextId;
            _nextId++;
            Boat = boat;
            User = user;
            BoatName = boat.BoatName;
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
                $"User: {User}\n" + 
                $"Booking ID: {Id}\n" + 
                $"Destination: {Destination}\n" +
                $"Start time: {StartTime}\n" +
                $"End time: {EndTime}\n" +
                $"Investigation status: {StartInvestigation}\n";
        }


    }
        #endregion


}
