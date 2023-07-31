using Microsoft.AspNetCore.Mvc;
using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Service.Authentications.Interfaces;
using SchoolManagerSystem.Service.Users.Interfaces;
using System;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Controllers
{
	[ApiController]
	[Route("api/[Controller]")]
	public class AuthController : ControllerBase
	{
		private readonly IAuthServices _authServices;
		private readonly ICreateUser _createUser;

		public AuthController(IAuthServices authServices,
			ICreateUser createUser)
		{
			_authServices = authServices;
			_createUser = createUser;
		}


		[HttpPost]
		[Route("register/principal")]
		public async Task<IActionResult> RegisterPrincipal([FromBody] UserRegistrationRequest userRegistrationRequest)
		{
			try
			{
				var response = await _createUser.CreatePrincipalAsync(userRegistrationRequest);
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
		[Route("register/teacher")]
		public async Task<IActionResult> RegisterTeacher([FromBody] UserRegistrationRequest userRegistrationRequest)
		{
			try
			{
				var response = await _createUser.CreateTeacherAsync(userRegistrationRequest);
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
		[Route("register/student")]
		public async Task<IActionResult> RegisterStudent([FromBody] UserRegistrationRequest userRegistrationRequest)
		{
			try
			{
				var response = await _createUser.CreateStudentAsync(userRegistrationRequest);
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
