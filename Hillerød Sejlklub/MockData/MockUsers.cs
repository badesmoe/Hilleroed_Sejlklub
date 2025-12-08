using Hillerød_Sejlklub.Models;
using Hillerød_Sejlklub.Repository.Users;

namespace Hillerød_Sejlklub.MockData
{
    public class MockUsers: IReposioryUser
    {
        private static List<User> _users = new List<User>
        {
            new User("Anna Hansen", "annahansen@gmail.com", 12345678, RoleType.Admin),
            new User("Borge Jensen", "borgejensen@gmail.com", 12546463)
        };

        public List<User> GetUsers() { return _users; }

        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public User? Search(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}
