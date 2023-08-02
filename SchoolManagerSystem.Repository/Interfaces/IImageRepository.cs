using Microsoft.AspNetCore.Identity;
using SchoolManagerSystem.Model.Entities;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Repository.Interfaces
{
	public interface IImageRepository
	{
		void Update(ApplicationUser user);

		Task<ApplicationUser> FetchAsync(string userId);
	}
}
