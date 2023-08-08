using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Files.Interfaces
{
	public interface IImageService
	{
		Task<string> UploadImageAsync(IFormFile image);
	}
}
