using SchoolManagerSystem.Model.Entities;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Authentications.Interfaces
{
    public interface IToken
    {
        Task<string> GetToken(ApplicationUser user);
    }
}
