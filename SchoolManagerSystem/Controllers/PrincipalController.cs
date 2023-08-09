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
	public class PrincipalController : ControllerBase
	{
		private readonly IPrincipalServices _principalServices;

		public PrincipalController(IPrincipalServices principalServices)
		{
			_principalServices = principalServices;
		}

		[HttpPost]
		[Route("register")]
		public async Task<IActionResult> RegisterPrincipal([FromBody] UserRegistrationRequest userRegistrationRequest)
		{
			try
			{
				var response = await _principalServices.CreateUserAsync(userRegistrationRequest);
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


		[HttpGet]
		[Route("all")]
		public async Task<IActionResult> GetAllUsers()
		{
			try
			{
				var response = await _principalServices.GetUsers();
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
				var response = await _principalServices.GetUserAsync(userId);
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
		[Authorize(Roles = "Principal")]
		public async Task<IActionResult> UpdateUser([FromForm] UserUpdateRequest request)
		{
			try
			{
				var response = await _principalServices.UpdateUserAsync(request);
				if (response != null)
				{
					return Ok(response);
				}
				return BadRequest($"Updating Not Successful");
			}
			catch (ArgumentNullException ex)
			{
				return BadRequest(ex.Message);
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
				var response = await _principalServices.DeleteUserAsync(userId);
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
