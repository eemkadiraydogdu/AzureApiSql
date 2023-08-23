using AzureExample.API.DB;
using AzureExample.API.Repositories;

namespace AzureExample.API.UnitOfWorks
{
	public class UnitOfWork :IUnitOfWork
	{
		private readonly AzureDbContext _context;
		public UnitOfWork(AzureDbContext context)
		{
			_context = context;
		}
		public void Commit()
		{
			_context.SaveChanges();
		}

		public async Task CommitAsync()
		{
			await _context.SaveChangesAsync();
		}

		public IRepository<T> Repository<T>() where T : class
		{
			return new Repository<T>(_context);
		}
	}
}
