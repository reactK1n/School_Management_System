using SchoolManagerSystem.Common.DTOs;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Authentications.Interfaces
{
	public interface IRegisterService
	{
		Task<UserRegistrationResponse> Register(UserRegistrationRequest registerRequest, string isRole);
	}
}
