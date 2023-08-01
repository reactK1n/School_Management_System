using SchoolManagerSystem.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Users.Interfaces
{
	public interface IStudentServices
	{
		Task<string> CreateUserAsync(UserRegistrationRequest request);

		Task<ICollection<UserResponse>> GetUsers();

		Task<UserResponse> GetUserAsync(string userId);

		Task<string> UpdateUserAsync(string userId, UserUpdateRequest request);

		Task<string> DeleteUserAsync(string userId);
	}
}
