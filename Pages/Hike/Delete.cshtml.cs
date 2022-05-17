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
    public class DeleteModel : PageModel
    {
        private readonly StoreDBContext _context;

        public DeleteModel(StoreDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Hike Hike { get; set; }

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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hike = await _context.Hike.FindAsync(id);

            if (Hike != null)
            {
                _context.Hike.Remove(Hike);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
