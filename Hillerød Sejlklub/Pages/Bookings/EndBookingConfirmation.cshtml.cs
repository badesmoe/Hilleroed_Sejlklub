using Hillerød_Sejlklub.Models;
using Hillerød_Sejlklub.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hillerød_Sejlklub.Pages.Bookings;

public class EndBookingConfirmationModel : PageModel
{
    private readonly IRepositoryBookings _repo;

    public Booking Booking { get; set; }

    public EndBookingConfirmationModel(IRepositoryBookings repo)
    {
        _repo = repo;
    }

    public IActionResult OnGet(int id)
    {
        Booking = _repo.SearchBookings(id);
        if (Booking == null)
            return RedirectToPage("/Bookings/AllBookings");

        return Page();
    }

    public IActionResult OnPost(int id)
    {
        _repo.EndBooking(id);
        return RedirectToPage("/Bookings/AllBookings");
    }
}
