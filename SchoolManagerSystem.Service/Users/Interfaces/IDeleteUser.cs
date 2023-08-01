using System.Threading.Tasks;

namespace SchoolManagerSystem.Service.Users.Interfaces
{
	public interface IDeleteUser
	{
		Task<string> DeleteUserAsync(string userId);
	}
}
