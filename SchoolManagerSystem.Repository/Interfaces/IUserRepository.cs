using SchoolManagerSystem.Model.Entities;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Repository.Interfaces
{
	public interface IUserRepository
	{
		Task UpdateAsync(ApplicationUser user);

		Task<ApplicationUser> FetchAsync(string userId);
	}
}
