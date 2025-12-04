using Hillerød_Sejlklub.Models;

namespace Hillerød_Sejlklub.Repository.BoatFile
{
    public interface IRepositoryBoat
    {
        void Add(Boat boat);
        List<Boat> GetFleet();
        Boat? Search(int id);
        void Delete(int id);

    }
}
