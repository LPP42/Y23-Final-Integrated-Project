
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3.Models;


public class Point
{
	public int PointId { get; set; }
	[Column(TypeName = "decimal(9,6)")]
	public decimal? Lat { get; set; }
	[Column(TypeName = "decimal(9,6)")]
	public decimal? Lng { get; set; } 
	public virtual Route? Route {get;set;}

	
}