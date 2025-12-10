using Hillerød_Sejlklub.Models;
using Hillerød_Sejlklub.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hillerød_Sejlklub.Pages.Bookings;

public class AllBookingsModel : PageModel
{
    private IRepositoryBookings _bookings;

    public string? Destination { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool StartInvestigation { get; set; }
    public List<Booking> Bookings { get; private set; }
    public Boat? Boat { get; set; }

    public AllBookingsModel(IRepositoryBookings repositoryBookings)
    {
        _bookings = repositoryBookings;
    }

    public void OnGet()
    {
        Bookings = _bookings.GetAllBookings();
    }


public IActionResult OnPostEndBooking (int id)
    {
        _bookings.EndBooking(id);
        return RedirectToPage("AllBookings");
    }
}
