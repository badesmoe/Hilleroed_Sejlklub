using Hillerød_Sejlklub.Models;

namespace Hillerød_Sejlklub.Repository;

public class UserFile
{
    private List<User> users = new List <User>();
    
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

    // searchTerm = '3'
    public User? Search (string searchTerm)
    {
        int phoneNumber;

        if (Int32.TryParse(searchTerm, out phoneNumber))
        {
            foreach(User user in users)
            {
                if (phoneNumber == user.Phone)
                    return user;
            }          
        }

        else if (searchTerm.Contains("@"))
        {
            foreach (User user in users)
            {
                if (searchTerm == user.Email)
                    return user;
            }
        }
        else 
        { 
            foreach (User user in users)
            {
                if (searchTerm == user.Name)
                    return user;
            }
        }

            return null;
    }


}
