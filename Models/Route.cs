
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3.Models;
public enum RouteDifficultyLevel { Beginner, Easy, Medium, Hard, Pro }
public enum RouteLengthLevel {Shorter, Short, Long, Longer}

public class Route
{
    public int RouteId { get; set; }
    public string? Name { get; set; }
    [Range(0, 5)]
    //[DataType(DataType.Currency)]
    //[Column(TypeName = "decimal(3,2)")]
    public RouteDifficultyLevel Difficulty { get; set; }
    public RouteLengthLevel Distance { get; set; }
    //[DataType(DataType.Time)]
    // public uint ExpectedDuration {get;set;}
    public virtual IList<Point>? RoutePoints { get; set; }

}