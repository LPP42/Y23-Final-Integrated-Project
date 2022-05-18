
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3.Models;


public class Signup
{
	public int SignupId { get; set; }
	
	public virtual User? User {get;set;}
	public virtual Hike? Hike {get;set;}

	
}