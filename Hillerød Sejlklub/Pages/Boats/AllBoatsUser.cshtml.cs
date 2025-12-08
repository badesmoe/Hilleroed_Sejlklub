using Hillerød_Sejlklub.Models;
using Hillerød_Sejlklub.Repository.BoatFile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hillerød_Sejlklub.Pages.Boats
{
    public class AllBoatsUserModel : PageModel
    {
        private IRepositoryBoat _fleet;


        public List<Boat> Fleet { get; private set; }


       public AllBoatsUserModel(IRepositoryBoat repositoryBoat)
       {
            _fleet = repositoryBoat;
       }

        public void OnGet()
        {
            Fleet = _fleet.GetFleet();
        }
    }
}
