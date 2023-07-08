namespace RamenKing.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int RamenId { get; set; }
        public string RamenName { get; set; }
        public int Quantity { get; set; } 
        public int Price { get; set; }

        //public CartItem(Ramen ramen)
        //{
        //    RamenId = ramen.Id;
        //    RamenName = ramen.Name;
        //    Quantity = 1;
        //    Price = ramen.Price;
        //}
    }
}

