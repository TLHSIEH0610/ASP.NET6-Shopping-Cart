using System;
namespace RamenKing.ViewModel
{
	public class EditRamenViewModel
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public int Price { get; set; }
        public IFormFile? Photo { get; set; }
        public string? ImageURL { get; set; }
    }
}

