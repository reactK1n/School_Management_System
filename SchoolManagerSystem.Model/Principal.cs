using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagerSystem.Model
{
	public class Principal : BaseEntity
	{

		public ApplicationUser User { get; set; }
		public Address Address { get; set; }
	}
}
