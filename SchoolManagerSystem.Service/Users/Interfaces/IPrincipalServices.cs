using SchoolManagerSystem.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Users.Interfaces
{
	public interface IPrincipalServices
	{
		Task<UserResponse> CreateUserAsync(UserRegistrationRequest request);

		Task<ICollection<UserResponse>> GetUsers();

		Task<UserResponse> GetUserAsync(string userId);

		Task<string> UpdateUserAsync(UserUpdateRequest request);

		Task<string> DeleteUserAsync(string userId);
	}
}
