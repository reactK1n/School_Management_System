using System.ComponentModel.DataAnnotations;

namespace SchoolManagerSystem.Common.DTOs
{
	public class CourseRequest
	{
		[Required]
		public string CourseName { get; set; }

		[Required]
		public string LevelId { get; set; }
	}
}
