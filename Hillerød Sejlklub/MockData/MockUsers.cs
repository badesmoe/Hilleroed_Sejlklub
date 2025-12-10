using Hillerød_Sejlklub.Models;
using Hillerød_Sejlklub.Repository.Users;

namespace Hillerød_Sejlklub.MockData
{
    public class MockUsers: IRepositoryUser
    {
        private static List<User> _users = new List<User>
        {
            new User("Anna Hansen", "annahansen@gmail.com", 12345678),
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
            // Variabel til midlertidigt at gemme telefonnummer,
            // hvis søgetermen kan parses til et heltal
            int phoneNumber;


            // Forsøger at konvertere searchTerm til et heltal
            // Hvis det lykkes, antages der at blive søgt på telefonnummer
            if (int.TryParse(searchTerm, out phoneNumber))
            {
                foreach (User user in _users)
                {
                    if (phoneNumber == user.Phone)
                        return user;  
                }
            }
            // Hvis søgetermen indeholder '@', antages der at blive søgt på e-mail
            else if (searchTerm.Contains("@"))
            {
                foreach (User user in _users)
                {
                    if (searchTerm == user.Email)
                        return user;
                }
            }
            // Hvis hverken telefon eller e-mail, antages der at blive søgt på navn
            else
            {
                foreach (User user in _users)
                {
                    if (searchTerm == user.Name)
                        return user;
                }
            }

            // Hvis ingen bruger matcher søgekriteriet,
            // returneres null for at indikere "ingen fundet"
            return null;
        }
    }
}
