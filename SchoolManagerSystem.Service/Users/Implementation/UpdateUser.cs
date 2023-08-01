using Microsoft.AspNetCore.Identity;
using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Common.Enums;
using SchoolManagerSystem.Model.Entities;
using SchoolManagerSystem.Repository.UnitOfWork.Interfaces;
using SchoolManagerSystem.Service.Users.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Users.Implementation
{
	public class UpdateUser : IUpdateUser
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IUnitOfWork _unit;

		public UpdateUser(UserManager<ApplicationUser> userManager, IUnitOfWork unit)
		{
			_userManager = userManager;
			_unit = unit;
		}
		public async Task<string> UpdateUserAsync(string userId, UserUpdateRequest request)
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
				var appUser  = await _unit.Principal.GetPrincipalAsync(user.Id);
				address = await _unit.Address.FetchAddressAsync(appUser.AddressId);

			}

			if (userRole == UserRole.Teacher.ToString())
			{
				var appUser = await _unit.Teacher.GetTeacherAsync(user.Id);
				address = await _unit.Address.FetchAddressAsync(appUser.AddressId);

			}

			if (userRole == UserRole.Student.ToString())
			{
				var appUser = await _unit.Student.GetStudentAsync(user.Id);
				address = await _unit.Address.FetchAddressAsync(appUser.AddressId);

			}

			user.FirstName = request.FirstName ?? user.FirstName;
			user.LastName = request.LastName ?? user.LastName;
			user.Email = request.Email ?? user.Email;
			user.UserName = request.UserName ?? user.UserName;
			user.UpdatedOn = DateTime.UtcNow;
			address.State = request.State ?? address.State;
			address.City = request.City ?? address.City;
			address.UpdatedOn = DateTime.UtcNow;

			var updatingAddressResult = _unit.Address.UpdateAddressAsync(address);
			var result = await _userManager.UpdateAsync(user);
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

			return "User Updated Successfully";
		}
	}
}
