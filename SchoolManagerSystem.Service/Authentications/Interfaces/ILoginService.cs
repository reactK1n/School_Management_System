using SchoolManagerSystem.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Authentications.Interfaces
{
	public interface ILoginService
	{
		Task<LoginResponse> Login(LoginRequest loginRequest);
	}
}
