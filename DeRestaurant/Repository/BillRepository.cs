using System;
using DeRestaurant.Models.Entitices;
using DeRestaurant.Models;
using DeRestaurant.Repository.IRepository;
namespace DeRestaurant.Repository
{
	public class BillRepository : BaseRepository<Bill>, IBillRepository
	{
		public BillRepository(DBContext dBContext) : base(dBContext)
		{
		}
	}
}

