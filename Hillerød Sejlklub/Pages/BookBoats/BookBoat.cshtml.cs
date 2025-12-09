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
    private IRepositoryBoat _fleet;
    private IRepositoryUser _users;
    private IRepositoryBookings _bookings;

    [BindProperty]
    public DateOnly StartDate { get; set; }
    [BindProperty]
    public DateOnly EndDate { get; set; }
    [BindProperty]
    public string Destination { get; set; } = string.Empty;

    [BindProperty]
    public Boat? Boat { get; set; } = null;
    public BookBoatModel(IRepositoryBoat repositoryBoat, IRepositoryUser repositoryUser, IRepositoryBookings repositoryBookings)
    {
        _fleet = repositoryBoat;
        _users = repositoryUser;
        _bookings = repositoryBookings;
    }

    public IActionResult OnGet(int id)
    {
        Boat = _fleet.Search(id);
        if (Boat == null)
            return RedirectToPage("/Index");

        StartDate = DateOnly.FromDateTime(DateTime.Today.AddDays(1));
        EndDate = DateOnly.FromDateTime(DateTime.Today.AddDays(2));

        return Page();
    }

    public IActionResult OnPost()
    {
        User? user = _users.Search("annahansen@gmail.com");
        Boat? boat = _fleet.Search(Boat!.Id);
        if (_bookings.AddBooking(new Booking(user, boat, StartDate, EndDate, Destination)))
            return RedirectToPage("/Bookings/AllBookings");
        else
            return Page();

    }
}
