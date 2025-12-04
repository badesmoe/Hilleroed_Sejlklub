using Hillerød_Sejlklub.Repository;

namespace Hillerød_Sejlklub.Models
{
    public class Boat
    {
        private static int _nextId = 1;

        #region Properties
        // Identification
        public int Id { get; private set; }
        public int SailNumber { get; set; }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }

        // Engine
        public string EngineType { get; set; }

        // Measurements
        public double Length { get; set; }
        public double Width { get; set; }
        public double Draft { get; set; }

        public List<MaintenanceLogFile> MaintenanceLog { get; } 
        public List<DamageReportFile> DamageReports { get; }

        // Construction
        public int BuildYear { get; set; }

        // Booking Status
        public bool IsBooked { get; set; }
        #endregion

        #region Constructor
        public Boat(int sailNumber, string type, string model, string name,
            string engineType, 
            double length, double width, double draft, 
            int buildYear)
        {
            Id = _nextId++;
            SailNumber = sailNumber;
            Type = type;
            Model = model;
            Name = name;

            EngineType = engineType;

            Length = length;
            Width = width;
            Draft = draft;

            BuildYear = buildYear;

            IsBooked = false;

        }
        #endregion

        #region Methods

        // Vi skal have en metode til at føre en Vedligeholdelseslog og en metode til at medlemmer skal kunne rapportere en skade.
        public override string ToString()
        {
            return
                $"Boat ID: {Id}\n" +
                $"Sail Number: {SailNumber}\n" +
                $"Type: {Type}\n" +
                $"Model: {Model}\n" +
                $"Name: {Name}\n" +
                $"Engine Type: {EngineType}\n" +
                $"Length: {Length} m\n" +
                $"Width: {Width} m\n" +
                $"Draft: {Draft} m\n" +
                $"Build Year: {BuildYear}\n";
        }
        #endregion
    }
}
