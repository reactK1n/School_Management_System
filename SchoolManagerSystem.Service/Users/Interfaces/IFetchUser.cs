using SchoolManagerSystem.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Users.Interfaces
{
	public interface IFetchUser
	{
		Task<ICollection<UserResponse>> GetAllUsers();

		Task<ICollection<UserResponse>> GetAllTeachers();

		Task<ICollection<UserResponse>> GetAllPrincipals();

		Task<ICollection<UserResponse>> GetAllStudents();

		Task<UserResponse> GetUserAsync(string userId);


	}
}
