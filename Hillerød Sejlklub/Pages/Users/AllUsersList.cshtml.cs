using Hillerød_Sejlklub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hillerød_Sejlklub.Pages.Users
{
    public class AllUsersListModel : PageModel
    {
        public int Id { get; private set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int Phone { get; set; }

        public List<User> Users { get; private set; } = new List<User>
        {
        new User("Anna Hansen", "annahansen@gmail.com", 12345678),
        new User("Borge Jensen", "borgejensen@gmail.com", 12546463)
        };

        public void OnGet()
        {
        }
    }
}
    