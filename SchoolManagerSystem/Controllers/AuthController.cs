using Microsoft.AspNetCore.Mvc;
using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Service.Authentications.Interfaces;
using SchoolManagerSystem.Service.CreateUser.Implementation;
using SchoolManagerSystem.Service.CreateUser.Interfaces;
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
		private readonly ICreateTeacher _createTeacher;
		private readonly ICreateStudent _createStudent;

		public AuthController(IAuthServices authServices,
			ICreatePrincipal createPrincipal,
			ICreateTeacher createTeacher,
			ICreateStudent createStudent)
		{
			_authServices = authServices;
			_createPrincipal = createPrincipal;
			_createTeacher = createTeacher;
			_createStudent = createStudent;
		}


		[HttpPost]
		[Route("register/principal")]
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
		[Route("Register/Teacher")]
		public async Task<IActionResult> RegisterTeacher([FromBody] UserRegistrationRequest userRegistrationRequest)
		{
			try
			{
				var response = await _createTeacher.CreateTeacherAsync(userRegistrationRequest);
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
		[Route("Register/Student")]
		public async Task<IActionResult> RegisterStudent([FromBody] UserRegistrationRequest userRegistrationRequest)
		{
			try
			{
				var response = await _createStudent.CreateStudentAsync(userRegistrationRequest);
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
