using SchoolManagerSystem.Common.DTOs;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Users.Interfaces
{
	public interface ICreateUser
	{
		Task<string> CreatePrincipalAsync(UserRegistrationRequest request);

		Task<string> CreateStudentAsync(UserRegistrationRequest request);

		Task<string> CreateTeacherAsync(UserRegistrationRequest request);


	}
}
