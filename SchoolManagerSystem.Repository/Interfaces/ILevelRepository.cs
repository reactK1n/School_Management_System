using SchoolManagerSystem.Model.Entities;
using System.Threading.Tasks;

namespace SchoolManagerSystem.Repository.Interfaces
{
	public interface ILevelRepository
	{
		Task<Level> FetchLevelAsync(string levelId);
	}
}
