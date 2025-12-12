using Hillerød_Sejlklub.Models;
using Hillerød_Sejlklub.Repository.Users;

namespace Hillerød_Sejlklub.MockData
{
    public class MockUsers: IRepositoryUser
    {
        private static List<User> _users = new List<User>
        {
            new User("Niels Henrik Meedom", "meedom73@gmail.com", 31659882, RoleType.Admin),
            new User("Michael Krejlberg", "michael_kreiberg@hotmail.com", 21649832, RoleType.Admin),
            new User("Christian V Pedersen", "cvesterp@hotmail.com", 26807755, RoleType.Member),
            new User("Henrik K Knudsen", "henrik.knu@gmail.com", 41397474, RoleType.Member),
            new User("Anna Hansen", "annahansen@gmail.com", 12345678),
            new User("Borge Jensen", "borgejensen@gmail.com", 12546463)
        };

        public List<User> GetUsers() { return _users; }

        public void Add(User user)
        {
            _users.Add(user);
        }

        public void Delete(int id)
        {
            for (int i = 0; i < _users.Count; i++)
            {
                if (_users[i].Id == id)
                {
                    _users.RemoveAt(i);
                    return;
                }
            }
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

        public void Update(int oldId, User newUser)
        {
            for (int i = 0; i < _users.Count; i++)
            {
                if (_users[i].Id == oldId)
                {
                    _users[i].Name = newUser.Name;
                    _users[i].Email = newUser.Email;
                    _users[i].Phone = newUser.Phone;
                    _users[i].Role = newUser.Role;
                    _users[i].MemberType = newUser.MemberType;
                    return;
                }
            }
        }
    }
}
