using Microsoft.AspNetCore.Identity;
using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Common.Enums;
using SchoolManagerSystem.Model.Entities;
using SchoolManagerSystem.Repository.UnitOfWork.Interfaces;
using SchoolManagerSystem.Service.Authentications.Interfaces;
using SchoolManagerSystem.Service.Users.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Users.Implementation
{
	public class TeacherServices : ITeacherServices
	{
		private readonly IUnitOfWork _unit;
		private readonly IAuthServices _auth;
		private readonly UserManager<ApplicationUser> _userManager;

		public TeacherServices(IUnitOfWork unit, IAuthServices auth, UserManager<ApplicationUser> userManager)
		{
			_unit = unit;
			_auth = auth;
			_userManager = userManager;
		}

		public async Task<string> CreateUserAsync(UserRegistrationRequest request)
		{
			var user = new ApplicationUser
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				Email = request.Email,
				UserName = request.UserName,
				EmailConfirmed = true
			};

			var createUser = await _auth.Register(user, request.Password, UserRole.Teacher);
			var createAddress = _unit.Address.CreateAddress(request);
			var teacher = _unit.Teacher.CreateTeacher(createUser.Id, createAddress.Id);
			await _unit.SaveChangesAsync();

			return "Teacher successfully created";
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

		public async Task<string> UpdateUserAsync(string userId, UserUpdateRequest request)
		{
			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
			{
				throw new ArgumentNullException($"User with {userId} Not Found ");
			};

			var appUser = await _unit.Teacher.GetTeacherAsync(user.Id);
			var address = await _unit.Address.FetchAddressAsync(appUser.AddressId);

			user.FirstName = request.FirstName ?? user.FirstName;
			user.LastName = request.LastName ?? user.LastName;
			user.Email = request.Email ?? user.Email;
			user.UserName = request.UserName ?? user.UserName;
			user.UpdatedOn = DateTime.UtcNow;
			address.State = request.State ?? address.State;
			address.City = request.City ?? address.City;
			address.UpdatedOn = DateTime.UtcNow;

			var updatingAddressResult = _unit.Address.UpdateAddressAsync(address);
			var result = await _userManager.UpdateAsync(user);
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

			var appUser = await _unit.Teacher.GetTeacherAsync(user.Id);
			var address = await _unit.Address.FetchAddressAsync(appUser.AddressId);
			await _unit.Teacher.DeleteTeacherAsync(appUser);
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
