using Hillerød_Sejlklub.Models;

namespace Hillerød_Sejlklub.Repository.Users
{
    public interface IRepositoryUser
    {
        void Add(User user);
        User? Search(string searchTerm);
        List<User> GetUsers();
        void Delete(int id);
        void Update(int id, User user);
    }
}
