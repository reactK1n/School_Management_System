using SchoolManagerSystem.Common.DTOs;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.CreateUser.Interfaces
{
	public interface ICreatePrincipal
	{
		Task<string> CreatePrincipalAsync(UserRegistrationRequest request);
	}
}
