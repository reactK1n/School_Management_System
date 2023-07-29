using SchoolManagerSystem.Model.Entities;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Repository.Interfaces
{
    public interface IPrincipalRepository
    {
        Principal CreatePrincipal(string userId, string addressId);
    }
}