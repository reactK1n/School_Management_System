using Microsoft.AspNetCore.Http;
using SchoolManagerSystem.Common.Middlewares.AddToRole.Interfaces;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Common.Middlewares.AddToRole
{
    public class RoleInitializer
    {
        private readonly RequestDelegate _next;

        public RoleInitializer(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IAddRoles addRoles)
        {
            await addRoles.InitRoles();
            await _next(httpContext);
        }
    }
}