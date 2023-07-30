using Microsoft.EntityFrameworkCore;
using SchoolManagerSystem.Data;
using SchoolManagerSystem.Model.Entities;
using SchoolManagerSystem.Repository.Interfaces;

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
    }
}
