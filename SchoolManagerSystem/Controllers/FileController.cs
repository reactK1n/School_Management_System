using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Service.Image.Interfaces;
using System;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Controllers
{
	[ApiController]
	[Route("api/user/[Controller]")]
	[Authorize]
	public class FileController : ControllerBase
	{
		private readonly IImageService _imageService;

		public FileController(IImageService imageService)
		{
			_imageService = imageService;
		}


		[HttpPatch]
		[Route("image")]
		public async Task<IActionResult> UploadImage([FromForm] ImageRequest image)
		{
			try
			{
				var uploadResult = await _imageService.UploadImage(image.Image);
				if (uploadResult != null)
				{
					return NoContent();
				}
				return BadRequest("image upload failed");
			}
			catch (NotSupportedException ex)
			{
				return BadRequest(ex.Message);
			}
			catch
			{
				return BadRequest("image upload failed");
			}
		}

	}
}
