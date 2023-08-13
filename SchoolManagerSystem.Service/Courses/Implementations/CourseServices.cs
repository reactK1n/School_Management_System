using SchoolManagerSystem.Common;
using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Model.Entities;
using SchoolManagerSystem.Repository.UnitOfWork.Interfaces;
using SchoolManagerSystem.Service.Courses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
			if (!Helper.IsCourseNameValid(request.CourseName))
			{
				throw new ArgumentException("Course Name Is Invalid");
			}

			var level = await _unit.Level.FetchLevelAsync(request.LevelId);
			if (level == null)
			{
				throw new ArgumentNullException($"Invalid LevelId {request.LevelId}");
			}

			var course = new Course
			{
				CourseName = request.CourseName,
				LevelId = request.LevelId,
			};

			_unit.Course.AddCourse(course);
			await _unit.SaveChangesAsync();

			var response = new CourseResponse
			{
				Id = course.Id,
				CourseName = course.CourseName,
				LevelName = level.LevelName
				
			};

			return response;
		}

		public async Task DeleteCourseAsync(string courseId)
		{
			var course = await _unit.Course.GetCoursesAsync(courseId);
			if (course == null)
			{
				throw new ArgumentNullException($"User with {courseId} Not Found ");
			};

			await _unit.Course.DeleteCourseAsync(course);
			await _unit.SaveChangesAsync();
		}

		public async Task<ICollection<CourseResponse>> FetchCoursesAsync(string levelId)
		{
			var courses = await _unit.Course.FetchCoursesAsync(levelId);
			if (!courses.Any())
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
					LevelName = level.LevelName
				});

			}
			return response;
		}

		public async Task<ICollection<CourseResponse>> GetStudentCourseAsync(string studentId)
		{
			var student = _unit.Student.FetchStudents().FirstOrDefault(st => st.Id == studentId);
			if (student == null)
			{
				throw new ArgumentNullException("Invalid StudentID");
			}
			var courses = await _unit.Course.FetchCoursesAsync(student.LevelId);

			if (!courses.Any())
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
					CourseName = course.CourseName
				});

			}
			return response;
		}

		public async Task UpdateCourseAsync(CourseUpdateRequest request, string courseId)
		{
			if (!Helper.IsCourseNameValid(request.CourseName))
			{
				throw new ArgumentException("Course Name Is Invalid");
			}

			var course = await _unit.Course.GetCoursesAsync(courseId);
			if (course == null)
			{
				throw new ArgumentNullException("Course Not Found");
			}

			//assigning value
			course.CourseName = !string.IsNullOrEmpty(request.CourseName)
				? request.CourseName
				: course.CourseName;

			//updating entites
			await _unit.Course.UpdateCoursesAsync(course);
			//saving changes
			await _unit.SaveChangesAsync();
		}
	}
}
