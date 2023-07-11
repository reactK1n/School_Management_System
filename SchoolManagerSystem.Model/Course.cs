using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Model
{
	public class Course : BaseEntity
	{

		public string CourseName { get; set; }

		public Student Student { get; set; }

		public Level Level { get; set; }

	}
}
