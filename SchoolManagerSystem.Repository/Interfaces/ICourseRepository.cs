using Microsoft.EntityFrameworkCore;
using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Repository.Interfaces
{
	public interface ICourseRepository
	{
		Task<Course> AddCourse(CourseRequest request,  ICollection<Student> students);
		
		Task DeleteCourseAsync(Course course);
		
		Task<ICollection<Course>> FetchCoursesAsync(string levelId);

		Task<Course> GetCoursesAsync(string courseId);

		Task UpdateCoursesAsync(Course course);


	}
}
