#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab3.Models;

using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Lab3.Pages;

namespace Lab3.Pages_Signup
{
    public class ViewModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        
        private readonly UserManager<HikeUser> _userManager;
        private readonly SignInManager<HikeUser> _signInManager;

        public string Username { get; set; }
        public IList<Signup> Signup { get; set; }
        private readonly StoreDBContext _context;
        //private readonly UserManager<User> _userManager;
        public ViewModel(StoreDBContext context, UserManager<HikeUser> userManager,
            SignInManager<HikeUser> signInManager , ILogger<IndexModel> logger)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
             _logger = logger;
        }


        public async Task<IActionResult> OnGetAsync()
        {

            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
            var userHikes = from m in _context.Signup
                              select m;
            userHikes = userHikes.Where(s => s.HikeUser == user);
            Signup = await userHikes.ToListAsync();
                return Page();
            }
            else
            {
                _logger.Log(LogLevel.Information, "**NO user is  authenticated! BAD VERY BAD!***");
                return RedirectToPage("../Hike/Index");
            }

        }

    }
}
