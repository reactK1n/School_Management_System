using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Repository.UnitOfWork.Interfaces;
using SchoolManagerSystem.Service.Courses.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Courses.Implementations
{
	public class CourseServices : ICourseServices
	{
		private readonly IUnitOfWork _unit;

		public CourseServices(IUnitOfWork unit)
		{
			_unit = unit;
		}

		public async Task<CourseResponse> AddCourse(CourseRequest request)
		{
			var students = await _unit.Student.FetchStudentAsync(request.LevelId);
			if (students == null)
			{
				throw new ArgumentNullException($"invalid levelId {request.LevelId} ");
			}

			var course = await _unit.Course.AddCourse(request, students);
			await _unit.SaveChangesAsync();
			var level = await _unit.Level.FetchLevelAsync(course.LevelId);
			var response = (new CourseResponse
			{
				Id = course.Id,
				CourseName = course.CourseName,
				LevelName = level.LevelName//we arrange it later
			};

			return response;
		}

		public async Task<string> DeleteCourseAsync(string courseId)
		{
			var course = await _unit.Course.GetCoursesAsync(courseId);
			if (course == null)
			{
				throw new ArgumentNullException($"User with {courseId} Not Found ");
			};

			var result = _unit.Course.DeleteCourseAsync(course);
			await _unit.SaveChangesAsync();
			if (!result.IsCompleted)
			{
				throw new MissingFieldException($"{result.Exception}");
			}

			return "User Removed Successfully";
		}

		public async Task<ICollection<CourseResponse>> FetchCoursesAsync(string levelId)
		{
			var courses = await _unit.Course.FetchCoursesAsync(levelId);
			if (courses == null)
			{
				throw new ArgumentNullException($"No Course Found ");
			};

			var response = new List<CourseResponse>();

			foreach (var course in courses)
			{
				var level = await _unit.Level.FetchLevelAsync(course.LevelId);
				response.Add(new CourseResponse
				{
					Id = course.Id,
					CourseName = course.CourseName,
					LevelName = level.LevelName //we arrange it later
				});

			}
			return response;
		}

		public async Task<ICollection<CourseResponse>> GetStudentCourseAsync(string studentId)
		{
			var courses = await _unit.Course.GetStudentCoursesAsync(studentId);
			if (courses == null)
			{
				throw new ArgumentNullException($"No Course Found ");
			};

			var response = new List<CourseResponse>();

			foreach (var course in courses)
			{
				var level = await _unit.Level.FetchLevelAsync(course.LevelId);
				response.Add(new CourseResponse
				{
					Id = course.Id,
					CourseName = course.CourseName,
					LevelName = level.LevelName//we arrange it later
				});

			}
			return response;
		}

		public async Task<string> UpdateCourseAsync(CourseRequest request)
		{
			var course = await _unit.Course.GetCoursesAsync(request.LevelId);
			if (course == null)
			{
				throw new ArgumentNullException("Course Not Found");
			}

			//assigning value
			course.CourseName = !string.IsNullOrEmpty(request.CourseName)
				? request.CourseName
				: course.CourseName;

			//updating entites
			var result = _unit.Course.UpdateCoursesAsync(course);
			await _unit.SaveChangesAsync();
			//saving changes

			if (!result.IsCompleted)
			{
				throw new MissingFieldException($"{result.Exception}");
			}

			return "Course Updated Successfully";
		}
	}
}
