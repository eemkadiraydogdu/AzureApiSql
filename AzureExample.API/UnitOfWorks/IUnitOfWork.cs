using AzureExample.API.Repositories;

namespace AzureExample.API.UnitOfWorks
{
	public interface IUnitOfWork
	{
		Task CommitAsync();
		void Commit();
		IRepository<T> Repository<T>() where T : class;
	}
}
