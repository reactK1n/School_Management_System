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

		public void AddCourse(Course course)
		{
			_dbSet.Add(course);
		}

		public async Task DeleteCourseAsync(Course course)
		{
			_dbSet.Remove(course);
		}

		public async Task<ICollection<Course>> FetchCoursesAsync(string levelId)
		{
			var courses = await _dbSet.Where(cou => cou.LevelId == levelId).ToListAsync();
			return courses;
		}

		public async Task<Course> GetCoursesAsync(string courseId)
		{
			var course = await _dbSet.FirstOrDefaultAsync(cou => cou.Id == courseId);
			return course;
		}

		public async Task UpdateCoursesAsync(Course course)
		{
			_dbSet.Update(course);
		}
	}
}
