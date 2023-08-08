using SchoolManagerSystem.Common.DTOs;
using SchoolManagerSystem.Model.Entities;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Repository.Interfaces
{
	public interface IAddressRepository
	{
		Address CreateAddress(UserRegistrationRequest userRequest);

		Task<Address> FetchAddressAsync(string addressId);

		Task UpdateAddressAsync(Address address);

		Task DeleteAddressAsync(Address address);
	}
}
