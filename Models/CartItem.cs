namespace RamenKing.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public Ramen Ramen { get; set; }
        public int Amount { get; set; }
    }
}

