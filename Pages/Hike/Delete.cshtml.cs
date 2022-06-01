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
        public IList<Signup> Hiker { get;set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Hike = await _context.Hike.FirstOrDefaultAsync(m => m.HikeId == id);
            var hikers = from p in _context.Signup select p;
            hikers = hikers.Where(p => p.Hike ==  Hike);
            Hiker = await hikers.ToListAsync();
            if (Hike == null)
            {
                return NotFound();
            }
            
            if (Hike != null && Hiker.Count != 0)
            {
               TempData["msg"] = "<script>alert('There are people signed up! We have to inform them before removing this hike!');</script>";
               
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
            var hikers = from p in _context.Signup select p;
            hikers = hikers.Where(p => p.Hike ==  Hike);
            Hiker = await hikers.ToListAsync();

            if (Hike != null && Hiker.Count == 0)
            {
                _context.Hike.Remove(Hike);
                //await _context.SaveChangesAsync();
                
            } else if (Hike != null && Hiker.Count != 0)
            {
               TempData["msg"] = "<script>alert('There are people signed up! We have to inform them before removing this hike!');</script>";
               
            }
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
