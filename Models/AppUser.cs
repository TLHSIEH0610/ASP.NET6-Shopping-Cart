using System;
using Microsoft.AspNetCore.Identity;

namespace RamenKing.Models
{
	public class AppUser: IdentityUser
	{
		public string PostalAddress { get; set; }
		public IEnumerable<Order>? Orders { get; set; }
		public Cart? Cart { get; set; }
		public string? PreferName{ get; set; }
	}
}

