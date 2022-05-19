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
public class PointController : ControllerBase
{
    private readonly StoreDBContext _context;

    public PointController(StoreDBContext context)
    {
        _context = context;
    }

    // GET: api/Point
    //return list of points
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Point>>> GetPointList()
    {
        return await _context.Point.ToListAsync();
    }

    // GET: api/Point/5
    // return singular point
    [HttpGet("{id}")]
    public async Task<ActionResult<Point>> GetPoint(uint id)
    {
        var Point = await _context.Point.FindAsync(id);

        if (Point == null)
        {
            return NotFound();
        }
        return Point;
    }

    // PUT: api/Point/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPoint(uint id, Point Point)
    {
        if (id != Point.PointId)
        {
            return BadRequest();
        }

        _context.Entry(Point).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PointExists(id))
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

    // POST: api/Point
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Point>> PostPoint(Point Point)
    {
        _context.Point.Add(Point);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPoint), new { id = Point.PointId }, Point);
    }
    //POST ROUTES
    [HttpPost]
    public async Task<ActionResult<Lab3.Models.Route>> PostRoute(Lab3.Models.Route Route)
    {
        _context.Route.Add(Route);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetRoute), new { id = Route.RouteId }, Route);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchPoint(uint id, Point Point)
    {
        if (id != Point.PointId)
        {
            return BadRequest();
        }
        // var taskItem = await _context.Points.FindAsync(id);
        if (Point == null)
        {
            return NotFound();
        }
        // taskItem.IsComplete = item.IsComplete;
        _context.Update(Point);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/Point/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePoint(uint id)
    {
        var Point = await _context.Point.FindAsync(id);
        if (Point == null)
        {
            return NotFound();
        }

        _context.Point.Remove(Point);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PointExists(uint id)
    {
        return _context.Point.Any(e => e.PointId == id);
    }
}

