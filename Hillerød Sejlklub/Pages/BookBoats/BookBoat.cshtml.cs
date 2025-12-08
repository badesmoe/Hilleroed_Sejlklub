using Hillerød_Sejlklub.Models;
using Hillerød_Sejlklub.Repository.BoatFile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Hillerød_Sejlklub.Pages.BookBoats;

public class BookBoatModel : PageModel
{
    private IRepositoryBoat _fleet;

    [BindProperty]
    public DateTime StartDate { get; set; }
    [BindProperty]
    public DateTime EndDate { get; set; }
    [BindProperty]
    public string Destination { get; set; }
    [BindProperty]
    public Boat? Boat { get; set; }
    public int Id { get; set; }

    public BookBoatModel(IRepositoryBoat repositoryBoat)
    {
        _fleet = repositoryBoat;
    }

    public IActionResult OnGet(int id)
    {
        Boat = _fleet.Search(id);
        Id = id;
        if (Boat == null)
            return RedirectToPage("/Index"); //NotFound er ikke defineret endnu 

        return Page();
    }

    public void OnPost()
    {
        
    }
}
