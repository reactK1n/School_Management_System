using Microsoft.EntityFrameworkCore;
using SchoolManagerSystem.Data;
using SchoolManagerSystem.Model.Entities;
using SchoolManagerSystem.Repository.Interfaces;
using System;

namespace SchoolManagerSystem.Repository.Implementation
{
	public class AddressRepository : GenericRepository<Address>, IAddressRepository
	{
		private readonly DbSet<Address> _dbSet;

		public AddressRepository(SMSContext context) : base(context)
		{
			_dbSet = context.Set<Address>();
		}

		public Address CreateAddress(Address address)
		{
			var userAddress = new Address
			{
				Id = Guid.NewGuid().ToString(),
				City = address.City,
				State = address.State,
			};
			_dbSet.Add(userAddress);

			return userAddress;
		}

	}
}
