#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab3.Models;

namespace Lab3.Pages_Map
{
    public class RouteCallerPageModel : PageModel
    {
        private readonly StoreDBContext _context;
        
        public SelectList RouteNameSL { get; set; }

        public void PopulateRouteList(StoreDBContext _context,
            object selectedRoute = null)
        {
            var routesQuery = from r in _context.Route
                                   orderby r.Name // Sort by name.
                                   select r;

            RouteNameSL = new SelectList(routesQuery.AsNoTracking(),
                        "RouteId", "Name", selectedRoute);
        }

    }
}
