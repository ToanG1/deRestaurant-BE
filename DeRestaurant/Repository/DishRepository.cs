using System;
using DeRestaurant.Models;
using DeRestaurant.Repository.IRepository;

namespace DeRestaurant.Repository
{
	public class DishRepository : BaseRepository<Dish>, IDishRepository
	{
		public DishRepository(DBContext dBContext) : base(dBContext)
		{
		}
	}
}

