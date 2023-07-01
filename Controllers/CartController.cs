using Microsoft.AspNetCore.Mvc;

namespace RamenKing.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
