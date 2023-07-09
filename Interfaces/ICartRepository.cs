using RamenKing.Models;

namespace RamenKing.Interfaces
{
    public interface ICartRepository
    {
        Task<bool> AddToCart(int ramenId);
        bool RemoveFromCart(int ramenId);
        Cart GetCart();
        bool Add(CartItem cartItem);
        bool Update(CartItem cartItem);
        bool Delete(CartItem cartItem);
        bool Save();
    }
}
