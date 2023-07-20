using Microsoft.AspNetCore.Identity;
using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Model.Entities;
using SchoolManagerSystem.Service.Authentications.Interfaces;
using SchoolManagerSystem.Service.Token.Interfaces;
using System;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Authentications.Implementations
{
	public class LoginService : ILoginService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IToken _token;

		public LoginService(UserManager<ApplicationUser> userManager, IToken token)
		{
			_userManager = userManager;
			_token = token;
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
