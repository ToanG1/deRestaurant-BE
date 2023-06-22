using DeRestaurant.Models.DTO;

namespace DeRestaurant.Models.DTO
{
	public class CommentDTO
	{
        public int id { get; set; }
        public string content { get; set; }
        public int rating { get; set; }
        public string images { get; set; }
        public DateTime create_at { get; set; }
        public DateTime delete_at { get; set; }
        public bool is_approved { get; set; } = false;
        public BillDto bill { get; set; }
        public List<DishDTO> dishes { get; set; }
        public CommentDTO(Comment comment)
		{
            this.id = comment.id;
            this.content = comment.content;
            this.rating = comment.rating;
            this.images = comment.images;
            this.create_at = comment.create_at;
            this.delete_at = comment.delete_at;
            this.is_approved = comment.is_approved;
            this.bill = new BillDto (comment.bill);
            var list = new List<DishDTO>();
            comment.dishes.ForEach(delegate (Dish item)
            {
                list.Add(new DishDTO(item));
            });
            this.dishes = list;
		}
	}
}

