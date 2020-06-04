using IA.Framework.Selenium.Enum;
using IA.Framework.Selenium.Interfaces;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Test.Bot.Exceptions;
using Test.Bot.Helpers;
using Test.Bot.Service.Contracts;
using Test.Bot.Settings.Contracts;


namespace Test.Bot.Service.Impl
{

	/// <seealso cref="Test.Bot.Helpers.WebDriverHelpers" />
	/// <seealso cref="Test.Bot.Service.Contracts.IBotService" />
	public class BotService : WebDriverHelpers, IBotService
	{
		/// <summary>
		/// The web driver settings
		/// </summary>
		private readonly IWebSettings _webDriverSettings;

		/// <summary>
		/// The methods inputs
		/// </summary>
		private readonly Dictionary<string, string> _methodsInputs = new Dictionary<string, string>
		{
			["Digite_Chave_Id"] = "chave",
			["Tipo_Chave_Id"] = "cte",
			["Digite_Chave_Value"] = "35200260319985000144570010000445011000445011",
			["Botão_Consulta_Id"] = "butconsulta",
			["Recaptcha"] = "recaptcha-checkbox-borderAnimation",
			["Recaptcha_Iframe"] = "ReCaptcha",
			["Download_Xml"] = "linksemcert"
		};

		/// <summary>
		/// Initializes a new instance of the <see cref="BotService" /> class.
		/// </summary>
		/// <param name="webDriverSettings">The web driver settings.</param>
		/// <param name="seleniumHelperFactory">The selenium helper factory.</param>
		public BotService(IWebSettings webDriverSettings, ISeleniumHelperFactory seleniumHelperFactory) : base(webDriverSettings,  seleniumHelperFactory)
		{
			_webDriverSettings = webDriverSettings;

		}
		/// <summary>
		/// Executes this instance.
		/// </summary>
		/// <exception cref="Test.Bot.Exceptions.BotException"></exception>
		/// <exception cref="BotException"></exception>
		public void Execute()
		{

			try
			{

				//Navega para o site desejado.
				GoToUrl(_webDriverSettings.FsistUrl);

				//Seleciona Tipo de Chave.
				Click(
					id: _methodsInputs["Tipo_Chave_Id"],
					enumType: EnumTypeBy.ById);

				//Preenche o campo de consulta da CTe 
				FillTextById(
					id: _methodsInputs["Digite_Chave_Id"],
					valor: _methodsInputs["Digite_Chave_Value"]);

				//Clica em consultar nota.
				Click(
					id: _methodsInputs["Botão_Consulta_Id"],
					enumType: EnumTypeBy.ById);

				//Muda para o Iframe do Recaptcha.
				SwitchToFrame(
					id: _methodsInputs["Recaptcha_Iframe"], 
					enumTypeBy: EnumTypeBy.ById);
				//Passa pelo recaptcha.
				Click(
					id: _methodsInputs["Recaptcha"],
					enumType: EnumTypeBy.ByClassName);

				//Volta para o parent Frame.
				SwitchParentFrame();

				//Clica em consultar nota.
				ClickDonwloadXml(
					id: _methodsInputs["Download_Xml"],
					enumType: EnumTypeBy.ById);
			}

			catch (BotException ex)
			{
				throw new BotException(ex.Message);
			}

		}

		/// <summary>
		/// Clicks the donwload XML.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="enumType">Type of the enum.</param>
		public void ClickDonwloadXml(string id, EnumTypeBy enumType)
		{
			SwitchToFrame(id, enumType);
			ClickAndWait(
					id: _methodsInputs["Download_Xml"],
					enumType: EnumTypeBy.ById);
		}

	}
}
