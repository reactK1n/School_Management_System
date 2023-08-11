using SchoolManagerSystem.Service.Validations.Interfaces;
using System.Text.RegularExpressions;

namespace SchoolManagerSystem.Service.Validations.Implementations
{
	public class RequestValidations : IRequestValidations
	{
		public bool IsCourseNameValid(string courseName)
		{
			string pattern = @"^[A-Za-z]{3}\d{3}$";
			Regex regex = new Regex(pattern);
			return regex.IsMatch(courseName);
		}
	}
}
