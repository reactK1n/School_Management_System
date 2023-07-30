using SchoolManagerSystem.Common.DTOs;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.CreateUser.Interfaces
{
	public interface ICreateStudent
	{
		Task<string> CreateStudentAsync(UserRegistrationRequest request);
	}
}
