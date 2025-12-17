using Hillerød_Sejlklub.Models;                
using Hillerød_Sejlklub.Repository.EventsFile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hillerød_Sejlklub.Pages.Events
{
    //[AllowAnonymous]
    public class EventDetailsModel : PageModel
    {
        private readonly IRepositoryEvents _repo;

        public Event? CurrentEvent { get; set; }

        [BindProperty]
        public EventParticipant NewParticipant { get; set; } = new();

        public IActionResult OnPostCancel(int id, string cancelEmail)
        {
            _repo.RemoveParticipantByEmail(id, cancelEmail);
            return RedirectToPage(new { id });
        }


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
            bool success = _repo.AddParticipant(id, NewParticipant, out string message);

            TempData["JoinMessage"] = message;
            TempData["JoinSuccess"] = success;

            return RedirectToPage(new { id });
        }
    }
}
