using Microsoft.EntityFrameworkCore;
using SchoolManagerSystem.Data;
using SchoolManagerSystem.Model.Entities;
using SchoolManagerSystem.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Repository.Implementation
{
	public class StudentRepository : GenericRepository<Student>, IStudentRepository
	{
		private readonly DbSet<Student> _dbSet;

		public StudentRepository(SMSContext context) : base(context)
		{
			_dbSet = context.Set<Student>();
		}

		public Student CreateStudent(Student student)
		{
			_dbSet.Add(student);
			return student;
		}

		public ICollection<Student> FetchStudents()
		{
			return _dbSet.ToList();
		}

		public async Task<Student> GetStudentAsync(string userId)
		{
			var user = await _dbSet.FirstOrDefaultAsync(x => x.UserId == userId);
			return user;
		}

		public async Task<ICollection<Student>> FetchStudentAsync(string levelId)
		{
			var user = await _dbSet.Where(x => x.LevelId == levelId).ToListAsync();
			return user;
		}


		public async Task DeleteStudentAsync(Student student)
		{
			_dbSet.Remove(student);
		}

		public async Task UpdateStudent(Student student)
		{
			_dbSet.Update(student);
		}
	}
}
