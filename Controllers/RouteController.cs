#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
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

    public RouteController(StoreDBContext context)
    {
        _context = context;
    }

    // GET: api/Route
    //return list of Routes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Lab3.Models.Route>>> GetRouteList()
    {
        return await _context.Route.ToListAsync();
    }

    // GET: api/Route/5
    // return singular Route
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


    // PUT: api/Route/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRoute(uint id, Lab3.Models.Route Route)
    {
        if (id != Route.RouteId)
        {
            return BadRequest();
        }

        _context.Entry(Route).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RouteExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Route
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Lab3.Models.Route>> PostRoute(Lab3.Models.Route Route)
    {
        _context.Route.Add(Route);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetRoute), new { id = Route.RouteId }, Route);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchRoute(uint id, Lab3.Models.Route Route)
    {
        if (id != Route.RouteId)
        {
            return BadRequest();
        }
        // var taskItem = await _context.Routes.FindAsync(id);
        if (Route == null)
        {
            return NotFound();
        }
        // taskItem.IsComplete = item.IsComplete;
        _context.Update(Route);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/Route/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRoute(uint id)
    {
        var Route = await _context.Route.FindAsync(id);
        if (Route == null)
        {
            return NotFound();
        }

        _context.Route.Remove(Route);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool RouteExists(uint id)
    {
        return _context.Route.Any(e => e.RouteId == id);
    }
}

