using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace RamenKing.Models
{
	public class MvcRamenContext:IdentityDbContext<IdentityUser>
	{
		public MvcRamenContext(DbContextOptions<MvcRamenContext> options): base(options)
		{
		}
		public DbSet<Ramen> Ramen { get; set; }
	}
}

