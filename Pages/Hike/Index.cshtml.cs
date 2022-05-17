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

        public async Task OnGetAsync()
        {
            Hike = await _context.Hike.ToListAsync();
        }
    }
}
