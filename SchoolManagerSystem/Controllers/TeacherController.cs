using Microsoft.AspNetCore.Mvc;
using SchoolManagerSystem.Common.DTOs;
using System.Threading.Tasks;
using System;
using SchoolManagerSystem.Service.Users.Interfaces;

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


		[HttpGet]
		[Route("all")]
		public async Task<IActionResult> GetAllUsers()
		{
			try
			{
				var response = _teacherServices.GetUsers();
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
		[Route("[Controller]")]
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
		public async Task<IActionResult> UpdateUser([FromBody] UserUpdateRequest request, [FromQuery] string userId)
		{
			try
			{
				var response = await _teacherServices.UpdateUserAsync(userId, request);
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
