using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Model
{
	public class Level : BaseEntity
	{
		public string LevelName { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Course> Courses { get; set; }

	}
}
