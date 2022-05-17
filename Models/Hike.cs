
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3.Models;


public class Hike
{
	public int HikeId { get; set; }
	public string? Name { get; set; }
	[Range(0, 5)]
	public string? Description { get; set; } 
	//public virtual User? Organizer { get; set; }
	public DateTime? ScheduledTime {get;set;}
	public virtual Route? Route {get;set;}
	//public List<OrderItem> Items
	
}