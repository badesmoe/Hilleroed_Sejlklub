using Hillerød_Sejlklub.Models;

namespace Hillerød_Sejlklub.Repository.BoatFile
{
    public interface IRepositoryBoat
    {
        void Add(Boat boat);
        Boat? Search(int id);
        void Delete(int id);

    }
}
