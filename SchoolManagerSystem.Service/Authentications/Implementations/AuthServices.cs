using Microsoft.AspNetCore.Identity;
using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Model.Entities;
using SchoolManagerSystem.Service.Authentications.Interfaces;
using SchoolManagerSystem.Service.Token.Interfaces;
using System;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Authentications.Implementations
{
	public class AuthServices : IAuthServices
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IToken _token;

		public AuthServices(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IToken token)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_token = token;
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


		public async Task<LoginResponse> Login(LoginRequest loginRequest)
		{
			var user = await _userManager.FindByEmailAsync(loginRequest.Email);
			if (user == null)
			{
				throw new ArgumentNullException("Email Provided is Invalid");
			}
			var isUserFound = await _userManager.CheckPasswordAsync(user, loginRequest.Password);
			if (!isUserFound)
			{
				throw new ArgumentNullException("User does not Exist");
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
