using Hillerød_Sejlklub.Models;

namespace Hillerød_Sejlklub.Repository;

public class UserFile
{
    private List<User> users = new List <User>()
    {
        new User("John Doe", "John@Doe.com", 29545843, RoleType.Admin),
    };
    
    public void AddUser(User user)
    {
        users.Add(user);
    } 

    public void DeleteUser(int id)
    {
        for (int i = 0; i < users.Count; i++)
        {
            if (users[i].Id == id )
            {
                users.RemoveAt(i);
                return;
            }
        }
    }

    public User? Search (string searchTerm)
    {
        // Variabel til midlertidigt at gemme telefonnummer,
        // hvis søgetermen kan parses til et heltal
        int phoneNumber;


        // Forsøger at konvertere searchTerm til et heltal
        // Hvis det lykkes, antages der at blive søgt på telefonnummer
        if (Int32.TryParse(searchTerm, out phoneNumber))
        {
            foreach (User user in users)
            {
                if (phoneNumber == user.Phone)
                    return user;
            }          
        }
        // Hvis søgetermen indeholder '@', antages der at blive søgt på e-mail
        else if (searchTerm.Contains("@"))
        {
            foreach (User user in users)
            {
                if (searchTerm == user.Email)
                    return user;
            }
        }
        // Hvis hverken telefon eller e-mail, antages der at blive søgt på navn
        else
        {
            foreach (User user in users)
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
