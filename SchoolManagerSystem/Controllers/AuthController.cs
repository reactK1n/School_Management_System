using Microsoft.AspNetCore.Mvc;
using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Service.Authentications.Interfaces;
using System;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Controllers
{
	[ApiController]
	[Route("api/[Controller]")]
	public class AuthController : ControllerBase
	{
		private readonly IAuthServices _authServices;

		public AuthController(IAuthServices authServices)
		{
			_authServices = authServices;
		}


		[HttpPost]
		[Route("register")]
		public async Task<IActionResult> Register([FromBody] UserRegistrationRequest userRegistrationRequest)
		{
			try
			{
				var response = await _authServices.Register(userRegistrationRequest);
				if (response != null)
				{
					return Ok(response);
				}
				return BadRequest();

			}
			catch (MissingFieldException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (InvalidOperationException ex)
			{
				return BadRequest(ex.Message);
			}
			catch
			{
				return BadRequest();
			}
		}


		[HttpPost]
		[Route("login")]
		public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
		{
			try
			{
				var response = await _authServices.Login(loginRequest);
				if (response != null)
				{
					return Ok(response);
				}
				return BadRequest();
			}
			catch (ArgumentNullException ex)
			{
				return BadRequest(ex.Message);
			}
			catch
			{
				return BadRequest();
			}
		}
	}
}
