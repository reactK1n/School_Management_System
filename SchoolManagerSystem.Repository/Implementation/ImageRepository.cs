using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolManagerSystem.Data;
using SchoolManagerSystem.Model.Entities;
using SchoolManagerSystem.Repository.Interfaces;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Repository.Implementation
{
	public class ImageRepository : IImageRepository
	{

		private readonly DbSet<ApplicationUser> _dbSet;

		public ImageRepository(SMSContext context) 
		{
			_dbSet = context.Set<ApplicationUser>();
		}

		public async Task<ApplicationUser> FetchAsync(string userId)
		{
			var user = await _dbSet.FindAsync(userId);
			return user;
		}

		public void Update(ApplicationUser user)
		{
			_dbSet.Update(user);
		}
	}
}
