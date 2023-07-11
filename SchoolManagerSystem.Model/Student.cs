using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Model
{
	public class Student : BaseEntity
	{
		public ApplicationUser User { get; set; }
		public Address Address { get; set; }
		public Level Level { get; set; }
    }
}
