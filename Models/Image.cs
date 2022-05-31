
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3.Models;


public class Image
{
	public int ImageId { get; set; }
	public string? Description { get; set; }
	public string? File { get; set; } 
	public virtual Route? Route {get;set;}
	public int RouteId { get; set; }
	
}