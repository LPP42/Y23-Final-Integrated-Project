#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class StoreDBContext : IdentityDbContext
{
	public StoreDBContext(DbContextOptions<StoreDBContext> options)
		 : base(options)
	{
	}

	public DbSet<Lab3.Models.Route> Route { get; set; }
	public DbSet<Lab3.Models.Hike> Hike { get; set; }
	public DbSet<Lab3.Models.Point> Point { get; set; }
	public DbSet<Lab3.Models.Image> Image { get; set; }
	//public DbSet<User> User { get; set; }
}
