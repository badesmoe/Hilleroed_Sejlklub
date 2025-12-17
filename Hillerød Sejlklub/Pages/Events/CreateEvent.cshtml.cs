using Hillerød_Sejlklub.Models;
using Hillerød_Sejlklub.Repository.EventsFile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Hillerød_Sejlklub.Pages.Events;

//[Authorize(Roles = "Admin")]
public class CreateEventModel : PageModel
{
    private readonly IRepositoryEvents _repo;

    [BindProperty]
    public Event InputEvent { get; set; } = new();

    public List<Event> Events { get; set; } = new();
    public CreateEventModel(IRepositoryEvents repo)
    {
        _repo = repo;
    }

    public void OnGet()
    {
        Events = _repo.GetAllEvents();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            Events = _repo.GetAllEvents();
            return Page();
        }

        _repo.AddEvent(InputEvent);

        return RedirectToPage("/Events/AllEvents");
    }

    public IActionResult OnPostRemoveParticipant(int eventId, string email)
    {
        _repo.RemoveParticipantByEmail(eventId, email);
        return RedirectToPage();
    }
}
