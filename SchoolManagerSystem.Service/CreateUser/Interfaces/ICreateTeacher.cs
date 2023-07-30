using SchoolManagerSystem.Common.DTOs;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.CreateUser.Interfaces
{
	public interface ICreateTeacher
	{
		Task<string> CreateTeacherAsync(UserRegistrationRequest request);
	}
}
