using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagerSystem.Model.Entities;

namespace SchoolManagerSystem.Data
{
    public class SMSContext : IdentityDbContext<ApplicationUser>
	{
		public SMSContext(DbContextOptions<SMSContext> option) : base(option) { }

		public DbSet<Address> Addresses { get; set; }
		public DbSet<Principal> Principals { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Level> Levels { get; set; }
		public DbSet<StudentCourse> StudentCourses { get; set; }
	}
}
