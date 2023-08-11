using Microsoft.AspNetCore.Identity;
using SchoolManagerSystem.Model.Entities;
using SchoolManagerSystem.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Repository.UnitOfWork.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPrincipalRepository Principal { get; }

        IAddressRepository Address { get; }

		ITeacherRepository Teacher { get; }

		IStudentRepository Student { get; }

		ICourseRepository Course { get; }

		ILevelRepository Level { get; }

		Task SaveChangesAsync();
    }
}