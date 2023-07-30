﻿using Microsoft.EntityFrameworkCore;
using SchoolManagerSystem.Data;
using SchoolManagerSystem.Model.Entities;
using SchoolManagerSystem.Repository.Interfaces;

namespace SchoolManagerSystem.Repository.Implementation
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
	{
        private readonly DbSet<Student> _dbSet;

        public StudentRepository(SMSContext context) : base(context)
        {
            _dbSet = context.Set<Student>();
        }

        public Student CreateStudent(string userId, string addressId)
        {
            var student = new Student
			{
                UserId = userId,
                AddressId = addressId
            };

            _dbSet.Add(student);
            return student;
        }
    }
}
