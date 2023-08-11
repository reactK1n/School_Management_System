using SchoolManagerSystem.Common.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Courses.Interfaces
{
	public interface ICourseServices
	{
		Task<CourseResponse> AddCourse(CourseRequest request);

		Task<string> DeleteCourseAsync(string courseId);

		Task<ICollection<CourseResponse>> FetchCoursesAsync(string levelId);

		Task<ICollection<CourseResponse>> GetStudentCourseAsync(string studentId);

		Task<string> UpdateCourseAsync(CourseUpdateRequest request, string courseId);
	}
}
