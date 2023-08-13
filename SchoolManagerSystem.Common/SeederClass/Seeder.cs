using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SchoolManagerSystem.Model.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SchoolManagerSystem.Data.SeederClass
{
	public static class Seeder
	{
		public static void seedData(this IApplicationBuilder app)
		{
			var serviceScope = app.ApplicationServices.CreateScope();
			Seeding(serviceScope.ServiceProvider.GetRequiredService<SMSContext>());
		}

		private static void Seeding(SMSContext smsContext)
		{

			string jsonString = File.ReadAllText(@"C:\Users\User\Desktop\Repos\SchoolManagerSystem\SchoolManagerSystem.Common\JsonFiles\seeder.json");

			var levels = JsonConvert.DeserializeObject<List<Level>>(jsonString);
			foreach (var level in levels)
			{
				if (!smsContext.Levels.Any(lev => lev.LevelName == level.LevelName))
				{
					smsContext.Add(level);
				}
			}
			smsContext.SaveChanges();
		}
	}
}
