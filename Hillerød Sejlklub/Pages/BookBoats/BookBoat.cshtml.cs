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
    public string Destination { get; set; }
    [BindProperty]
    public Boat? Boat { get; set; }
    public int Id { get; set; }

    public BookBoatModel(IRepositoryBoat repositoryBoat, IRepositoryUser repositoryUser, IRepositoryBookings repositoryBookings)
    {
        _fleet = repositoryBoat;
        _users = repositoryUser;
        _bookings = repositoryBookings;
    }

    public IActionResult OnGet(int id)
    {
        Boat = _fleet.Search(id);
        Id = id;
        if (Boat == null)
            return RedirectToPage("/Index"); //NotFound er ikke defineret endnu 

        return Page();
    }

    public IActionResult OnPost()
    {
        User? user = _users.Search("annahansen@gmail.com");
        if (_bookings.AddBooking(new Booking(user, Boat, StartDate, EndDate, Destination)))
            return RedirectToPage("/Bookings/AllBookings");
        else
            return Page();

    }
}
