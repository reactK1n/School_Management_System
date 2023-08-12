using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SchoolManagerSystem.Common;
using SchoolManagerSystem.Common.RegisterServiceClass;
using SchoolManagerSystem.Data;
using SchoolManagerSystem.Data.SeederClass;
using SchoolManagerSystem.Repository.Implementation;
using SchoolManagerSystem.Repository.Interfaces;
using SchoolManagerSystem.Repository.UnitOfWork.Implementations;
using SchoolManagerSystem.Repository.UnitOfWork.Interfaces;
using SchoolManagerSystem.Service.Authentications.Implementations;
using SchoolManagerSystem.Service.Authentications.Interfaces;
using SchoolManagerSystem.Service.Courses.Implementations;
using SchoolManagerSystem.Service.Courses.Interfaces;
using SchoolManagerSystem.Service.Files.Implementations;
using SchoolManagerSystem.Service.Files.Interfaces;
using SchoolManagerSystem.Service.Users.Implementation;
using SchoolManagerSystem.Service.Users.Interfaces;
using System;

namespace SchoolManagerSystem
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddDbContextPool<SMSContext>(opt =>
			{
				//registering of database service
				opt.UseSqlServer(Configuration["ConnectionStrings:DefaultConnectionString"]);
			});
			services.AddHttpContextAccessor();
			services.AddScoped<ITokenService, TokenService>();
			services.AddScoped<IAuthServices, AuthServices>();
			services.AddScoped<IImageService, ImageService>();
			services.AddScoped<IAddressRepository, AddressRepository>();
			services.AddScoped<IPrincipalRepository, PrincipalRepository>();
			services.AddScoped<ITeacherRepository, TeacherRepository>();
			services.AddScoped<ICourseRepository, CourseRepository>();
			services.AddScoped<ILevelRepository, LevelRepository>();
			services.AddScoped<IStudentRepository, StudentRepository>();
			services.AddScoped<IPrincipalServices, PrincipalServices>();
			services.AddScoped<ITeacherServices, TeacherServices>();
			services.AddScoped<IStudentServices, StudentServices>();
			services.AddScoped<ICourseServices, CourseServices>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddAuthenticationConfig(Configuration);

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "SchoolManagerSystem", Version = "v1" });
				//this for locking the api with roles inside controller
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
				{
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer",
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Description = "Enter 'Bearer' [space] and then your valid token in the input below.\r\n\rExample: \"Bearer ioqnqf8uqnwifqiwunwfudifijdfdlkjsdnfajldjnfj"
				});
				c.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{

						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							}
						},
						Array.Empty<string>()
					}
				});
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SchoolManagerSystem v1"));
			}

			app.seedData();
			app.InitRoles();
			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
