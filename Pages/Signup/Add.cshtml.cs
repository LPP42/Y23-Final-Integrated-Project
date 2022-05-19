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

namespace Lab3.Pages_Signup
{
    
    public class AddModel : PageModel
    {
        private readonly UserManager<HikeUser> _userManager;
        private readonly SignInManager<HikeUser> _signInManager;

        public string Username { get; set; }
        //public uint Quantity { get; set; }
        private readonly StoreDBContext _context;
        //private readonly UserManager<ShopUser> _userManager;
        public AddModel(StoreDBContext context, UserManager<HikeUser> userManager,
            SignInManager<HikeUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        
        public async Task<IActionResult> OnGetAsync(uint? id)
        {
            // if (id == null)
            // {
            //     return NotFound();
            // }
            var user = await _userManager.GetUserAsync(User);
                        
            if (id == null)
            {
                return NotFound();
            }
            if (user == null)
            {
                return Redirect("/Identity/Account/Login");
            }

            //var user = userManager.Find(userName);
            //var claimsIdentity = (ClaimsIdentity)User;
            //var user = claimsIdentity.
            var hike = await _context.Hike.FirstOrDefaultAsync(m => m.HikeId == id);
            
            //var customer = await _context.ShopUser.Where(c => c.UserName == ).FirstOrDefaultAsync();
            //var userName = await _userManager.GetUserAsync(user);
            var signup = await _context.Signup.FirstOrDefaultAsync(c => c.Hike == hike && c.HikeUser == user);
            if (hike != null && user != null)
            {
               
                if (signup == null)
                {
                    _context.Signup.Add(new Signup { Hike = hike, HikeUser = user});
                }
                else
                {
                    //ViewData["alert"] = "You are already signed up!";
                    TempData["msg"] = "<script>alert('You are already signed up!');</script>";
                }
                await _context.SaveChangesAsync();

            } else return Redirect("../Hike/Index");
            if (hike == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.


    }
}
