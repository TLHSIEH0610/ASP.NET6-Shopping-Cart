using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RamenKing.Interfaces;
using RamenKing.Models;
using RamenKing.Repository;
using RamenKing.ViewModel;

namespace RamenKing.Infrastructure.Components
{
	public class MenuCartViewComponent: ViewComponent
    {
		private readonly ICartRepository _cartRepository;


        public MenuCartViewComponent(ICartRepository cartRepository)
		{
            _cartRepository = cartRepository;
        }

		public  IViewComponentResult Invoke()
		{
    
            var cart =  _cartRepository.GetCart();

            var menuCartData = new MenuCartViewModel
            {
                CartCounts = cart.CartItems.Count(),
                TotalPrice = cart.CartItems.Sum(c => c.Price * c.Quantity)
            };

            return View(menuCartData);

		}
	}
}

