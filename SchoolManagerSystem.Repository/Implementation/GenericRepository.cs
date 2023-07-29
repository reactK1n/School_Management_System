using Microsoft.EntityFrameworkCore;
using SchoolManagerSystem.Data;
using SchoolManagerSystem.Repository.Interfaces;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Repository.Implementation
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly DbSet<T> _dbSet;
		public GenericRepository(SMSContext context)
		{
			_dbSet = context.Set<T>();
		}
		public void Delete(T entity)
		{
			_dbSet.Remove(entity);
		}

		public async Task InsertAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
		}

		public void Update(T entity)
		{
			_dbSet.Update(entity);
		}
	}
}
