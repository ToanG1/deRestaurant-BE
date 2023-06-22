using System;
using System.ComponentModel.DataAnnotations;
namespace DeRestaurant.Models.Entitices
{
	public class Bill
	{
		public int id { get; set; }
		public String guest { get; set; }
		public DateTime create_at { get; set; }
		public String dish_ids { get; set; }
		public Comment? comment { get; set; }
		public Bill()
		{

		}
	}
}

