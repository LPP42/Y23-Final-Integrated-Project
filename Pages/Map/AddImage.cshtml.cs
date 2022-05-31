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
using System.Diagnostics;

namespace Lab3.Pages_Map
{
    
 public class AddImageModel : RouteCallerPageModel
    {
        //private readonly ILogger<IndexModel> _logger;
        private readonly StoreDBContext _context;
        private readonly UserManager<HikeUser> _userManager;
        [BindProperty]
        public Image image { get; set; }

        [BindProperty]
        public Lab3.Models.Route Route { get; set; }
        public IFormFile fileImg{ get; set; }
        public AddImageModel(StoreDBContext context, UserManager<HikeUser> userManager)//  UserManager<HikeUser> userManager
        {
            _userManager = userManager;
            _context = context;
            //_logger = logger;
        }
        
        public IActionResult OnGet()
        {
            PopulateRouteList(_context);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            ClaimsPrincipal currentUser = this.User;
            var newImage = new Image();

            if (await TryUpdateModelAsync<Image>(
                 newImage,
                 "image"))
                 //s => s.ImageId, s => s.Name, s => s.RouteId, s => s.ScheduledTime, s => s.Description))
            {
                
                var fileName = fileImg.FileName;
                newImage.File = "~/images/"+fileName;
                newImage.Description=image.Description;
                newImage.Route=image.Route;
                _context.Image.Add(newImage);
                await _context.SaveChangesAsync();
                return RedirectToPage("../Map/AddImageConfirm");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateRouteList(_context, newImage.RouteId);
            return Page();

            // return RedirectToPage("./Index");
        }

    }
}