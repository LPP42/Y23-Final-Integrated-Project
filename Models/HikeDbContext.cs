using Microsoft.EntityFrameworkCore;

namespace Lab3.Models;

public class HikeDbContext : DbContext
{
	public HikeDbContext(DbContextOptions<HikeDbContext> options) : base(options)
	{

	}

	public DbSet<Point>? Points { get; set; }

}