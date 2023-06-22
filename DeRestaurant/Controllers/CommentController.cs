using System;
using DeRestaurant.Models;
using DeRestaurant.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DeRestaurant.Repository.IRepository;
using DeRestaurant.Models.DTO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;

namespace DeRestaurant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
	{
        private IRepositoryWrapper _wrapper;

        public CommentController(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        [HttpGet]
        public ActionResult<CommentDTO> getAllComment()
        {
            var List = _wrapper.Comment.FindAllCommentRelated();

            if (List.Count() < 0)
            {
                return StatusCode(204);
            }
            else
            {
                var res = new List<CommentDTO>();
                List.ToList().ForEach(delegate(Comment item){
                    var temp = new CommentDTO(item);
                    res.Add(temp);
                });
                return Ok(res);
            }
        }

        [HttpPost]
        public ActionResult createComment([FromBody] CreateCommentRequest request)
        {
            var bill = _wrapper.Bill.FindSingle(x => x.id.Equals(request.billid));
            if (bill == null) return BadRequest("Bữa ăn không tồn tài !");
            else
            {
                Comment comment = new Comment();
                comment.bill = bill;
                comment.billid = request.billid;
                comment.content = request.content;
                comment.images = request.images;
                comment.rating = request.rating;
                var dishes = new List<Dish>();
                JsonSerializer.Deserialize<List<int>>(bill.dish_ids).ForEach(delegate (int id)
                {
                    dishes.Add(_wrapper.Dish.FindSingle(x => x.id.Equals(id)));
                });
                comment.dishes = dishes;
                _wrapper.Comment.Create(comment);
                bill.comment = comment;
                _wrapper.Bill.Update(bill);
                _wrapper.Save();
                Console.WriteLine(request.billid + "is created");
                return Ok();
            }
        }
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult approveComment([FromRoute] int id)
        {
            var comment = _wrapper.Comment.FindSingle(x => x.id.Equals(id));
            if (comment == null || comment.is_verified == false) return BadRequest("Bình luận không tồn tại");
            else
            {
                comment.is_approved = true;
                _wrapper.Comment.Update(comment);
                _wrapper.Save();
                Console.WriteLine(id + " is updated");
                return Ok();
            }
        }
        [Authorize]
        [HttpDelete("{id}")]
        public ActionResult deleteComment([FromRoute] int id)
        {
            var comment = _wrapper.Comment.FindSingle(x => x.id.Equals(id));
            if (comment == null) return BadRequest("Bình luân không tồn tại");
            else
            {
                _wrapper.Comment.Delete(comment);
                _wrapper.Save();
                Console.WriteLine(id + " is deleted");
                return Ok();
            }
        }
    }
}

