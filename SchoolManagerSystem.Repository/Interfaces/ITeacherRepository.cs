using SchoolManagerSystem.Model.Entities;

namespace SchoolManagerSystem.Repository.Interfaces
{
	public interface ITeacherRepository
	{
		Teacher CreateTeacher(string userId, string addressId);
	}
}