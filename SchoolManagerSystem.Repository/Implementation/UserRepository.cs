using Microsoft.EntityFrameworkCore;
using SchoolManagerSystem.Data;
using SchoolManagerSystem.Model.Entities;
using SchoolManagerSystem.Repository.Interfaces;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Repository.Implementation
{
	public class UserRepository : IUserRepository
	{

		private readonly DbSet<ApplicationUser> _dbSet;

		public UserRepository(SMSContext context)
		{
			_dbSet = context.Set<ApplicationUser>();
		}

		public async Task<ApplicationUser> FetchAsync(string userId)
		{
			var user = await _dbSet.FindAsync(userId);
			return user;
		}

		public async Task UpdateAsync(ApplicationUser user)
		{
			_dbSet.Update(user);
		}
	}
}
