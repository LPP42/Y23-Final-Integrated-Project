#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab3.Models;

namespace Lab3.Pages_Hike
{
    public class EditModel : PageModel
    {
        private readonly StoreDBContext _context;
        private readonly UserManager<HikeUser> _userManager;
        private readonly ILogger<IndexModel> _logger;

        public EditModel(StoreDBContext context, ILogger<IndexModel> logger, UserManager<HikeUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        [BindProperty]
        public Hike Hike { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (User.Identity.IsAuthenticated)
            {
                _logger.Log(LogLevel.Information, "************************* User is Authenticated *************************");
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
            else
            {
                _logger.Log(LogLevel.Information, "************************* User is NOT Authenticated *************************");
                return RedirectToPage("./Index");
            }
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // if (User.Identity.IsAuthenticated)
            // {
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
            // }
            return RedirectToPage("./Index");
        }

        private bool HikeExists(int id)
        {
            return _context.Hike.Any(e => e.HikeId == id);
        }
    }
}