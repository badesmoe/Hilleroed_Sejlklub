using Hillerød_Sejlklub.Models;
using Hillerød_Sejlklub.Repository.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hillerød_Sejlklub.Pages.Users
{
    public class UpdateUserModel : PageModel
    {
        private IRepositoryUser _users;

        [BindProperty]
        public User User { get; set; }

        [BindProperty]
        public MemberType NewMember { get; set; }

        public SelectList MemberTypeList { get; set; }

        public UpdateUserModel(IRepositoryUser repositoryUser)
        {
            _users = repositoryUser;
        }

        public IActionResult OnGet()
        {
            MemberTypeList = new SelectList(Enum.GetValues(typeof(MemberType)));
            return Page();

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                MemberTypeList = new SelectList(Enum.GetValues(typeof(MemberType)));
                return Page();
            }
            _users.Update(User);
            return RedirectToPage("AllUsersList");
        }
    }
}

