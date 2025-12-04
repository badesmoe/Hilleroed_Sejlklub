using Hillerød_Sejlklub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hillerød_Sejlklub.Pages.Bookings
{
    public class AllBookingsModel : PageModel
    {
        public string? Destination { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool StartInvestigation { get; set; }
        public int BoatId { get; set; }
        public Boat? Boat { get; }
        public User? User { get; }

        public List<Booking> Fleet { get; private set; } = new List<Booking> 
        { 
        };
        public void OnGet()
        {
        }
    }
}
