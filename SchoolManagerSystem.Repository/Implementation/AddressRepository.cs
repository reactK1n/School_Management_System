using Microsoft.EntityFrameworkCore;
using SchoolManagerSystem.Common.DTOs;
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

		public Address CreateAddress(UserRegistrationRequest userRequest)
		{
			var userAddress = new Address
			{
				Id = Guid.NewGuid().ToString(),
				City = userRequest.City,
				State = userRequest.State,
			};
			_dbSet.Add(userAddress);
			

			return userAddress;
		}

	}
}
