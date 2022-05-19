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
namespace Lab3.Pages_Signup
{
    public class RemoveModel : PageModel
    {
        private readonly UserManager<HikeUser> _userManager;
        private readonly SignInManager<HikeUser> _signInManager;

        public string Username { get; set; }
        public uint Quantity { get; set; }
        private readonly StoreDBContext _context;
        //private readonly UserManager<ShopUser> _userManager;
        public RemoveModel(StoreDBContext context, UserManager<HikeUser> userManager,
            SignInManager<HikeUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<IActionResult> OnGetAsync(uint? id)
        {

            // var user = await _userManager.GetUserAsync(User);
            // if (user == null)
            // {
            //     return Redirect("/Identity/Account/Login");
            // }

            //var product = await _context.Product.FirstOrDefaultAsync(m => m.ProductId == id);
            //var customer = await _context.ShopUser.Where(c => c.UserName == ).FirstOrDefaultAsync();
            //var userName = await _userManager.GetUserAsync(user);
            // var cart = await _context.Cart.FirstOrDefaultAsync(c => c.Product == product && c.ShopUser == user);
            var signup = await _context.Signup.FirstOrDefaultAsync(c => c.SignupId == id);
            if (signup != null)
            {
                _context.Signup.Remove(signup);
            }

            await _context.SaveChangesAsync();

            // if (product == null)
            // {
            //     return NotFound();
            // }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.


    }
}
