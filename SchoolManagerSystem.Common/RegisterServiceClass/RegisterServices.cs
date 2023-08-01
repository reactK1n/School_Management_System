using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SchoolManagerSystem.Data;
using SchoolManagerSystem.Model.Entities;
using System;
using System.Text;

namespace SchoolManagerSystem.Common.RegisterServiceClass
{
	public static class RegisterServices
	{
		public static void AddAuthenticationConfig(this IServiceCollection services, IConfiguration configuration)
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
					ValidAudience = configuration["JwtSettings:ValidAudience"],
					ValidIssuer = configuration["JwtSettings:ValidIssuer"],
					IssuerSigningKey = new SymmetricSecurityKey(
						Encoding.UTF8.GetBytes(configuration["JwtSettings:SecretKey"])),
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
		}
	}
}
