using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Service.Users.Interfaces;
using System;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Controllers
{
	[ApiController]
	[Route("api/[Controller]")]
	public class TeacherController : Controller
	{
		private readonly ITeacherServices _teacherServices;

		public TeacherController(ITeacherServices teacherServices)
		{
			_teacherServices = teacherServices;
		}


		[HttpPost]
		[Route("register")]
		public async Task<IActionResult> RegisterTeacher([FromBody] UserRegistrationRequest userRegistrationRequest)
		{
			try
			{
				var response = await _teacherServices.CreateUserAsync(userRegistrationRequest);
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


		[HttpGet]
		[Route("all")]
		public async Task<IActionResult> GetAllUsers()
		{
			try
			{
				var response = await _teacherServices.GetUsers();
				if (response != null)
				{
					return Ok(response);
				}
				return BadRequest("No User Found");
			}
			catch (ArgumentNullException ex)
			{
				return BadRequest(ex.Message);
			}
			catch
			{
				return BadRequest("No User Found");
			}
		}



		[HttpGet]
		public async Task<IActionResult> GetUser([FromQuery] string userId)
		{
			try
			{
				var response = await _teacherServices.GetUserAsync(userId);
				if (response != null)
				{
					return Ok(response);
				}
				return BadRequest($"No User with {userId} Found");
			}
			catch (ArgumentNullException ex)
			{
				return BadRequest(ex.Message);
			}
			catch
			{
				return BadRequest("No User Found");
			}
		}


		[HttpPatch]
		[Route("update")]
		[Authorize(Roles = "Teacher")]
		public async Task<IActionResult> UpdateUser([FromForm] UserUpdateRequest request)
		{
			try
			{
				var response = await _teacherServices.UpdateUserAsync(request);
				if (response != null)
				{
					return Ok(response);
				}
				return BadRequest($"Updating Not Successful");
			}
			catch (NotSupportedException ex)
			{
				return BadRequest("File Not Supported");
			}
			catch (MissingFieldException ex)
			{
				return BadRequest(ex.Message);
			}
			catch
			{
				return BadRequest("Updating not successful");
			}
		}



		[HttpDelete]
		[Route("Delete")]
		public async Task<IActionResult> DeleteUser([FromQuery] string userId)
		{
			try
			{
				var response = await _teacherServices.DeleteUserAsync(userId);
				if (response != null)
				{
					return Ok(response);
				}
				return BadRequest($"No User with {userId} Found");
			}
			catch (ArgumentNullException ex)
			{
				return BadRequest(ex.Message);
			}

			catch (MissingFieldException ex)
			{
				return BadRequest(ex.Message);
			}
			catch
			{
				return BadRequest("Delete not successful");
			}
		}

	}
}
