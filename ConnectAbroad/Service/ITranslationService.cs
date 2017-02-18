using System;
using System.Threading.Tasks;

namespace ConnectAbroad
{
	public interface ITranslationService
	{
		Task<string> TranslateText(string TextToTranslate, string LanguageCode = LanguageCodes.French);
	}
}
