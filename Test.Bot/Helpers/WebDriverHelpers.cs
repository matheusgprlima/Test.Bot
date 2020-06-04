using System;
using IA.Framework.Selenium.Interfaces;
using Test.Bot.Settings.Contracts;
using EnumTypeBy = IA.Framework.Selenium.Enum.EnumTypeBy;

namespace Test.Bot.Helpers
{
	/// <seealso cref="System.IDisposable" />
	public abstract class WebDriverHelpers : IDisposable
	{
		/// <summary>
		/// The web driver
		/// </summary>
		private readonly ISeleniumHelper _webDriver;

		/// <summary>
		/// Initializes a new instance of the <see cref="WebDriverHelpers" /> class.
		/// </summary>
		/// <param name="webSettings">The web settings.</param>
		/// <param name="seleniumHelperFactory">The selenium helper factory.</param>
		protected WebDriverHelpers(IWebSettings webSettings, ISeleniumHelperFactory seleniumHelperFactory)
		{
			_webDriver = seleniumHelperFactory.CreateChrome(10, null, null, webSettings.CrxPath, null);

		}
		/// <summary>
		/// Goes to URL.
		/// </summary>
		/// <param name="url">The URL.</param>
		protected void GoToUrl(string url)
		{

			_webDriver.NavigateUrl(url);
		}
		/// <summary>
		/// Clicks the specified identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="enumType">Type of the enum.</param>
		protected void Click(string id, EnumTypeBy enumType)
		{
			_webDriver.ClickItem(id, enumType);
		}
		/// <summary>
		/// Clicks the and wait.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="enumType">Type of the enum.</param>
		protected void ClickAndWait(string id, EnumTypeBy enumType)
		{
			_webDriver.ElementExistClickable(id, enumType, 10);
		}

		/// <summary>
		/// Switches the parent frame.
		/// </summary>
		protected void SwitchParentFrame()
		{
			_webDriver.SwitchToParentFrame();
		}

		/// <summary>
		/// Fills the text by identifier.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="valor">The valor.</param>
		protected void FillTextById(string id, string valor)
		{
			_webDriver.ClearText(id, EnumTypeBy.ById);
			_webDriver.WriteText(id, valor, EnumTypeBy.ById);
		}
		/// <summary>
		/// Switches to frame.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="enumTypeBy">The enum type by.</param>
		protected void SwitchToFrame(string id, EnumTypeBy enumTypeBy)
		{
			_webDriver.SwitchToFrame(id, enumTypeBy);
		}
		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources.
		/// </summary>
		/// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				_webDriver.Dispose();
			}
		}
	}

}
