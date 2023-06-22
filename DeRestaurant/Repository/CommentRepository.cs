using System;
using System.Linq.Expressions;
using DeRestaurant.Models;
using DeRestaurant.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DeRestaurant.Repository
{
	public class CommentRepository : BaseRepository<Comment>, ICommentRepository
	{
        protected DBContext RepositoryContext;

        public CommentRepository(DBContext dBContext) : base(dBContext)
		{
            RepositoryContext = dBContext;
        }

        public IQueryable<Comment> FindAllCommentRelated() => RepositoryContext.Set<Comment>()
            .Include(x => x.bill)
            .Include(x => x.dishes)
            .AsNoTracking();
    }
}

