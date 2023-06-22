using System;
using System.Linq.Expressions;
using DeRestaurant.Models;
using Microsoft.EntityFrameworkCore;
using DeRestaurant.Repository.IRepository;

namespace DeRestaurant.Repository
{
	public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected DBContext RepositoryContext { get; set; }

        public BaseRepository(DBContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll() => RepositoryContext.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            RepositoryContext.Set<T>().Where(expression).AsNoTracking();

        public T FindSingle(Expression<Func<T, bool>> expression)
        {
            var t = RepositoryContext.Set<T>().Where(expression);
            if (t.Count() == 0) return null;
            return t.First();
        }



        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);
        public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);
        public void Delete(T entity) => RepositoryContext.Set<T>().Remove(entity);

      
    }
}

