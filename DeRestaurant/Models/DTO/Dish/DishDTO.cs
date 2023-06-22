namespace DeRestaurant.Models.DTO
{
	public class DishDTO
	{
        public int id { get; set; }
        public string name { get; set; }
        public int rating { get; set; }
        public int num_of_rating { get; set; }
        public string description { get; set; }
        public string images { get; set; }
        public DateTime create_at { get; set; }
        public DateTime delete_at { get; set; }
        public List<CommentDTO> comments { get; set; }
        public DishDTO(Dish dish)
		{
            this.id = dish.id;
            this.name = dish.name;
            this.rating = dish.rating;
            this.num_of_rating = dish.num_of_rating;
            this.description = dish.description;
            this.images = dish.images;
            this.create_at = dish.create_at;
            this.delete_at = dish.delete_at;
    }
	}
}

