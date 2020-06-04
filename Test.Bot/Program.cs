using Microsoft.Extensions.DependencyInjection;
using Test.Bot.Service.Contracts;

namespace Test.Bot
{
	public static class Program
	{
		static void Main(string[] args)
		{
			var ServiceProvider = new Startup().ConfigureServices();
			ServiceProvider.GetService<IBotService>().Execute();
		}
	}
}
