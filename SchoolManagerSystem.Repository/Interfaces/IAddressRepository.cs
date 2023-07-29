using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Model.Entities;

namespace SchoolManagerSystem.Repository.Interfaces
{
	public interface IAddressRepository
	{
		Address CreateAddress(UserRegistrationRequest userRequest);
	}
}
