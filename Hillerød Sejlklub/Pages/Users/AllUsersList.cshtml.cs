using Hillerød_Sejlklub.MockData;
using Hillerød_Sejlklub.Models;
using Hillerød_Sejlklub.Repository.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hillerød_Sejlklub.Pages.Users
{
    public class AllUsersListModel : PageModel
    {
        private IReposioryUser _users;

        public int Id { get; private set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int Phone { get; set; }
        public List<User> Users { get; private set; }

        public AllUsersListModel(IReposioryUser reposioryUser)
        {
            _users = reposioryUser;
        }

        public void OnGet()
        {
            Users = _users.GetUsers();
        }
    }
}
    