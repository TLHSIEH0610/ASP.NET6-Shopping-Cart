using Microsoft.AspNetCore.Mvc;
using RamenKing.Interfaces;

namespace RamenKing.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public IActionResult All()
        {
            var cartItems = _cartRepository.GetCart();
            return View(cartItems.CartItems);
        }

        public async Task<IActionResult> Add(int id)
        {
              await _cartRepository.AddToCart(id);
            //return Redirect(redirect);
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public  IActionResult Decrease(int id)
        {
             _cartRepository.RemoveFromCart(id);
            return Redirect(Request.Headers["Referer"].ToString());
        }
    
    }
}
