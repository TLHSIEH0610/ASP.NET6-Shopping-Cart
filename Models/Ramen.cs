using System;
namespace RamenKing.Models
{
	public class Ramen
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int Price { get; set; }
        public string ImageURL { get; set; }

        public Ramen()
        {

        }
    }
}

