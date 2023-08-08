using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Common.Enums;
using SchoolManagerSystem.Model.Entities;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Authentications.Interfaces
{
	public interface IAuthServices
	{
		Task<UserResponse> Register(ApplicationUser user, string password, UserRole role);

		Task<LoginResponse> Login(LoginRequest loginRequest);
	}
}
