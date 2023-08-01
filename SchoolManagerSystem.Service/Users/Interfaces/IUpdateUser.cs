using SchoolManagerSystem.Common.DTOs;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Users.Interfaces
{
	public interface IUpdateUser
	{
		Task<string> UpdateUserAsync(string userId, UserUpdateRequest request);
	}
}
