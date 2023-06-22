using System;
using System.Linq.Expressions;

namespace DeRestaurant.Repository.IRepository
{
	public interface IBaseRepository<T>
	{
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T FindSingle(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}

