using Hillerød_Sejlklub.Models;
using Hillerød_Sejlklub.Repository.BoatFile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Hillerød_Sejlklub.Pages.BookBoats;

public class BookBoatModel : PageModel
{
    private readonly IRepositoryBoat _fleet;

    [BindProperty(SupportsGet = true)]
    public int Id { get; set; }

    [BindProperty]
    [DataType(DataType.Date)]
    [Display(Name = "Startdato")]
    public DateTime StartDate { get; set; }

    [BindProperty]
    [DataType(DataType.Date)]
    [Display(Name = "Slutdato")]
    public DateTime EndDate { get; set; }

    [BindProperty]
    [Required]
    [Display(Name = "Farvand / destination")]
    public string Destination { get; set; } = string.Empty;

    public Boat? Boat { get; private set; }

    public BookBoatModel(IRepositoryBoat repositoryBoat)
    {
        _fleet = repositoryBoat;
    }

    public IActionResult OnGet(int id)
    {
        Id = id;
        Boat = _fleet.Search(id);
        if (Boat == null)
            return RedirectToPage("/Index");

        // Kun sæt default værdier første gang
        if (StartDate == default)
        {
            StartDate = DateTime.Today;
            EndDate = DateTime.Today.AddDays(1);
        }

        return Page();
    }

    public IActionResult OnPost()
    {
        // Hent båden igen på serveren – stol ikke på, hvad klienten poster
        Boat = _fleet.Search(Id);
        if (Boat == null)
            return RedirectToPage("/Index");

        if (EndDate < StartDate)
        {
            ModelState.AddModelError(nameof(EndDate), "Slutdato kan ikke være før startdato.");
        }

        if (!ModelState.IsValid)
            return Page();

        // TODO: Opret booking-objekt og gem det via et booking-repository
        // var booking = new Booking(Boat.Id, StartDate, EndDate, Destination, currentUserId);
        // _bookingRepo.Create(booking);

        return RedirectToPage("/Bookings/AllBookings");
    }
}
