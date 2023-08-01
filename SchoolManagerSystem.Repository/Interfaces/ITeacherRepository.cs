using SchoolManagerSystem.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Repository.Interfaces
{
	public interface ITeacherRepository
	{
		Teacher CreateTeacher(string userId, string addressId);

		ICollection<Teacher> FetchTeachers();

		Task<Teacher> GetTeacherAsync(string userId);

		Task DeleteTeacherAsync(Teacher teacher);


	}
}