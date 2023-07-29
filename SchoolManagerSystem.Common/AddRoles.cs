using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagerSystem.Common.Enums;
using System.Linq;

namespace SchoolManagerSystem.Common
{
    public static class AddRoles
    {
        public static void InitRoles(this IApplicationBuilder app)
        {
            var serviceScope = app.ApplicationServices.CreateScope();
            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var roles = roleManager.Roles.ToList();
            if (!roles.Any())
            {
                roleManager.CreateAsync(new IdentityRole { Name = UserRole.Principal.ToString() }).Wait();
                roleManager.CreateAsync(new IdentityRole { Name = UserRole.Teacher.ToString() }).Wait();
                roleManager.CreateAsync(new IdentityRole { Name = UserRole.Student.ToString() }).Wait();
            }
        }
    }
}
