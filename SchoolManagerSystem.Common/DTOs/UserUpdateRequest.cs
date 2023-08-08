using Microsoft.AspNetCore.Http;

namespace SchoolManagerSystem.Common.DTOs
{
	public class UserUpdateRequest
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string UserName { get; set; }

		public string Email { get; set; }

		public string State { get; set; }

		public string City { get; set; }

		public IFormFile Image { get; set; }

	}
}
