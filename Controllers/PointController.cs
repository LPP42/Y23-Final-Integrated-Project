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

    //GET: api/Point
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PointView>>> GetPointList()
    {
        List<PointView> PointList = new();
        var result = await _context.Point.ToListAsync();
        foreach (Point p in result)
        {
            PointList.Add(new PointView { PointId = p.PointId, Lat = p.Lat, Lng = p.Lng, RouteId = p.RouteId, IsStart = p.IsStart });
        }
        return PointList;
    }

    // GET: api/Point
    [HttpGet("route/{id}")]
    public async Task<ActionResult<IEnumerable<PointView>>> GetRoutePointList(uint id)
    {
        List<PointView> PointList = new();

        var result = await _context.Point.Where(r => r.RouteId == id).ToListAsync();
        foreach (Point p in result)
        {
            PointList.Add(new PointView { PointId = p.PointId, Lat = p.Lat, Lng = p.Lng, RouteId = p.RouteId, IsStart = p.IsStart });
        }
        return PointList;
    }

    // POST: api/Point
    [HttpPost]
    public async Task<ActionResult<Point>> PostPoint(Point Point)
    {
        _context.Point.Add(Point);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Point), new { id = Point.PointId }, Point);
    }
}

