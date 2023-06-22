using System;
namespace DeRestaurant.Models.DTO
{
	public class CreateCommentRequest
	{
        public string content { get; set; }
        public int rating { get; set; }
        public string images { get; set; }
        public int billid { get; set; }
        public CreateCommentRequest()
		{
		}
	}
}

