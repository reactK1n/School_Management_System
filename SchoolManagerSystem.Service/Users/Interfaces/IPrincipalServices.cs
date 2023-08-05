using Microsoft.AspNetCore.Http;
using SchoolManagerSystem.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Users.Interfaces
{
	public interface IPrincipalServices
	{
		Task<string> CreateUserAsync(UserRegistrationRequest request);

		Task<ICollection<UserResponse>> GetUsers();

		Task<UserResponse> GetUserAsync(string userId);

		Task<string> UpdateUserAsync(UserUpdateRequest request, IFormFile image);

		Task<string> DeleteUserAsync(string userId);

	}
}
