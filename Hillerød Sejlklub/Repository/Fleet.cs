using Hillerød_Sejlklub.Models;

namespace Hillerød_Sejlklub.Repository
{
    public class Fleet
    {
        private List<Boat> fleet = new List<Boat>();

        public void AddUser(Boat boat)
        {
            fleet.Add(boat);
        }

        public void DeleteBoat(int id)
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
