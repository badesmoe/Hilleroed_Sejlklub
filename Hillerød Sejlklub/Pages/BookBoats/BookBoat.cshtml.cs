using Hillerød_Sejlklub.Models;
using Hillerød_Sejlklub.Repository;
using Hillerød_Sejlklub.Repository.BoatFile;
using Hillerød_Sejlklub.Repository.Users;
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

    private IRepositoryBoat _fleet;
    private IRepositoryUser _users;
    private IRepositoryBookings _bookings;

    [BindProperty]
    public DateOnly StartDate { get; set; }
    [BindProperty]
    public DateOnly EndDate { get; set; }
    [BindProperty]
    [Required]
    [Display(Name = "Farvand / destination")]
    public string Destination { get; set; }

    public Boat? Boat { get; private set; }

    public BookBoatModel(IRepositoryBoat repositoryBoat, IRepositoryUser repositoryUser, IRepositoryBookings repositoryBookings)
    {
        _fleet = repositoryBoat;
        _users = repositoryUser;
        _bookings = repositoryBookings;
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
        Boat = _fleet.Search(Id);
        if (Boat == null)
            return RedirectToPage("/Index");

        if (EndDate < StartDate)
        {
            ModelState.AddModelError(nameof(EndDate), "Slutdato kan ikke være før startdato.");
        }

        if (!ModelState.IsValid)
            return Page();
        return RedirectToPage("/Bookings/AllBookings");
        User? user = _users.Search("annahansen@gmail.com");
        if (_bookings.AddBooking(new Booking(user, Boat, StartDate, EndDate, Destination)))
            return RedirectToPage("/Bookings/AllBookings");
        else
            return Page();

    }
}
