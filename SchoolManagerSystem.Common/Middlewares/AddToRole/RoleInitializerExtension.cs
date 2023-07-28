using Microsoft.AspNetCore.Builder;

namespace SchoolManagerSystem.Common.Middlewares.AddToRole
{
	public static class RoleInitializerExtension
	{
		public static IApplicationBuilder UseRoleInitializer(this IApplicationBuilder app)
		{
			var useRoleInit = app.UseMiddleware<RoleInitializer>();
			return useRoleInit;
		}
	}
}
