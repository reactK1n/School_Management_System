using System.Threading.Tasks;

namespace SchoolManagerSystem.Repository.Interfaces
{
	public interface IGenericRepository<T> where T : class
	{
		Task InsertAsync(T entity);
		void Update(T entity);
		void Delete(T entity);
	}
}
