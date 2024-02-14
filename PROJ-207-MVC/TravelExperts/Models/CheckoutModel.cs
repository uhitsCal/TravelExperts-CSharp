// Written by Keegan

using System.ComponentModel.DataAnnotations;

namespace TravelExperts.Models
{
	public class CheckoutModel
	{
		[Required(ErrorMessage = "Please input the traveler count.")]
		[Range(1, 15, ErrorMessage = "Invalid number.")]
		public int TravelerCount { get; set; }

		[Required(ErrorMessage = "Please input a card name.")]
		[RegularExpression(@"^[0-9]{14,16}$", ErrorMessage = "Card number must be in format XXXXXXXXXXXXXXXX.")]
		public string CardNumber { get; set; }

		[Required(ErrorMessage = "Please input an expiry date.")]
		[RegularExpression(@"^[0-9]{1,2}/[0-9]{1,2}", ErrorMessage = "Please enter expiry in format yy/mm.")]
		public string Expiry { get; set; }

		[Required(ErrorMessage = "Please input a CVV.")]
		[RegularExpression(@"^[0-9]{3}$", ErrorMessage = "CVV is a 3-digit number.")]
		public string CVV { get; set; }

		public bool RememberPayment { get; set; }
	}
}
