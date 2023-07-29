using SchoolManagerSystem.Repository.Interfaces;
using System;

namespace SchoolManagerSystem.Repository.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPrincipalRepository Principal { get; }

        IAddressRepository Address { get; }
    }
}