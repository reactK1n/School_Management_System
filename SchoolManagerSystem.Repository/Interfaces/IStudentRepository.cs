using SchoolManagerSystem.Model.Entities;

namespace SchoolManagerSystem.Repository.Interfaces
{
	public interface IStudentRepository
	{
		Student CreateStudent(string userId, string addressId);
	}
}