using System.Linq.Expressions;

namespace AzureExample.API.Repositories
{
	public interface IRepository<T> where T : class
	{
		Task<T> GetByIdAsync(int id);
		Task<T> GetByGuidIdAsync(Guid id);
		Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression, string[] includes = null, params Expression<Func<T, object>>[] includeExpressions);
		Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> expression, string[] includes = null);
		Task<IEnumerable<T>> GetAllAsync(int? pageNumber = null, int? pageSize = null);
		IQueryable<T> GetList(Expression<Func<T, bool>> expression, string[] includes = null, bool asNoTracking = true, params Expression<Func<T, object>>[] includeExpressions);
		Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
		Task AddAsync(T entity);
		Task AddRangeAsync(IEnumerable<T> entities);
		void Update(T entity);
		void Remove(T entity);
		void RemoveRange(IEnumerable<T> entities);
	}
}
