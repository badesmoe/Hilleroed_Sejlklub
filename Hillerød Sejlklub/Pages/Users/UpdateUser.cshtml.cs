using Hillerød_Sejlklub.Models;
using Hillerød_Sejlklub.Repository.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Xml.Linq;

namespace Hillerød_Sejlklub.Pages.Users
{
    public class UpdateUserModel : PageModel
    {
        private IRepositoryUser _users;

        [BindProperty]
        public int OldId { get; set; }

        [BindProperty]
        public User User { get; set; }

        [BindProperty]
        public MemberType NewMember { get; set; }

        public SelectList MemberTypeList { get; set; }

        public UpdateUserModel(IRepositoryUser repositoryUser)
        {
            _users = repositoryUser;
        }

        public IActionResult OnGet(string name)
        {
            User = _users.Search(name);
            OldId = User.Id;
            
            if (User == null)
                return RedirectToPage("/NotFound");

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
            
            _users.Update(OldId, User);
            return RedirectToPage("AllUsersList");
        }
    }
}

