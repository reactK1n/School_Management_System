using System.ComponentModel.DataAnnotations;

namespace SchoolManagerSystem.Common.DTOs
{
	public class UserRegistrationRequest
	{
		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

        public string UserName { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }

		[Required]
		public string State { get; set; }

		[Required]
		public string City { get; set; }
    }
}
