#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab3.Models;

namespace Lab3.Pages_Hike
{
    public class IndexModel : PageModel
    {
        private readonly StoreDBContext _context;

        public IndexModel(StoreDBContext context)
        {
            _context = context;
        }

        public IList<Hike> Hike { get;set; }
        [BindProperty(SupportsGet = true)]
        public bool filterOn { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; }
        [BindProperty(SupportsGet = true)]
        public RouteDifficultyLevel? DifficultyLevel { get; set; }
        [BindProperty(SupportsGet = true)]
        public RouteLengthLevel? LengthLevel { get; set; }
        public async Task OnGetAsync()
        {
            var hikes = from p in _context.Hike select p;
            if (filterOn)
            {
                // filter by name
                if (!string.IsNullOrEmpty(SearchName))
                {
                    hikes = hikes.Where(p => p.Name.Contains(SearchName));
                }

                // filter by difficulty
                if (DifficultyLevel != null)
                {
                    hikes = hikes.Where(p => p.Route.Difficulty ==  DifficultyLevel);
                }

                // filter by distance
                if (LengthLevel != null)
                {
                    hikes = hikes.Where(p => p.Route.Distance ==  LengthLevel);
                }

            }
            
            Hike = await hikes.ToListAsync();
        }
    }
}
