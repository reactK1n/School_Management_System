using Microsoft.AspNetCore.Mvc;
using SchoolManagerSystem.Common.DTOs;
using System.Threading.Tasks;
using System;
using SchoolManagerSystem.Service.Users.Interfaces;

namespace SchoolManagerSystem.Controllers
{
	[ApiController]
	[Route("api/[Controller]")]
	public class StudentController : Controller
	{
		private readonly IStudentServices _studentServices;

		public StudentController(IStudentServices studentServices)
        {
			_studentServices = studentServices;
		}

        [HttpGet]
		[Route("all")]
		public async Task<IActionResult> GetAllUsers()
		{
			try
			{
				var response = _studentServices.GetUsers();
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
				var response = await _studentServices.GetUserAsync(userId);
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
				var response = await _studentServices.UpdateUserAsync(userId, request);
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
				var response = await _studentServices.DeleteUserAsync(userId);
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
