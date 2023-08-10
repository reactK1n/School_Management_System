using Microsoft.EntityFrameworkCore;
using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Repository.Interfaces
{
	public interface ICourseRepository
	{
		Task AddCourse(AddCourseRequest request, Level level, List<Student> students);
		
		Task DeleteCourseAsync(string id);
		
		Task<ICollection<Course>> FetchCoursesAsync(string levelId);

		Task<ICollection<string>> GetStudentCourses(string studentId);

		Task UpdateCoursesAsync(string levelId);


	}
}
