using Microsoft.AspNetCore.Identity;
using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Model.Entities;
using SchoolManagerSystem.Service.Authentications.Interfaces;
using System;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Authentications.Implementations
{
    public class AuthServices : IAuthServices
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IToken _token;

		public AuthServices(UserManager<ApplicationUser> userManager, IToken token)
		{
			_userManager = userManager;
			_token = token;
		}

		public async Task<UserRegistrationResponse> Register(UserRegistrationRequest registerRequest)
		{
			var user = new ApplicationUser
			{
				FirstName = registerRequest.FirstName,
				LastName = registerRequest.LastName,
				Email = registerRequest.Email,
				UserName = registerRequest.UserName,
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
