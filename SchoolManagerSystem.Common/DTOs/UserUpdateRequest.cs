using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Common.DTOs
{
	public class UserUpdateRequest
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string UserName { get; set; }

		public string Email { get; set; }

		public string ProfilePics { get; set; }

		public string State { get; set; }

		public string City { get; set; }
	}
}
