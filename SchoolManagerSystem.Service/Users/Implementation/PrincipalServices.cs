using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Common.Enums;
using SchoolManagerSystem.Model.Entities;
using SchoolManagerSystem.Repository.UnitOfWork.Interfaces;
using SchoolManagerSystem.Service.Authentications.Interfaces;
using SchoolManagerSystem.Service.Files.Interfaces;
using SchoolManagerSystem.Service.Users.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Users.Implementation
{
	public class PrincipalServices : IPrincipalServices
	{
		private readonly IUnitOfWork _unit;
		private readonly IAuthServices _auth;
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IImageService _image;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public PrincipalServices(IUnitOfWork unit, IAuthServices auth, UserManager<ApplicationUser> userManager, IImageService image, IHttpContextAccessor httpContextAccessor)
		{
			_unit = unit;
			_auth = auth;
			_userManager = userManager;
			_image = image;
			_httpContextAccessor = httpContextAccessor;
		}

		public async Task<UserResponse> CreateUserAsync(UserRegistrationRequest request)
		{
			var user = new ApplicationUser
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				Email = request.Email,
				UserName = request.UserName,
				EmailConfirmed = true
			};

			var createUser = await _auth.Register(user, request.Password, UserRole.Principal);
			var createAddress = _unit.Address.CreateAddress(request);
			_unit.Principal.CreatePrincipal(createUser.Id, createAddress.Id);
			await _unit.SaveChangesAsync();

			var response = new UserResponse
			{
				Id = user.Id,
				FirstName = request.FirstName,
				LastName = request.LastName,
				UserName = request.UserName,
				Email = request.Email
			};

			return response;
		}

		public async Task<ICollection<UserResponse>> GetUsers()
		{
			var users = _unit.Principal.FetchPrincipals();
			if (users == null)
			{
				throw new ArgumentNullException("No User Found");
			};

			var response = new List<UserResponse>(); 
			foreach (var user in users)
			{
				var appUser = await _userManager.FindByIdAsync(user.UserId);
				response.Add(new UserResponse
				{
					Id = appUser.Id,
					FirstName = appUser.FirstName,
					LastName = appUser.LastName,
					UserName = appUser.UserName,
					Email = appUser.Email
				});
			}

			return response;
		}

		public async Task<UserResponse> GetUserAsync(string userId)
		{
			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
			{
				throw new ArgumentNullException($"User with {userId} Not Found ");
			};

			var response = new UserResponse
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				UserName = user.UserName,
				Email = user.Email
			};

			return response;
		}

		public async Task<string> UpdateUserAsync(UserUpdateRequest request)
		{
			var userId = _httpContextAccessor.HttpContext.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
				throw new ArgumentNullException("User not found");
            }
			var principal = await _unit.Principal.GetPrincipalAsync(user.Id);
			var address = await _unit.Address.FetchAddressAsync(principal.AddressId);

			//assigning values
			user.FirstName = !string.IsNullOrEmpty(request.FirstName) ? request.FirstName : user.FirstName;
			user.LastName = !string.IsNullOrEmpty(request.LastName) ? request.LastName : user.LastName;
			user.Email = !string.IsNullOrEmpty(request.Email) ? request.Email : user.Email;
			user.UserName = !string.IsNullOrEmpty(request.UserName) ? request.UserName : user.UserName;
			user.ProfilePics = request.Image != null ? await _image.UploadImageAsync(request.Image) : user.ProfilePics;
			address.State = !string.IsNullOrEmpty(request.State) ? request.State : address.State;
			address.City = !string.IsNullOrEmpty(request.City) ? request.City : address.City;

			//updating entites
			await _unit.Principal.UpdatePrincipal(principal);
			var updatingAddressResult = _unit.Address.UpdateAddressAsync(address);
			var result = await _userManager.UpdateAsync(user);

			//saving changes
			await _unit.SaveChangesAsync();

			if (!result.Succeeded || !updatingAddressResult.IsCompleted)
			{
				var errors = string.Empty;
				foreach (var error in result.Errors)
				{
					errors += error.Description + Environment.NewLine;
				};

				errors += updatingAddressResult.Exception;

				throw new MissingFieldException(errors);
			}

			return "User Updated Successfully";
		}

		public async Task<string> DeleteUserAsync(string userId)
		{
			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
			{
				throw new ArgumentNullException($"User with {userId} Not Found ");
			};

			var principal = await _unit.Principal.GetPrincipalAsync(user.Id);
			var address = await _unit.Address.FetchAddressAsync(principal.AddressId);
			await _unit.Principal.DeletePrincipalAsync(principal);
			var updatingAddressResult = _unit.Address.DeleteAddressAsync(address);
			var result = await _userManager.DeleteAsync(user);
			await _unit.SaveChangesAsync();
			if (!result.Succeeded || !updatingAddressResult.IsCompleted)
			{
				var errors = string.Empty;
				foreach (var error in result.Errors)
				{
					errors += error.Description + Environment.NewLine;
				};

				errors += updatingAddressResult.Exception;

				throw new MissingFieldException(errors);
			}

			return "User Removed Successfully";
		}
	}
}
