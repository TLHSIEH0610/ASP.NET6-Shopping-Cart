using RamenKing.Data;
using RamenKing.Models;
using RamenKing.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace RamenKing.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IRamenRepository _ramenRepository;

        public CartRepository(AppDbContext ramenContext, IHttpContextAccessor httpContextAccessor, IRamenRepository ramenRepository)
        {
            _context = ramenContext;
            _httpContextAccessor = httpContextAccessor;
            _ramenRepository = ramenRepository;
        }

        public bool Add(CartItem cartItem)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddToCart(int ramenId)
        {
            
            var cart =GetCart();

            var ramen = await _ramenRepository.GetRamenById(ramenId);

            var newCartItem = new CartItem()
            {
                RamenId = ramen.Id,
                RamenName = ramen.Name,
                Quantity = 1,
                Price = ramen.Price
            };


            cart.CartItems.Add(newCartItem);

            return Save();

             

        }

        public bool Delete(CartItem cartItem)
        {
            throw new NotImplementedException();
        }


        public  Cart GetCart()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var hasCart =  _context.Carts.Include(c=>c.CartItems).FirstOrDefault(c => c.AppUserId == userId);

            if(hasCart == null)
            {
                var newCart = new Cart
                {
                    AppUserId = userId
                };
                _context.Carts.Add(newCart);
                Save();
                hasCart = newCart;
            }

            return hasCart;

        }
        

        public Task<bool> RemoveFromCart(CartItem cartItem)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(CartItem cartItem)
        {
            throw new NotImplementedException();
        }
    }
}
