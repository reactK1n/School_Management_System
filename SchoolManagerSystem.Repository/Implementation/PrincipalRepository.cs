using Microsoft.EntityFrameworkCore;
using SchoolManagerSystem.Data;
using SchoolManagerSystem.Model.Entities;
using SchoolManagerSystem.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Repository.Implementation
{
	public class PrincipalRepository : GenericRepository<Principal>, IPrincipalRepository
	{
		private readonly DbSet<Principal> _dbSet;

		public PrincipalRepository(SMSContext context) : base(context)
		{
			_dbSet = context.Set<Principal>();
		}

		public Principal CreatePrincipal(string userId, string addressId)
		{
			var principal = new Principal
			{
				UserId = userId,
				AddressId = addressId
			};

			_dbSet.Add(principal);
			return principal;
		}

		public ICollection<Principal> FetchPrincipals()
		{
			return _dbSet.ToList();
		}

		public async Task<Principal> GetPrincipalAsync(string userId)
		{
			var user = await _dbSet.FirstOrDefaultAsync(x => x.UserId == userId);
			return user;
		}

		public async Task UpdatePrincipal(Principal principal)
		{
			_dbSet.Update(principal);
		}

		public async Task DeletePrincipalAsync(Principal principal)
		{
			_dbSet.Remove(principal);
		}
	}
}
