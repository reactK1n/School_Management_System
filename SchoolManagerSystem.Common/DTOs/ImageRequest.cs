using Microsoft.AspNetCore.Http;

namespace SchoolManagerSystem.Common.DTOs
{
	public class ImageRequest
	{
		public IFormFile Image { get; set; }
	}
}
