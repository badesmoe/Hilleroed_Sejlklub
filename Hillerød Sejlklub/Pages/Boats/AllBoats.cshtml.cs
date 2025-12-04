using Hillerød_Sejlklub.Models;
using Hillerød_Sejlklub.Repository.BoatFile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hillerød_Sejlklub.Pages.Boats
{
    public class AllBoatsModel : PageModel
    {
        private IRepositoryBoat _fleet;

        public int Id { get; private set; }
        public int SailNumber { get; set; }
        public string? Type { get; set; }
        public string? Model { get; set; }
        public string? Name { get; set; }

        // Engine
        public string? EngineType { get; set; }

        // Measurements
        public double Length { get; set; }
        public double Width { get; set; }
        public double Draft { get; set; }

        public List<Boat> Fleet { get; private set; }

        public AllBoatsModel(IRepositoryBoat repositoryBoat)
        {
            _fleet = repositoryBoat;
        }

        public void OnGet()
        {
            Fleet = _fleet.GetFleet();
        }
    }
}
