using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace SchoolManagerSystem.Data.SeederClass
{
	public static class Seeder
	{

		public static void seed(this IApplicationBuilder app)
		{
			var serviceScope = app.ApplicationServices.CreateScope();
			Seeding(serviceScope.ServiceProvider.GetRequiredService<SMSContext>());
		}

		private static void Seeding(SMSContext smsContext)
		{

/*			string jsonString = File.ReadAllText("myData.json");

			var categories = JsonConvert.DeserializeObject<List<Category>>(jsonString);
			foreach (var myCategory in categories)
			{
				smsContext.Add(myCategory);
			}
			smsContext.SaveChanges();*/

		}
	}
}
