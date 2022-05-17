
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3.Models;


public class Route
{
	public int RouteId { get; set; }
	public string? Name { get; set; }
	[Range(0, 5)]
	//[DataType(DataType.Currency)]
	//[Column(TypeName = "decimal(3,2)")]
	public uint Difficulty { get; set; } 
	public uint Distance { get; set; } = 0;
	//[DataType(DataType.Time)]
	public uint ExpectedDuration {get;set;}
	public virtual IList<Point>? RoutePoints { get; set; }

}