using Microsoft.AspNetCore.Identity;
using SchoolManagerSystem.Common.Enums;
using SchoolManagerSystem.Model.Entities;
using SchoolManagerSystem.Repository.UnitOfWork.Interfaces;
using SchoolManagerSystem.Service.Users.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Users.Implementation
{

	public class DeleteUser : IDeleteUser
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IUnitOfWork _unit;

		public DeleteUser(UserManager<ApplicationUser> userManager, IUnitOfWork unit)
		{
			_userManager = userManager;
			_unit = unit;
		}

		public async Task<string> DeleteUserAsync(string userId)
		{
			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
			{
				throw new ArgumentNullException($"User with {userId} Not Found ");
			};
			var roles = await _userManager.GetRolesAsync(user);
			var userRole = roles.FirstOrDefault();

			var address = new Address();
			if (userRole == UserRole.Principal.ToString())
			{
				var appUser = await _unit.Principal.GetPrincipalAsync(user.Id);
				address = await _unit.Address.FetchAddressAsync(appUser.AddressId);
				await _unit.Principal.DeletePrincipalAsync(appUser);

			}

			if (userRole == UserRole.Teacher.ToString())
			{
				var appUser = await _unit.Teacher.GetTeacherAsync(user.Id);
				address = await _unit.Address.FetchAddressAsync(appUser.AddressId);
				await _unit.Teacher.DeleteTeacherAsync(appUser);


			}

			if (userRole == UserRole.Student.ToString())
			{
				var appUser = await _unit.Student.GetStudentAsync(user.Id);
				address = await _unit.Address.FetchAddressAsync(appUser.AddressId);
				await _unit.Student.DeleteStudentAsync(appUser);


			}

			var updatingAddressResult = _unit.Address.DeleteAddressAsync(address);
			var result = await _userManager.DeleteAsync(user);
			await _unit.SaveChangesAsync();
			if (!result.Succeeded || !updatingAddressResult.IsCompleted)
			{
				var errors = string.Empty;
				foreach (var error in result.Errors)
				{
					errors += error.Description + Environment.NewLine;
				};

				errors += updatingAddressResult.Exception;

				throw new MissingFieldException(errors);
			}
			return "User Removed Successfully";
		}

	}
}
