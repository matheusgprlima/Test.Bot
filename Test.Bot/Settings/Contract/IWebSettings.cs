namespace Test.Bot.Settings.Contracts
{
	public interface IWebSettings
	{
		/// <summary>
		/// Gets or sets the web drivers.
		/// </summary>
		/// <value>
		/// The web drivers.
		/// </value>
		string WebDrivers { get; set; }

		/// <summary>
		/// Gets or sets the fsist URL.
		/// </summary>
		/// <value>
		/// The fsist URL.
		/// </value>
		string FsistUrl { get; set; }

		/// <summary>
		/// Gets or sets the CRX path.
		/// </summary>
		/// <value>
		/// The CRX path.
		/// </value>
		string CrxPath { get; set; }
	}
}

