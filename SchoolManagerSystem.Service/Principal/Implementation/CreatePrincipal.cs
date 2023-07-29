using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Common.Enums;
using SchoolManagerSystem.Model.Entities;
using SchoolManagerSystem.Repository.UnitOfWork.Interfaces;
using SchoolManagerSystem.Service.Authentications.Interfaces;
using SchoolManagerSystem.Service.Principal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Principal.Implementation
{
    public class CreatePrincipal : ICreatePrincipal
    {
        private readonly IUnitOfWork unit;
        private readonly IAuthServices auth;

        public CreatePrincipal(IUnitOfWork unit, IAuthServices auth)
        {
            this.unit = unit;
            this.auth = auth;
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

            var createUser = await auth.Register(user, request.Password, UserRole.Principal);
            var createAddress = unit.Address.CreateAddress(request);
            var principal = unit.Principal.CreatePrincipal(createUser.Id, createAddress.Id);

            return "principal successfully created";
        }
    }
}
