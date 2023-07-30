using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Common.Enums;
using SchoolManagerSystem.Model.Entities;
using SchoolManagerSystem.Repository.UnitOfWork.Interfaces;
using SchoolManagerSystem.Service.Authentications.Interfaces;
using SchoolManagerSystem.Service.CreateUser.Interfaces;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.CreateUser.Implementation
{
	public class CreateTeacher : ICreateTeacher
	{
		private readonly IUnitOfWork _unit;
		private readonly IAuthServices _auth;

		public CreateTeacher(IUnitOfWork unit, IAuthServices auth)
		{
			_unit = unit;
			_auth = auth;
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

			var createUser = await _auth.Register(user, request.Password, UserRole.Student);
			var createAddress = _unit.Address.CreateAddress(request);
			var teacher = _unit.Teacher.CreateTeacher(createUser.Id, createAddress.Id);
			await _unit.SaveChangesAsync();

			return "Teacher successfully created";
		}
	}
}
