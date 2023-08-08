using System.Collections.Generic;

namespace SchoolManagerSystem.Model.Entities
{
	public class Course : BaseEntity
	{
		public string CourseName { get; set; }

		public string LevelId { get; set; }

		//navigation properties
		public Level Level { get; set; }

		public ICollection<Student> Students { get; set; }

	}
}
