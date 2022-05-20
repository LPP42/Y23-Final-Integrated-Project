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
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Point>>> GetPointList()
    {
        return await _context.Point.ToListAsync();
    }

    // GET: api/Point/5

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

    // POST: api/Point
    [HttpPost]
    public async Task<ActionResult<Point>> PostPoint(Point Point)
    {
        _context.Point.Add(Point);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPoint), new { id = Point.PointId }, Point);
    }
}

