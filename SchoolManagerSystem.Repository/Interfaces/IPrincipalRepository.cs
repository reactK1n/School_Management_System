﻿using SchoolManagerSystem.Model.Entities;

namespace SchoolManagerSystem.Repository.Interfaces
{
	public interface IPrincipalRepository
	{
		Principal CreatePrincipal(string userId, string addressId);
	}
}