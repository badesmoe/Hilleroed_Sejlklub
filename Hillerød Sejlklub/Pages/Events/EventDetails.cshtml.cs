using Hillerød_Sejlklub.Models;                
using Hillerød_Sejlklub.Repository.EventsFile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hillerød_Sejlklub.Pages.Events
{
    [AllowAnonymous]
    public class EventDetailsModel : PageModel
    {
        private readonly IRepositoryEvents _repo;

        public Event? CurrentEvent { get; set; }

        [BindProperty]
        public string NewParticipant { get; set; } = "";

        public EventDetailsModel(IRepositoryEvents repo)
        {
            _repo = repo;
        }

        public IActionResult OnGet(int id)
        {
            CurrentEvent = _repo.SearchEvents(id);
            if (CurrentEvent == null)
                return RedirectToPage("AllEvents");

            return Page();
        }

        public IActionResult OnPostJoin(int id)
        {
            _repo.AddParticipant(id, NewParticipant);

            return RedirectToPage(new { id = id });
        }
    }
}
