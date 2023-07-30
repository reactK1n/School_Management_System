using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Image.Interfaces
{
	public interface IImageService
	{
		Task<string> UploadImage(IFormFile image);
	}
}
