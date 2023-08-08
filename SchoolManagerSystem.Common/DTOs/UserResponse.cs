using System.ComponentModel.DataAnnotations;

namespace SchoolManagerSystem.Common.DTOs
{
	public class UserResponse
	{
		public string Id { get; set; }	

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		public string UserName { get; set; }

		public string Email { get; set; }
	}
}
