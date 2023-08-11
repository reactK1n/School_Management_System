using System.ComponentModel.DataAnnotations;

namespace SchoolManagerSystem.Common.DTOs
{
	public class RegisterStudentRequest 
	{
		[Required]
		public  UserRegistrationRequest UserRegistrationRequest { get; set; }
		
		[Required]
		public string LevelId { get; set; }
	}
}
