using System;
using System.Linq.Expressions;
using DeRestaurant.Models;

namespace DeRestaurant.Repository.IRepository
{
	public interface ICommentRepository : IBaseRepository<Comment>
	{
        IQueryable<Comment> FindAllCommentRelated();
    }
}

