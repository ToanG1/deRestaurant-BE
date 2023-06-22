using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace DeRestaurant.Models
{
	public class Dish
	{
        public int id { get; set; }
		public string name { get; set; }
		public int rating { get; set; } = 0;
		public int num_of_rating { get; set; } = 0;
		public string description { get; set; }
		public string images { get; set; }
		public DateTime create_at { get; set; } = DateTime.Now;
		public DateTime delete_at { get; set; }
		public List<Comment> comments { get; set; } = null;
		public Dish()
		{
		}
	}
}

