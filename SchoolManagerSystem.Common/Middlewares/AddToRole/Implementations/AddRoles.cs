using Microsoft.AspNetCore.Identity;
using SchoolManagerSystem.Common.Enums;
using SchoolManagerSystem.Common.Middlewares.AddToRole.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Common.Middlewares.AddToRole.Implementations
{
	public class AddRoles : IAddRoles
	{
		private readonly RoleManager<IdentityRole> _roleManager;

		public AddRoles(RoleManager<IdentityRole> roleManager)
        {
			_roleManager = roleManager;
		}
        public async Task InitRoles()
		{
			var roles = _roleManager.Roles.ToList();
			if (!roles.Any())
			{
				await _roleManager.CreateAsync(new IdentityRole { Name = UserRole.Principal.ToString() });
				await _roleManager.CreateAsync(new IdentityRole { Name = UserRole.Teacher.ToString() });
				await _roleManager.CreateAsync(new IdentityRole { Name = UserRole.Student.ToString() });
			}
		}
	}
}
