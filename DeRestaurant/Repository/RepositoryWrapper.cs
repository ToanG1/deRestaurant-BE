using System;
using DeRestaurant.Models;
using DeRestaurant.Repository.IRepository;

namespace DeRestaurant.Repository
{
	public class RepositoryWrapper : IRepositoryWrapper
	{
		private DBContext _repoContext;
		private IDishRepository _dish;
		private ICommentRepository _comment;
		private IBillRepository _bill;
		public IDishRepository Dish
		{
			get
			{
				if (_dish == null)
				{
					_dish = new DishRepository(_repoContext);
				}
				return _dish;
			}
		}
		public ICommentRepository Comment
		{
			get
			{
				if (_comment == null)
				{
					_comment = new CommentRepository(_repoContext);
				}
				return _comment;
			}
		}
		public IBillRepository Bill
		{
			get
			{
				if(_bill == null)
				{
					_bill = new BillRepository(_repoContext);
				}
				return _bill;
			}
		}
		public RepositoryWrapper(DBContext dBContext)
		{
			_repoContext = dBContext;
		}
		public void Save()
		{
			_repoContext.SaveChanges();
		}
	}
}

