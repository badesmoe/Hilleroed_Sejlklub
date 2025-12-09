using Hillerød_Sejlklub.Models;
using Hillerød_Sejlklub.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hillerød_Sejlklub.Pages.Bookings
{
    public class AllBookingsModel : PageModel
    {
        private IRepositoryBookings _bookings;

        public string? Destination { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool StartInvestigation { get; set; }
        public int BoatId { get; set; }
        public Boat? Boat { get; }
        //public User? User { get; }
        public List<Booking> Bookings { get; private set; }

        public AllBookingsModel(IRepositoryBookings repositoryBookings)
        {
            _bookings = repositoryBookings;
        }


        public void OnGet()
        {
            Bookings = _bookings.GetAllBookings();
        }
    }
}
