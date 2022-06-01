#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab3.Models;
using Lab3.Areas.Identity.Pages.Account.Manage;

namespace Lab3.Pages_Map
{
    public class MapModel : PageModel
    {
        private readonly StoreDBContext _context;
        private readonly UserManager<HikeUser> _userManager;
        private readonly ILogger<IndexModel> _logger;

        [BindProperty(SupportsGet = true)]
        public RouteDifficultyLevel? DifficultyLevel { get; set; }
        [BindProperty(SupportsGet = true)]
        public RouteLengthLevel? LengthLevel { get; set; }

        public MapModel(StoreDBContext context,ILogger<IndexModel> logger, UserManager<HikeUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }

        // public IList<Map> Map { get;set; }

        // public async Task OnGetAsync()
        // {
        //     Map = await _context.Map.ToListAsync();
        // }
    }
}
