using SchoolManagerSystem.Model.Entities;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Authentications.Interfaces
{
    public interface ITokenService
    {
        Task<string> GetToken(ApplicationUser user);
    }
}
