using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DeRestaurant.Models.Entitices;

namespace DeRestaurant.Models
{
	public class Comment
	{
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
		public string content { get; set; }
		public int rating { get; set; }
		public string images { get; set; }
		public DateTime create_at { get; set; } = DateTime.Now;
		public DateTime delete_at { get; set; }

		public bool is_verified { get; set; } = false;
		public bool is_approved { get; set; } = false;
        public int billid { get; set; }
		public Bill bill { get; set; }
		public List<Dish> dishes { get; set; }
        public Comment() 
		{
		}
	}
}

