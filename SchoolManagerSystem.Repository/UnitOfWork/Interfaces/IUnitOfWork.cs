using SchoolManagerSystem.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Repository.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPrincipalRepository Principal { get; }

        IAddressRepository Address { get; }

        Task SaveChangesAsync();
    }
}