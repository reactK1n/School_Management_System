using Microsoft.AspNetCore.Identity;
using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Common.Enums;
using SchoolManagerSystem.Model.Entities;
using SchoolManagerSystem.Service.Authentications.Interfaces;
using System;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Authentications.Implementations
{
	public class AuthServices : IAuthServices
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly ITokenService _token;

		public AuthServices(UserManager<ApplicationUser> userManager, ITokenService token)
		{
			_userManager = userManager;
			_token = token;
		}

		public async Task<UserResponse> Register(ApplicationUser user, string password, UserRole role)
		{
			var results = await _userManager.CreateAsync(user, password);
			if (!results.Succeeded)
			{
				var errors = string.Empty;
				foreach (var error in results.Errors)
				{
					errors = error.Description + Environment.NewLine;
				}
				throw new MissingFieldException(errors);
			}
			await _userManager.AddToRoleAsync(user, role.ToString());

			var response = new UserResponse
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email,
				UserName = user.UserName,
			};

			return response;
		}

		public async Task<LoginResponse> Login(LoginRequest loginRequest)
		{
			var user = await _userManager.FindByEmailAsync(loginRequest.Email);
			if (user == null)
			{
				throw new ArgumentNullException("Email Provided is Invalid");
			}
			var isPasswordMatch = await _userManager.CheckPasswordAsync(user, loginRequest.Password);
			if (!isPasswordMatch)
			{
				throw new ArgumentNullException("Password Not Match");
			}
			var token = await _token.GetToken(user);

			var response = new LoginResponse
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email,
				UserName = user.UserName,
				Token = token
			};

			return response;
		}
	}
}
