using System;
namespace DeRestaurant.Models.DTO
{
	public class CreateDishRequest
	{
		public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string images { get; set; }
        public CreateDishRequest()
		{
		}
	}
}

