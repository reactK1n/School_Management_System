using Microsoft.EntityFrameworkCore;
using SchoolManagerSystem.Data;
using SchoolManagerSystem.Model.Entities;
using SchoolManagerSystem.Repository.Interfaces;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Repository.Implementation
{
	public class LevelRepository: GenericRepository<Level>, ILevelRepository
	{
		private readonly DbSet<Level> _dbSet;
		public LevelRepository(SMSContext context) : base(context)
		{
			_dbSet = context.Set<Level>();
		}

		public async Task<Level> FetchLevelAsync(string levelId)
		{
			var level = await _dbSet.FirstOrDefaultAsync(lev => lev.Id == levelId);
			return level;
		}

	}
}
