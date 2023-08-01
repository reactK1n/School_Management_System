using Microsoft.AspNetCore.Identity;
using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Model.Entities;
using SchoolManagerSystem.Repository.UnitOfWork.Interfaces;
using SchoolManagerSystem.Service.Users.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Users.Implementation
{
	public class FetchUser : IFetchUser
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IUnitOfWork _unit;

		public FetchUser(UserManager<ApplicationUser> userManager, IUnitOfWork unit)
		{
			_userManager = userManager;
			_unit = unit;
		}



		public async Task<ICollection<UserResponse>> GetAllPrincipals()
		{
			var users = _unit.Principal.FetchPrincipals();
			if (users == null)
			{
				throw new ArgumentNullException("No User Found");
			};

			var response = new List<UserResponse>();
			foreach (var user in users)
			{
				var appUser = await _userManager.FindByIdAsync(user.UserId);
				response.Add(new UserResponse
				{
					Id = appUser.Id,
					FirstName = appUser.FirstName,
					LastName = appUser.LastName,
					UserName = appUser.UserName,
					Email = appUser.Email
				});
			}

			return response;
		}



		public async Task<ICollection<UserResponse>> GetAllStudents()
		{
			var users = _unit.Student.FetchStudents();
			if (users == null)
			{
				throw new ArgumentNullException("No User Found");
			};

			var response = new List<UserResponse>();
			foreach (var user in users)
			{
				var appUser = await _userManager.FindByIdAsync(user.UserId);
				response.Add(new UserResponse
				{
					Id = appUser.Id,
					FirstName = appUser.FirstName,
					LastName = appUser.LastName,
					UserName = appUser.UserName,
					Email = appUser.Email
				});
			}

			return response;
		}



		public async Task<ICollection<UserResponse>> GetAllTeachers()
		{
			var users = _unit.Teacher.FetchTeachers();
			if (users == null)
			{
				throw new ArgumentNullException("No User Found");
			};

			var response = new List<UserResponse>();
			foreach (var user in users)
			{
				var appUser = await _userManager.FindByIdAsync(user.UserId);
				response.Add(new UserResponse
				{
					Id = appUser.Id,
					FirstName = appUser.FirstName,
					LastName = appUser.LastName,
					UserName = appUser.UserName,
					Email = appUser.Email
				});
			}

			return response;
		}


			public async Task<ICollection<UserResponse>> GetAllUsers()
		{
			var users = _userManager.Users.ToList();
			if (users == null)
			{
				throw new ArgumentNullException("No User Found");
			};

			var response = new List<UserResponse>();
			foreach (var user in users)
			{
				response.Add(new UserResponse
				{
					Id = user.Id,
					FirstName = user.FirstName,
					LastName = user.LastName,
					UserName = user.UserName,
					Email = user.Email
				});
			}

			return response;
		}


		public async Task<UserResponse> GetUserAsync(string userId)
		{
			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
			{
				throw new ArgumentNullException($"User with {userId} Not Found ");
			};

			var response = new UserResponse
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				UserName = user.UserName,
				Email = user.Email
			};

			return response;
		}
	}

}
