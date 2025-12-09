using Hillerød_Sejlklub.Models;

namespace Hillerød_Sejlklub.Repository.BoatFile
{
    public class Fleet: IRepositoryBoat
    {
        private readonly List<Boat> fleet = new List<Boat>();

        public void Add(Boat boat)
        {
            fleet.Add(boat);
        }

        public void Delete(int id)
        {
            for (int i = 0; i < fleet.Count; i++)
            {
                if (fleet[i].Id == id)
                {
                    fleet.RemoveAt(i);
                    return;
                }
            }
        }
        public List<Boat> GetFleet()
        {
            return fleet;
        }
        public Boat? Search(int id)
        {
            foreach (Boat boat in fleet)
            {
                if (id == boat.Id)
                    return boat;
            }
            return null;
        }
    }
}
