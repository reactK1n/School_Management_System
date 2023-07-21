using Microsoft.AspNetCore.Identity;
using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Model.Entities;
using SchoolManagerSystem.Service.Authentications.Interfaces;
using System;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Authentications.Implementations
{
	public class RegisterService : IRegisterService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		public RegisterService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
		}
		public async Task<UserRegistrationResponse> Register(UserRegistrationRequest registerRequest, string isRole)
		{
			var user = new ApplicationUser
			{
				FirstName = registerRequest.FirstName,
				LastName = registerRequest.LastName,
				Email = registerRequest.Email,
				UserName = registerRequest.UserName,
				PasswordHash = registerRequest.Password,
				EmailConfirmed = true
			};
			var results = await _userManager.CreateAsync(user, registerRequest.Password);
			if (!results.Succeeded)
			{
				var errors = string.Empty;
				foreach (var error in results.Errors)
				{
					errors = error.Description + Environment.NewLine;
				}
				throw new MissingFieldException(errors);
			}

			var isRoleTheSame = isRole.Equals("Principal");
			var isRoleExist = false;
			if (isRoleTheSame)
			{
				isRoleExist = await _roleManager.RoleExistsAsync("Principal");

			}

			if (isRoleExist)
			{
				throw new InvalidOperationException("Role Already Exists");
			}
			await _userManager.AddToRoleAsync(user, isRole);

			var response = new UserRegistrationResponse
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email,
				UserName = user.UserName,
			};

			return response;
		}
	}
}
