using Microsoft.AspNetCore.Mvc;
using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Service.Authentications.Interfaces;
using SchoolManagerSystem.Service.Principal.Implementation;
using SchoolManagerSystem.Service.Principal.Interfaces;
using System;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Controllers
{
	[ApiController]
	[Route("api/[Controller]")]
	public class AuthController : ControllerBase
	{
		private readonly IAuthServices _authServices;
		private readonly ICreatePrincipal _createPrincipal;

		public AuthController(IAuthServices authServices, ICreatePrincipal createPrincipal)
		{
			_authServices = authServices;
			_createPrincipal = createPrincipal;
		}


		[HttpPost]
		[Route("Register/Principal")]
		public async Task<IActionResult> RegisterPrincipal([FromBody] UserRegistrationRequest userRegistrationRequest)
		{
			try
			{
				var response = await _createPrincipal.CreatePrincipalAsync(userRegistrationRequest);
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
