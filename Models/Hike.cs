
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3.Models;


public class Hike
{
	public int HikeId { get; set; }
	public string? Name { get; set; }
	public string? Description { get; set; } 
	public virtual HikeUser? Organizer { get; set; }
	public DateTime? ScheduledTime {get;set;}
	public virtual Route? Route {get;set;}
	//public List<OrderItem> Items
	public int RouteId { get; set; }

}