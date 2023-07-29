using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Repository.Interfaces
{
	public interface IAddressRepository
	{
		Address CreateAddress(UserRegistrationRequest userAddress);
	}
}
