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

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Add(int id)
        {
             await _cartRepository.AddToCart(id);
            return RedirectToAction("All", "Ramen");
        }
    }
}
