using Hillerød_Sejlklub.Models;
using Hillerød_Sejlklub.Repository.BoatFile;

namespace Hillerød_Sejlklub.MockData
{
    public class MockFleet : IRepositoryBoat
    {
        private static List<Boat> _fleet = new List<Boat>
        {
            new Boat(101, "Sailboat", "Hanse 315", "Sea Breeze", "Inboard Diesel", 9.5, 3.3, 1.6, 2018, "/img/boats/101.jpg"),
            new Boat(202, "Motorboat", "Yamaha 242X", "Wave Runner", "Outboard Gasoline", 7.3, 2.5, 0.9, 2020,"/img/boats/202.jpg"),
            new Boat(303, "Catamaran", "Lagoon 42", "Twin Spirit", "Inboard Diesel", 12.8, 7.5, 1.2, 2019,"/img/boats/303.jpg"),
            new Boat(404, "Sailboat", "Beneteau Oceanis 30.1", "Wind Dancer", "Inboard Diesel", 9.3, 3.2, 1.5, 2021,"/img/boats/404.jpg"),
            new Boat(505, "Motorboat", "Sea Ray SPX 190", "Sun Chaser", "Outboard Gasoline", 5.8, 2.3, 0.7, 2017,"/img/boats/505.jpg"),
            new Boat(606, "Catamaran", "Fountaine Pajot Lucia 40", "Ocean Breeze", "Inboard Diesel", 11.7, 6.9, 1.1, 2022,"/img/boats/606.jpg"),
            new Boat(707, "Sailboat", "Jeanneau Sun Odyssey 349", "Blue Horizon", "Inboard Diesel", 10.3, 3.4, 1.4, 2016,"/img/boats/707.jpg"),
            new Boat(808, "Motorboat", "Bayliner Element E18", "Lake Cruiser", "Outboard Gasoline", 5.5, 2.1, 0.6, 2019,"/img/boats/808.jpg"),
            new Boat(909, "Catamaran", "Nautitech 40 Open", "Sea Voyager", "Inboard Diesel", 12.0, 7.2, 1.3, 2020,"/img/boats/909.jpg")
        };

        public void Add(Boat boat)
        {
            _fleet.Add(boat);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Boat> GetFleet() { return _fleet; }

        public Boat? Search(int id)
        {
            foreach (Boat boat in _fleet)
            {
                if (id == boat.Id)
                    return boat;
            }
            return null;
        }
    }
}
