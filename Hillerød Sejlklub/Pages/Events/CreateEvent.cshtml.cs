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


    public CreateEventModel(IRepositoryEvents repo)
    {
        _repo = repo;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _repo.AddEvent(InputEvent);

        return RedirectToPage("/Events/AllEvents");
    }
}
