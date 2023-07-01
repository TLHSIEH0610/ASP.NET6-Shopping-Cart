using RamenKing.Models;

namespace RamenKing.Interfaces
{
    public interface ICartRepository
    {
        void AddToCart(CartItem cartItem, int amount);
        void RemoveFromCart(CartItem cartItem);
        IEnumerable<CartItem> GetCartItems();
        Cart GetCart();
    }
}
