using System.ComponentModel.DataAnnotations;

namespace SchoolManagerSystem.Common.DTOs
{
	public class CourseUpdateRequest
	{
		[Required]
		public string CourseName { get; set; }
	}
}
