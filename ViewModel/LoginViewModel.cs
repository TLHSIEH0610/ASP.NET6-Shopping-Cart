using System;
using System.ComponentModel.DataAnnotations;


namespace RamenKing.ViewModel
{
	public class LoginViewModel
	{
		[Display(Name ="Email Address")]
		[Required]
		public string EmailAddress { get; set; }
		[DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
	}
}

