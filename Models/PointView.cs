
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Lab3.Models;


public class PointView
{
    public int PointId { get; set; }
    public decimal? Lat { get; set; }
    public decimal? Lng { get; set; }
    public int RouteId { get; set; }
    public bool IsStart { get; set; }
}