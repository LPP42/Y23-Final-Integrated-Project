#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab3.Models;
using System.Diagnostics;

namespace Lab3.Pages_Hike
{
    public class DetailsModel : PageModel
    {
        private readonly StoreDBContext _context;

        public DetailsModel(StoreDBContext context)
        {
            _context = context;
        }

        public Hike Hike { get; set; }
        public IList<Signup> Hiker { get;set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hike = await _context.Hike.FirstOrDefaultAsync(m => m.HikeId == id);

            if (Hike == null)
            {
                return NotFound();
            }

            var hikers = from p in _context.Signup select p;
            hikers = hikers.Where(p => p.Hike ==  Hike);
            Hiker = await hikers.ToListAsync();
            return Page();
        }
    }
}
