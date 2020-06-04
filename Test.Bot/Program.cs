using Microsoft.Extensions.DependencyInjection;
using Test.Bot.Service.Contracts;

namespace Test.Bot
{
	public static class Program
	{
		/// <summary>
		/// Defines the entry point of the application.
		/// </summary>
		/// <param name="args">The arguments.</param>
		static void Main(string[] args)
		{
			var ServiceProvider = new Startup().ConfigureServices();
			ServiceProvider.GetService<IBotService>().Execute();
		}
	}
}
