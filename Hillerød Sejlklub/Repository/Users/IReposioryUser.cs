using Hillerød_Sejlklub.Models;

namespace Hillerød_Sejlklub.Repository.Users
{
    public interface IReposioryUser
    {
        void Add(User user);
        User? Search(string searchTerm);
        void Delete(int id);
    }
}
