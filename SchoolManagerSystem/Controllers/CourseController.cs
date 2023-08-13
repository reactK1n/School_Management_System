using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Service.Courses.Interfaces;
using System;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Controllers
{
	[ApiController]
	[Route("api/[Controller]")]
	public class CourseController : ControllerBase
	{
		private readonly ICourseServices _courseServices;

		public CourseController(ICourseServices courseServices)
		{
			_courseServices = courseServices;
		}


		[HttpPost]
		[Route("add")]
		[Authorize(Roles = "Teacher")]
		public async Task<IActionResult> AddCourse([FromBody] CourseRequest request)
		{
			try
			{
				var response = await _courseServices.AddCourse(request);
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
			catch (ArgumentException ex)
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
		[Authorize(Roles = "Principal")]
		[Authorize(Roles = "Teacher")]
		public async Task<IActionResult> GetAllCourses([FromQuery] string levelId)
		{
			try
			{
				var response = await _courseServices.FetchCoursesAsync(levelId);
				if (response != null)
				{
					return Ok(response);
				}
				return BadRequest("No Course Found");
			}
			catch (ArgumentNullException ex)
			{
				return BadRequest(ex.Message);
			}
			catch
			{
				return BadRequest("No Course Found");
			}
		}



		[HttpGet]
		public async Task<IActionResult> GetStudentCourse([FromQuery] string studentId)
		{
			try
			{
				var response = await _courseServices.GetStudentCourseAsync(studentId);
				if (response != null)
				{
					return Ok(response);
				}
				return BadRequest($"No Course with {studentId} Found");
			}
			catch (ArgumentNullException ex)
			{
				return BadRequest(ex.Message);
			}
			catch
			{
				return BadRequest("No Course Found");
			}
		}


		[HttpPatch]
		[Route("update")]
		[Authorize(Roles = "Principal")]
		[Authorize(Roles = "Teacher")]
		public async Task<IActionResult> UpdateCourse([FromBody] CourseUpdateRequest request, [FromQuery] string courseId)
		{
			try
			{
				await _courseServices.UpdateCourseAsync(request, courseId);
				return NoContent();
			}
			catch (ArgumentNullException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (ArgumentException ex)
			{
				return BadRequest(ex.Message);
			}
			catch (MissingFieldException ex)
			{
				return BadRequest(ex.Message);
			}
			catch
			{
				return BadRequest("Updating Not Successful");
			}
		}



		[HttpDelete]
		[Route("Delete")]
		[Authorize(Roles = "Principal")]
		[Authorize(Roles = "Teacher")]
		public async Task<IActionResult> DeleteCourse([FromQuery] string courseId)
		{
			try
			{
				await _courseServices.DeleteCourseAsync(courseId);
				return NoContent();
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
				return BadRequest("Deleting not successful");
			}
		}
	}
}
