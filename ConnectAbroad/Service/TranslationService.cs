using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ConnectAbroad;
using Newtonsoft.Json;
using Xamarin.Forms;

[assembly: Dependency(typeof(TranslationService))]
namespace ConnectAbroad
{
	public class TranslationService:ITranslationService
	{
		IAuthenticationService authService;

		public TranslationService(IAuthenticationService authService)
		{
			this.authService = authService;
		}

		public async Task<string> TranslateText(string TextToTranslate, string LanguageCode = LanguageCodes.Hindi)
		{
			await this.authService.InitializeAsync();
			var token =  this.authService.GetAccessToken();

			string uri = "http://api.microsofttranslator.com";

			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(uri);
				client.DefaultRequestHeaders.Accept.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				// Add the Authorization header with the AccessToken.
				client.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer", token);;

				// create the URL string.
				string url = string.Format("v2/Http.svc/Translate?text={0}&to={1}", TextToTranslate, LanguageCode);

				// make the request
				HttpResponseMessage response = await client.GetAsync(url);

				// parse the response and return the data.
				string jsonString = await response.Content.ReadAsStringAsync();

				System.Xml.Linq.XDocument xTranslation = System.Xml.Linq.XDocument.Parse(jsonString);

				var translatedString = xTranslation.Root.Value;

				return translatedString;
			}


		}
	}
}
