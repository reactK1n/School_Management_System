using Microsoft.AspNetCore.Identity;
using System;

namespace SchoolManagerSystem.Model.Entities
{
	public class ApplicationUser : IdentityUser
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string ProfilePics { get; set; }

		public DateTime CreatedOn { get; set; }

		public DateTime? UpdatedOn { get; set; }
	}
}
