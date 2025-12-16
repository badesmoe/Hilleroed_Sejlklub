using Hillerød_Sejlklub.Models;
using Hillerød_Sejlklub.Repository.EventsFile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hillerød_Sejlklub.Pages.Events;

//[AllowAnonymous]
public class AllEventsModel : PageModel
{
    private readonly IRepositoryEvents _repo;

    public List<Event> EventsList { get; set; } = new();

    public AllEventsModel(IRepositoryEvents repo)
    {
        _repo = repo;
    }
    public void OnGet()
    {
        EventsList = _repo.GetAllEvents();
    }
}
