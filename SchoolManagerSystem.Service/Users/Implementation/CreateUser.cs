using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Common.Enums;
using SchoolManagerSystem.Model.Entities;
using SchoolManagerSystem.Repository.UnitOfWork.Interfaces;
using SchoolManagerSystem.Service.Authentications.Interfaces;
using SchoolManagerSystem.Service.Users.Interfaces;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Users.Implementation
{
	public class CreateUser : ICreateUser
	{
		private readonly IUnitOfWork _unit;
		private readonly IAuthServices _auth;

		public CreateUser(IUnitOfWork unit, IAuthServices auth)
		{
			_unit = unit;
			_auth = auth;
		}
		public async Task<string> CreatePrincipalAsync(UserRegistrationRequest request)
		{
			var user = new ApplicationUser
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				Email = request.Email,
				UserName = request.UserName,
				EmailConfirmed = true
			};

			var createUser = await _auth.Register(user, request.Password, UserRole.Principal);
			var createAddress = _unit.Address.CreateAddress(request);
			var principal = _unit.Principal.CreatePrincipal(createUser.Id, createAddress.Id);
			await _unit.SaveChangesAsync();

			return "principal successfully created";
		}

		public async Task<string> CreateStudentAsync(UserRegistrationRequest request)
		{
			var user = new ApplicationUser
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				Email = request.Email,
				UserName = request.UserName,
				EmailConfirmed = true
			};

			var createUser = await _auth.Register(user, request.Password, UserRole.Student);
			var createAddress = _unit.Address.CreateAddress(request);
			var student = _unit.Student.CreateStudent(createUser.Id, createAddress.Id);
			await _unit.SaveChangesAsync();

			return "Student successfully created";
		}

		public async Task<string> CreateTeacherAsync(UserRegistrationRequest request)
		{
			var user = new ApplicationUser
			{
				FirstName = request.FirstName,
				LastName = request.LastName,
				Email = request.Email,
				UserName = request.UserName,
				EmailConfirmed = true
			};

			var createUser = await _auth.Register(user, request.Password, UserRole.Teacher);
			var createAddress = _unit.Address.CreateAddress(request);
			var teacher = _unit.Teacher.CreateTeacher(createUser.Id, createAddress.Id);
			await _unit.SaveChangesAsync();

			return "Teacher successfully created";
		}
	}
}
