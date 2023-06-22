using System;
using DeRestaurant.Repository.IRepository;

namespace DeRestaurant.Repository.IRepository
{
	public interface IRepositoryWrapper
	{
		IDishRepository Dish { get; }
		ICommentRepository Comment { get; }
		IBillRepository Bill { get; }
		void Save();
	}
}

