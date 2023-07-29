using SchoolManagerSystem.Data;
using SchoolManagerSystem.Repository.Implementation;
using SchoolManagerSystem.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SMSContext _context;
        private IPrincipalRepository _principal;

        public UnitOfWork(SMSContext context)
        {
            _context = context;
        }

        public IPrincipalRepository Principal
        {
            get => _principal ??= new PrincipalRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
