using SchoolManagerSystem.Common.DTOs;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Authentications.Interfaces
{
	public interface IAuthServices
	{
		Task<UserRegistrationResponse> Register(UserRegistrationRequest registerRequest);

		Task<LoginResponse> Login(LoginRequest loginRequest);
	}
}
