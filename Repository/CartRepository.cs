using RamenKing.Data;
using RamenKing.Models;
using RamenKing.Interfaces;

namespace RamenKing.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly AppDbContext _context;

        public CartRepository(AppDbContext ramenContext)
        {
            _context = ramenContext;
        }

        public void AddToCart(CartItem cartItem, int amount)
        {
            throw new NotImplementedException();
        }

        public Cart GetCart()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CartItem> GetCartItems()
        {
            throw new NotImplementedException();
        }

        public void RemoveFromCart(CartItem cartItem)
        {
            throw new NotImplementedException();
        }
    }
}
