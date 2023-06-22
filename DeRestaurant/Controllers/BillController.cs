using System;
using DeRestaurant.Repository;
using Microsoft.AspNetCore.Mvc;
using DeRestaurant.Models.DTO;
using DeRestaurant.Repository.IRepository;
using System.Text.Json;
using System.Text.Json.Serialization; 
namespace DeRestaurant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillController : ControllerBase
	{
        private IRepositoryWrapper _wrapper;

        public BillController(IRepositoryWrapper wrapper)
        {
            _wrapper = wrapper;
        }

        [HttpGet]
        public ActionResult<BillDto> getBill(int id)
        {
            var bill = _wrapper.Bill.FindSingle(x => x.id.Equals(id));
            if (bill == null)  return StatusCode(204);
            else
            {
                 return Ok(new BillDto(bill));
            }
        }
       
	}
}

