using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolManagerSystem.Model.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

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

		public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			foreach (var item in ChangeTracker.Entries<BaseEntity>())
			{
				switch (item.State)
				{
					case EntityState.Modified:
						item.Entity.UpdatedOn = DateTime.UtcNow;
						break;
					case EntityState.Added:
						item.Entity.Id = item.Entity.Id ?? Guid.NewGuid().ToString();
						item.Entity.CreatedOn = DateTime.UtcNow;
						break;
					default:
						break;
				}
			}
			return await base.SaveChangesAsync(cancellationToken);
		}
	}
}
