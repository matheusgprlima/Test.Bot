using Newtonsoft.Json;
using System;
using Test.Bot.Settings.Contracts;

namespace Test.Bot.Settings.Impl
{

	/// <seealso cref="Teste.Bot.Settings.Contracts.IWebDriverSettings" />
	[Serializable]
	public class WebSettings : IWebSettings
	{
		/// <summary>
		/// Gets the key.
		/// </summary>
		/// <value>
		/// The key.
		/// </value>
		public static string Key { get => "webDriverSettings"; }

		/// <summary>
		/// Gets or sets the web drivers.
		/// </summary>
		/// <value>
		/// The web drivers.
		/// </value>
		[JsonProperty("webDrivers")]
		public string WebDrivers { get; set; }

		/// <summary>
		/// Gets or sets the fsist URL.
		/// </summary>
		/// <value>
		/// The fsist URL.
		/// </value>
		[JsonProperty("fsistUrl")]
		public string FsistUrl { get; set; }


		/// <summary>
		/// Gets or sets the CRX path.
		/// </summary>
		/// <value>
		/// The CRX path.
		/// </value>
		[JsonProperty("crxPath")]
		public string CrxPath { get; set; }


	}
}
