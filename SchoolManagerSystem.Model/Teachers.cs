using System;

namespace SchoolManagerSystem.Model
{
	public class Teachers : BaseEntity
	{
		public ApplicationUser User { get; set; }
		public Address Address { get; set; }
	}
}
