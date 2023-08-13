using Microsoft.EntityFrameworkCore;
using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Repository.Interfaces
{
	public interface ICourseRepository
	{
		void AddCourse(Course course);

		Task DeleteCourseAsync(Course course);
		
		Task<ICollection<Course>> FetchCoursesAsync(string levelId);

		Task<Course> GetCoursesAsync(string courseId);

		Task UpdateCoursesAsync(Course course);


	}
}
