#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab3.Models;

namespace Lab3.Pages_Map
{
    public class MapModel : PageModel
    {
        private readonly StoreDBContext _context;

        public MapModel(StoreDBContext context)
        {
            _context = context;
        }

        // public IList<Map> Map { get;set; }

        // public async Task OnGetAsync()
        // {
        //     Map = await _context.Map.ToListAsync();
        // }
    }
}
