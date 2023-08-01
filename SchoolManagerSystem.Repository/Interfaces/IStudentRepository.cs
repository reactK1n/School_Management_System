using SchoolManagerSystem.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Repository.Interfaces
{
	public interface IStudentRepository
	{
		Student CreateStudent(string userId, string addressId);

		ICollection<Student> FetchStudents();

		Task<Student> GetStudentAsync(string userId);

		Task DeleteStudentAsync(Student student);


	}
}