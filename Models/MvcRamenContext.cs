using System;
using Microsoft.EntityFrameworkCore;

namespace RamenKing.Models
{
	public class MvcRamenContext:DbContext
	{
		public MvcRamenContext(DbContextOptions<MvcRamenContext> options): base(options)
		{
		}
		public DbSet<Ramen> Ramen { get; set; }
	}
}

