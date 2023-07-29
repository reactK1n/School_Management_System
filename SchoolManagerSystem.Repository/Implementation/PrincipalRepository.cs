using Microsoft.EntityFrameworkCore;
using SchoolManagerSystem.Data;
using SchoolManagerSystem.Model.Entities;
using SchoolManagerSystem.Repository.Interfaces;

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
    }
}
