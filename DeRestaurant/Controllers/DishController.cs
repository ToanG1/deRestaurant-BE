using Microsoft.AspNetCore.Mvc;
using DeRestaurant.Models;
using DeRestaurant.Models.DTO;
using DeRestaurant.Repository;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using DeRestaurant.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
namespace DeRestaurant.Controllers
{
    [ApiController]
	[Route("[controller]")]
    public class DishController : ControllerBase
	{
        private IRepositoryWrapper _wrapper;

        public DishController(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        [HttpGet]
        public ActionResult<Dish> getAllDish()
        {
            var List = _wrapper.Dish.FindAll();
            if (List.Count() < 0)
            {
                return StatusCode(204);
            }
            else
            {
                var res = new List<DishDTO>();
                List.ToList().ForEach(delegate (Dish item)
                {
                    res.Add(new DishDTO(item));
                });
                return Ok(res);
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult createDish([FromBody] CreateDishRequest request)
        {
            try
            {
                Dish dish = new Dish();
                dish.id = request.id;
                dish.name = request.name;
                dish.description = request.description;
                dish.images = request.images;
                _wrapper.Dish.Create(dish);
                _wrapper.Save();
                Console.WriteLine(request.id + " is created");
                return Ok();
            } catch ( Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }

        [Authorize]
        [HttpPut]
        public ActionResult updateDish([FromBody] CreateDishRequest request)
        {
            try
            {
                var dish = _wrapper.Dish.FindSingle(s => s.id.Equals(request.id));
                if (dish == null) return StatusCode(204);
                else
                {
                    dish.name = request.name != null ? request.name : dish.name;
                    dish.description = request.description != null ? request.description : dish.description;
                    dish.images = request.images != null ? request.images : dish.images;
                    _wrapper.Dish.Update(dish);
                    _wrapper.Save();
                    Console.WriteLine(request.id + " is updated");
                    return Ok();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }
        [Authorize]
        [HttpDelete]
        public ActionResult deleteDish(int id)
        {
            var user = HttpContext.User;
            Console.WriteLine(user.Claims.FirstOrDefault(x => x.Type.Equals("Name")).Value);
            try
            {
                var dish = _wrapper.Dish.FindSingle(s => s.id.Equals(id));
                if (dish == null) return StatusCode(204);
                else
                {
                    _wrapper.Dish.Delete(dish);
                    _wrapper.Save();
                    Console.WriteLine(id + " is deleted");
                    return Ok();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500);
            }
        }
    }
}

