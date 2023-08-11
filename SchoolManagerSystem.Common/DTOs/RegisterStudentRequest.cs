namespace SchoolManagerSystem.Common.DTOs
{
	public class RegisterStudentRequest 
	{
		public  UserRegistrationRequest UserRegistrationRequest { get; set; }
        public string LevelId { get; set; }
	}
}
