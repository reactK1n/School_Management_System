using SchoolManagerSystem.Common.DTOs;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Authentications.Interfaces
{
	public interface ILoginService
	{
		Task<LoginResponse> Login(LoginRequest loginRequest);
	}
}
