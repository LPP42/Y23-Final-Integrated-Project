#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab3.Models;

namespace Lab3.Pages_Hike
{
    public class CreateModel : PageModel
    {
        private readonly StoreDBContext _context;
        [BindProperty]
        public Lab3.Models.Route Route { get; set; }
        [BindProperty]
        public Hike Hike { get; set; }

        public CreateModel(StoreDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                //System.Diagnostics.Debug.WriteLine("fgfgsgs");
                return Page();
            }
            //System.Diagnostics.Debug.WriteLine("fgfgsgs");
            _context.Hike.Add(Hike);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
