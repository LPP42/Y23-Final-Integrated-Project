#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab3.Models;

namespace Lab3.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RouteController : ControllerBase
{
    private readonly StoreDBContext _context;

    private readonly ILogger<RouteController> _logger;
    private readonly UserManager<HikeUser> _userManager;

    public RouteController(StoreDBContext context, ILogger<RouteController> logger, UserManager<HikeUser> userManager)
    {
        _context = context;
        _logger = logger;
        _userManager = userManager;
    }

    // GET: api/Route
    //return list of Routes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Lab3.Models.Route>>> GetRouteList()
    {
        return await _context.Route.ToListAsync();
    }

    // GET: api/Route/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Lab3.Models.Route>> GetRoute(uint id)
    {
        var Route = await _context.Route.FindAsync(id);
        if (Route == null)
        {
            return NotFound();
        }
        return Route;
    }

    // POST: api/Route
    [HttpPost]

    public async Task<ActionResult<Lab3.Models.Route>> PostRoute(Lab3.Models.Route Route)
    {
        if (User.Identity.IsAuthenticated)
        {
            _context.Route.Add(Route);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRoute), new { id = Route.RouteId }, Route);
        }
        return null;
    }
}

