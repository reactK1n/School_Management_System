using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagerSystem.Data;
using SchoolManagerSystem.Model.Entities;

namespace SchoolManagerSystem.Common.RegisterServiceClass
{
	public static class RegisterServices
	{
/*		public static void ConfigAuthentication(this IServiceCollection services)
		{
			services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<SMSContext>()
				.AddDefaultTokenProviders();

			services.AddAuthentication(opt =>
			{
				opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(opt =>
			{
				opt.TokenValidationParameters = new TokenValidationParameters

				{
					ValidateAudience = true,
					ValidateIssuer = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidAudience = Configuration["JwtSettings:ValidAudience"],
					ValidIssuer = Configuration["JwtSettings:ValidIssuer"],
					IssuerSigningKey = new SymmetricSecurityKey(
						Encoding.UTF8.GetBytes(Configuration["JwtSettings:SecretKey"])),
					ClockSkew = TimeSpan.Zero
				};
			});

			services.Configure<IdentityOptions>(opt =>
			{
				opt.User.RequireUniqueEmail = true;
				opt.Password.RequiredLength = 8;
				opt.Password.RequireNonAlphanumeric = true;
				opt.Password.RequireDigit = true;
				opt.Password.RequireUppercase = true;
			});
		}*/

	}
}
