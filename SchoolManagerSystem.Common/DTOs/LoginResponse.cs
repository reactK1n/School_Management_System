﻿using System.Security.Principal;

namespace SchoolManagerSystem.Common.DTOs
{
	public class LoginResponse
	{
        public string Id { get; set; }
        public string FirstName { get; set; }
		public string LastName { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
        public string Token { get; set; }
    }
}
