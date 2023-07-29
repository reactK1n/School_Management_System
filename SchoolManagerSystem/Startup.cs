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
using SchoolManagerSystem.Repository.Implementation;
using SchoolManagerSystem.Repository.Interfaces;
using SchoolManagerSystem.Repository.UnitOfWork.Implementations;
using SchoolManagerSystem.Repository.UnitOfWork.Interfaces;
using SchoolManagerSystem.Service.Authentications.Implementations;
using SchoolManagerSystem.Service.Authentications.Interfaces;
using SchoolManagerSystem.Service.Principal.Implementation;
using SchoolManagerSystem.Service.Principal.Interfaces;

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
			services.AddScoped<ITokenService, TokenService>();
			services.AddScoped<IAuthServices, AuthServices>();
			services.AddScoped<IAddressRepository, AddressRepository>();
			services.AddScoped<IPrincipalRepository, PrincipalRepository>();
			services.AddScoped<ICreatePrincipal, CreatePrincipal>();
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddAuthenticationConfig(Configuration);

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "SchoolManagerSystem", Version = "v1" });
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
