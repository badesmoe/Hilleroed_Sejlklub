using Hillerød_Sejlklub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Hillerød_Sejlklub.Pages.Boats
{
    public class AllBoatsModel : PageModel
    {

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

        public List<Boat> Fleet { get; private set; } = new List<Boat>
        {
            new Boat(101, "Sailboat", "Hanse 315", "Sea Breeze", "Inboard Diesel", 9.5, 3.3, 1.6, 2018),
            new Boat(202, "Motorboat", "Yamaha 242X", "Wave Runner", "Outboard Gasoline", 7.3, 2.5, 0.9, 2020),
            new Boat(303, "Catamaran", "Lagoon 42", "Twin Spirit", "Inboard Diesel", 12.8, 7.5, 1.2, 2019),
            new Boat(404, "Sailboat", "Beneteau Oceanis 30.1", "Wind Dancer", "Inboard Diesel", 9.3, 3.2, 1.5, 2021),
            new Boat(505, "Motorboat", "Sea Ray SPX 190", "Sun Chaser", "Outboard Gasoline", 5.8, 2.3, 0.7, 2017),
            new Boat(606, "Catamaran", "Fountaine Pajot Lucia 40", "Ocean Breeze", "Inboard Diesel", 11.7, 6.9, 1.1, 2022),
            new Boat(707, "Sailboat", "Jeanneau Sun Odyssey 349", "Blue Horizon", "Inboard Diesel", 10.3, 3.4, 1.4, 2016),
            new Boat(808, "Motorboat", "Bayliner Element E18", "Lake Cruiser", "Outboard Gasoline", 5.5, 2.1, 0.6, 2019),
            new Boat(909, "Catamaran", "Nautitech 40 Open", "Sea Voyager", "Inboard Diesel", 12.0, 7.2, 1.3, 2020)
        };

        public void OnGet()
        {
        }
    }
}
