using Hillerød_Sejlklub.Models;
using Hillerød_Sejlklub.Repository.BoatFile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hillerød_Sejlklub.Pages.Boats;

public class CreateNewBoatModel : PageModel
{
    private readonly IRepositoryBoat _repo;

    [BindProperty]
    public Boat InputBoat { get; set; }

    public CreateNewBoatModel(IRepositoryBoat repo)
    {
        _repo = repo;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        _repo.Add(InputBoat);

        return RedirectToPage("AllBoats");
    }
}
