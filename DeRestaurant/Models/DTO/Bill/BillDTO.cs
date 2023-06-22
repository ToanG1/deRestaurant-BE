using System;
using DeRestaurant.Models.Entitices;

namespace DeRestaurant.Models.DTO
{
	public class BillDto
	{
        public int id { get; set; }
        public String guest { get; set; }
        public DateTime create_at { get; set; }
        public String dish_ids { get; set; }

        public BillDto(Bill bill)
		{
            this.id = bill.id;
            this.guest = bill.guest;
            this.create_at = bill.create_at;
            this.dish_ids = bill.dish_ids;
		}
	}
}

