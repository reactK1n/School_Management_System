using SchoolManagerSystem.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Repository.Interfaces
{
	public interface IPrincipalRepository
	{
		Principal CreatePrincipal(string userId, string addressId);

		ICollection<Principal> FetchPrincipals();

		Task<Principal> GetPrincipalAsync(string userId);

		Task UpdatePrincipal(Principal principal);

		Task DeletePrincipalAsync(Principal principal);
	}
}