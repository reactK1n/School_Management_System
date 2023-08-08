using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagerSystem.Model.Entities
{
	public class Student : BaseEntity
	{
		[ForeignKey("User")]
		public string UserId { get; set; }

		public string AddressId { get; set; }

		public string LevelId { get; set; }

		//navigation properties
		public ApplicationUser User { get; set; }

		public Level Level { get; set; }

		public Address Address { get; set; }

		public ICollection<Course> Courses { get; set; }

	}
}
