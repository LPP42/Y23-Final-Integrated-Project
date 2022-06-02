
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Lab3.Models;


public class Point
{
    public int PointId { get; set; }
    [Column(TypeName = "decimal(9,6)")]
    public decimal? Lat { get; set; }
    [Column(TypeName = "decimal(9,6)")]
    public decimal? Lng { get; set; }
    // [JsonIgnore]
    public virtual Route? Route { get; set; }
    // [JsonIgnore]
    public int RouteId { get; set; }
    public bool IsStart {get;set;} 
}