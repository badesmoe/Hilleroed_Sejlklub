using Hillerød_Sejlklub.MockData;
using Hillerød_Sejlklub.Models;
using Hillerød_Sejlklub.Repository.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hillerød_Sejlklub.Pages.Users
{
    public class AllUsersListModel : PageModel
    {
        private IRepositoryUser _users;

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int Phone { get; set; }
        [BindProperty]
        public List<User> Users { get; set; }
        [BindProperty]
        public string SearchTerm { get; set; }

        public AllUsersListModel(IRepositoryUser repositoryUser)
        {
            _users = repositoryUser;
        }

        public void OnGet()
        {
            Users = _users.GetUsers();
        }

        public IActionResult OnPostSearchUser()
        {
            if(string.IsNullOrEmpty(SearchTerm))
            {
                Users = _users.GetUsers();
                return Page();
            }
            else
            {
                List<User> usersList = new();
            
                User? user = _users.Search(SearchTerm);

                usersList.Add(user);

                Users = usersList;

                return Page();
            }
        }
        public IActionResult OnPostDelete(int id)
        {
            _users.Delete(id);
            return RedirectToPage("AllUsersList");
        }
    }
}
    