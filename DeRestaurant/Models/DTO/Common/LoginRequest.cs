using System;
namespace DeRestaurant.Models.DTO.Common
{
	public class LoginRequest
	{
		public String username { get; set; }
		public String passwd { get; set; }
		public LoginRequest() { }
	}
}

