using SchoolManagerSystem.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Courses.Interfaces
{
	public interface ICourseServices
	{
		Task<CourseResponse> AddCourse(CourseRequest request);

		Task DeleteCourseAsync(string courseId);

		Task<ICollection<CourseResponse>> FetchCoursesAsync(string levelId);

		Task<ICollection<CourseResponse>> GetStudentCourseAsync(string studentId);

		Task UpdateCourseAsync(CourseUpdateRequest request, string courseId);
	}
}
