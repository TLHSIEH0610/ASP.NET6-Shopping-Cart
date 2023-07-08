using System.ComponentModel.DataAnnotations.Schema;

namespace RamenKing.Models
{
    public class Cart
    {
        public int Id { get; set; }
        [ForeignKey("AppUserId")]
        public string AppUserId { get; set; }
        public List<CartItem> CartItems { get; set; } = new List<CartItem> { };
    }
}

