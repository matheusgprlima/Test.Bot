using IA.Framework.Selenium.Interfaces;
using IA.Framework.Selenium.Interfaces.Impl;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using Test.Bot.Service.Contracts;
using Test.Bot.Service.Impl;
using Test.Bot.Settings.Contracts;
using Test.Bot.Settings.Impl;


namespace Test.Bot
{
	public class Startup
	{
		/// <summary>
		/// The configuration
		/// </summary>
		private readonly IConfiguration _configuration;

		/// <summary>
		/// Initializes a new instance of the <see cref="Startup"/> class.
		/// </summary>
		public Startup()
		{
			_configuration = LoadConfiguration();
		}

		/// <summary>
		/// Configures the services.
		/// </summary>
		/// <returns></returns>
		public IServiceProvider ConfigureServices()
		{
			var services = new ServiceCollection()
							.Configure<WebSettings>(_configuration.GetSection(WebSettings.Key))
							.AddSingleton<IWebSettings>(sp => sp.GetRequiredService<IOptions<WebSettings>>().Value)
							.AddSingleton<ISeleniumHelperFactory,SeleniumHelperFactory>()
							.AddSingleton<IBotService, BotService>();


			return services.AddOptions().BuildServiceProvider();
		}


		/// <summary>
		/// Loads the configuration.
		/// </summary>
		/// <returns></returns>
		private static IConfigurationRoot LoadConfiguration()
		{
			return new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("Appsettings.json")
				.Build();

		}
	}
}
