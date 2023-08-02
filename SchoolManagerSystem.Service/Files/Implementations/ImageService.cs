using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SchoolManagerSystem.Common.Model;
using SchoolManagerSystem.Repository.UnitOfWork.Interfaces;
using SchoolManagerSystem.Service.Files.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Files.Implementations
{
	public class ImageService : IImageService
	{
		private readonly IConfiguration _config;
		private readonly IUnitOfWork _unit;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly Cloudinary _cloudinary;
		private readonly ImageSettings _imageSettings;

		public ImageService(IConfiguration config, IUnitOfWork unit, IHttpContextAccessor httpContextAccessor)
		{
			_config = config;
			_unit = unit;
			_httpContextAccessor = httpContextAccessor;
			_imageSettings = config.GetSection("CloudinarySettings").Get<ImageSettings>();
			_cloudinary = new Cloudinary(new Account(
				_imageSettings.CloudName,
				_imageSettings.ApiKey,
				_imageSettings.ApiSecret));
		}
		public async Task<string> UploadImageAsync(IFormFile image)
		{
			var imageExtension = _config.GetSection("PhotoSettings:Formats").Get<List<string>>();
			var userId = _httpContextAccessor.HttpContext.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;
			var user = await _unit.Image.FetchAsync(userId);
			var fileFormat = false;
			foreach (var item in imageExtension)
			{
				if (image.FileName.EndsWith(item))
				{
					fileFormat = true;
					break;
				}
			}

			if (!fileFormat)
			{
				throw new NotSupportedException("file format not supported");

			}

			var uploadResult = new ImageUploadResult();
			using (var imageStream = image.OpenReadStream())
			{
				string fileName = $"{Guid.NewGuid()}{image.FileName}";
				uploadResult = await _cloudinary.UploadAsync(new ImageUploadParams
				{
					File = new FileDescription(fileName, imageStream),
					Transformation = new Transformation().Radius("max").Chain().Crop("scale").Width("200").Height("200")
				});
			}
			user.ProfilePics = uploadResult.Uri.ToString();
			_unit.Image.Update(user);
			var picsUri = user.ProfilePics;

			return picsUri;
		}
	}
}
