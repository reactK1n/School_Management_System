using System.ComponentModel.DataAnnotations;

namespace SchoolManagerSystem.Common.DTOs
{
	public class AddCourseRequest
	{
		[Required]
		public string CourseName { get; set; }

		[Required]
		public string LevelId { get; set; }
	}
}
