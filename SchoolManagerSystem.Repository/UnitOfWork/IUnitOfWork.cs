using SchoolManagerSystem.Repository.Interfaces;
using System;

namespace SchoolManagerSystem.Repository.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IPrincipalRepository Principal { get; }
    }
}