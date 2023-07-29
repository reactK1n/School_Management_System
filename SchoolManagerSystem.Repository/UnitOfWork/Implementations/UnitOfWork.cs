using SchoolManagerSystem.Data;
using SchoolManagerSystem.Repository.Implementation;
using SchoolManagerSystem.Repository.Interfaces;
using SchoolManagerSystem.Repository.UnitOfWork.Interfaces;
using System;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Repository.UnitOfWork.Implementations
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly SMSContext _context;
		private IPrincipalRepository _principal;
		private IAddressRepository _address;

		public UnitOfWork(SMSContext context)
		{
			_context = context;
		}

		public IPrincipalRepository Principal
		{
			get => _principal ??= new PrincipalRepository(_context);
		}

		public IAddressRepository Address
		{
			get => _address ??= new AddressRepository(_context);
		}

		public async Task SaveChangesAsync()
		{
			await _context.SaveChangesAsync();
		}

		public void Dispose()
		{
			_context.Dispose();
			GC.SuppressFinalize(this);
		}
	}
}
