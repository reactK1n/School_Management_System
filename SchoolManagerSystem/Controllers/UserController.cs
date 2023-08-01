using Microsoft.AspNetCore.Mvc;
using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Service.Users.Interfaces;
using System;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Controllers
{
	[ApiController]
	[Route("api/[Controller]")]
	public class UserController : ControllerBase
	{
		private readonly IFetchUser _fetch;
		private readonly IUpdateUser _update;
		private readonly IDeleteUser _delete;

		public UserController(IFetchUser fetch, IUpdateUser update, IDeleteUser delete)
		{
			_fetch = fetch;
			_update = update;
			_delete = delete;
		}


		[HttpGet]
		[Route("users")]
		public async Task<IActionResult> GetAllUsers()
		{
			try
			{
				var response = await _fetch.GetAllUsers();
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
				var response = await _fetch.GetUserAsync(userId);
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



		[HttpGet]
		[Route("principals")]
		public async Task<IActionResult> GetAllPrincipals()
		{
			try
			{
				var response = await _fetch.GetAllPrincipals();
				if (response != null)
				{
					return Ok(response);
				}
				return BadRequest("No Principal Found");
			}
			catch (ArgumentNullException ex)
			{
				return BadRequest(ex.Message);
			}
			catch
			{
				return BadRequest("No Principal Found");
			}
		}



		[HttpGet]
		[Route("teachers")]
		public async Task<IActionResult> GetAllTeacher()
		{
			try
			{
				var response = await _fetch.GetAllTeachers();
				if (response != null)
				{
					return Ok(response);
				}
				return BadRequest("No Teacher Found");
			}
			catch (ArgumentNullException ex)
			{
				return BadRequest(ex.Message);
			}
			catch
			{
				return BadRequest("No Teacher Found");
			}
		}



		[HttpGet]
		[Route("students")]
		public async Task<IActionResult> GetAllStudents()
		{
			try
			{
				var response = await _fetch.GetAllStudents();
				if (response != null)
				{
					return Ok(response);
				}
				return BadRequest("No Student Found");
			}
			catch (ArgumentNullException ex)
			{
				return BadRequest(ex.Message);
			}
			catch
			{
				return BadRequest("No Student Found");
			}
		}



		[HttpPatch]
		[Route("update")]
		public async Task<IActionResult> UpdateUser([FromBody] UserUpdateRequest request, [FromQuery] string userId)
		{
			try
			{
				var response = await _update.UpdateUserAsync(userId, request);
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
				var response = await _delete.DeleteUserAsync(userId);
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
