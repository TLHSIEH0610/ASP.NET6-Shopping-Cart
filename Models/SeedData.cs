using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace RamenKing.Models
{
	public class SeedData
	{
		public SeedData()
		{

		}

		public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcRamenContext(serviceProvider.GetRequiredService<DbContextOptions<MvcRamenContext>>()))
            {
                // Look for any movies.
                if (context.Ramen.Any())
                {
                    return;   // DB has been seeded
                }
                context.Ramen.AddRange(
                new Ramen { Id = 1, Name = "Fuji-Ramen", Price = 12, Description = "Undefeatable flavour", ImageURL = "/images/r1" },
                new Ramen { Id = 2, Name = "Hokido-Best", Price = 10, Description = "Souce is from the northest island", ImageURL = "/images/r3" }
                );
                context.SaveChanges();
            }
        }
	}
}

