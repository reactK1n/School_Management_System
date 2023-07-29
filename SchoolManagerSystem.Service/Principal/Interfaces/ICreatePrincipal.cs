using SchoolManagerSystem.Common.DTOs;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Principal.Interfaces
{
	public interface ICreatePrincipal
	{
		Task<string> CreatePrincipalAsync(UserRegistrationRequest request);
	}
}
