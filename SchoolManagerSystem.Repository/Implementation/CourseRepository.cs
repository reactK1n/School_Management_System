using Microsoft.EntityFrameworkCore;
using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Data;
using SchoolManagerSystem.Model.Entities;
using SchoolManagerSystem.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Repository.Implementation
{
	public class CourseRepository : GenericRepository<Course>, ICourseRepository
	{
		private readonly DbSet<Course> _dbSet;
		public CourseRepository(SMSContext context) : base(context)
		{
			_dbSet = context.Set<Course>();
		}

		public async Task AddCourse(AddCourseRequest request, Level level, List<Student> students)
		{
			var course = new Course
			{
				CourseName = request.CourseName,
				LevelId = request.LevelId,
				Level = level,
				Students = students
			};
			_dbSet.Add(course);
		}

		public async Task DeleteCourseAsync(string id)
		{
			var course = await _dbSet.FirstOrDefaultAsync(cou => cou.Id == id);
			_dbSet.Remove(course);
		}

		public async Task<ICollection<Course>> FetchCoursesAsync(string levelId)
		{
			var courses = await _dbSet.Where(cou => cou.LevelId == levelId).ToListAsync();
			return courses;
		}

		public async Task<ICollection<string>> GetStudentCourses(string studentId)
		{
			var courseNames = await _dbSet
				.Where(course => course.Students.Any(student => student.Id == studentId))
				.Select(course => course.CourseName)
				.ToListAsync();

			return courseNames;
		}

		public async Task UpdateCoursesAsync(string levelId)
		{
			var courses = await _dbSet.Where(cou => cou.LevelId == levelId).ToListAsync();
			foreach (var course in courses)
			{
				_dbSet.Update(course);
			}
		}
	}
}
