using Microsoft.EntityFrameworkCore;
using SchoolManagerSystem.Data;
using SchoolManagerSystem.Model.Entities;
using SchoolManagerSystem.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Repository.Implementation
{
	public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
	{
		private readonly DbSet<Teacher> _dbSet;

		public TeacherRepository(SMSContext context) : base(context)
		{
			_dbSet = context.Set<Teacher>();
		}

		public Teacher CreateTeacher(string userId, string addressId)
		{
			var teacher = new Teacher
			{
				UserId = userId,
				AddressId = addressId
			};

			_dbSet.Add(teacher);
			return teacher;
		}

		public ICollection<Teacher> FetchTeachers()
		{
			return _dbSet.ToList();
		}

		public async Task<Teacher> GetTeacherAsync(string userId)
		{
			var user = await _dbSet.FirstOrDefaultAsync(x => x.UserId == userId);
			return user;
		}

		public async Task DeleteTeacherAsync(Teacher teacher)
		{
			_dbSet.Remove(teacher);
		}

		public async Task UpdateTeacher(Teacher teacher)
		{
			_dbSet.Update(teacher);
		}
	}
}
