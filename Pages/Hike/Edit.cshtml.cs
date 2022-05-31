#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab3.Models;

namespace Lab3.Pages_Hike
{
    public class EditModel : RouteCallerPageModel
    {
        private readonly StoreDBContext _context;

        public EditModel(StoreDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Hike Hike { get; set; }
        [BindProperty]
        public Lab3.Models.Route Route { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            Hike = await _context.Hike.FirstOrDefaultAsync(m => m.HikeId == id);
            PopulateRouteList(_context);
            if (Hike == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Hike).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HikeExists(Hike.HikeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            return RedirectToPage("./Index");
        }

        private bool HikeExists(int id)
        {
            return _context.Hike.Any(e => e.HikeId == id);
        }
    }
}
