using SchoolManagerSystem.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Repository.Interfaces
{
	public interface IStudentRepository
	{
		Student CreateStudent(Student student);

		ICollection<Student> FetchStudents();

		Task<Student> GetStudentAsync(string userId);

		Task<ICollection<Student>> FetchStudentAsync(string levelId);

		Task UpdateStudent(Student student);

		Task DeleteStudentAsync(Student student);


	}
}