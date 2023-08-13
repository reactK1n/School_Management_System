using System.Text.RegularExpressions;

namespace SchoolManagerSystem.Common
{
	public static class Helper
	{
		public static bool IsCourseNameValid(string courseName)
		{
			string pattern = @"^[A-Za-z]{3}\d{3}$";
			Regex regex = new Regex(pattern);
			return regex.IsMatch(courseName);
		}
	}
}
