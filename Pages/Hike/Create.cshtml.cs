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
using Lab3.Models;

namespace Lab3.Pages_Hike
{
    public class CreateModel : RouteCallerPageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly StoreDBContext _context;
        private readonly UserManager<HikeUser> _userManager;
        [BindProperty]
        public Lab3.Models.Route Route { get; set; }
        [BindProperty]
        public Hike Hike { get; set; }

        public CreateModel(StoreDBContext context, ILogger<IndexModel> logger, UserManager<HikeUser> userManager)//  UserManager<HikeUser> userManager
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                _logger.Log(LogLevel.Information, "************************* User is Authenticated *************************");
                PopulateRouteList(_context);
                return Page();
            }
            else
            {
                _logger.Log(LogLevel.Information, "************************* User is not Authenticated *************************");
            }
            return RedirectToPage("./Index");
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (User.Identity.IsAuthenticated)
            {


                ClaimsPrincipal currentUser = this.User;

                var newHike = new Hike();
                // TryUpdateModelAsync<Hike>()

                if (await TryUpdateModelAsync<Hike>(
                     newHike,
                     "hike",   // Prefix for form value.
                     s => s.HikeId, s => s.Name, s => s.RouteId, s => s.ScheduledTime, s => s.Description))
                {
                    newHike.Organizer = await _userManager.GetUserAsync(User);
                    _context.Hike.Add(newHike);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }

                // Select DepartmentID if TryUpdateModelAsync fails.
                PopulateRouteList(_context, newHike.RouteId);
            }
            return Page();

            // return RedirectToPage("./Index");
        }

        // public override bool Equals(object obj)
        // {
        //     return obj is CreateModel model &&
        //            EqualityComparer<UserManager<HikeUser>>.Default.Equals(userManager, model.userManager);
        // }
    }
}
