using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Splus_Extras.Translator
{
    public class TranslationServiceSingleton
    {
        private static readonly Lazy<TranslationServiceSingleton> lazy =
            new Lazy<TranslationServiceSingleton>(() => new TranslationServiceSingleton());

        public static TranslationServiceSingleton Instance { get { return lazy.Value; } }

        private ITranslationService _currentService;
        private string _sourceLanguage;
        private string _targetLanguage;
        private string _token;
        private List<string> _errors = new List<string>();

        public string TargetLanguage { get => _targetLanguage; }
        public string SourceLanguage { get => _sourceLanguage; }
        public List<string> Errors { get => _errors; }
        public string TranslateService
        {
            get 
            {
                switch (_currentService.GetType().Name)
                {
                    case "ChatGPT":
                        return "ChatGPT";
                    case "DeepL":
                        return "ChatGPT";
                    case "GGTranslate":
                        return "Google Translate";
                    default:
                        return "";
                }
            }
        }

        public string Token { get => _token; }

        public void ResetError()
        {
            _errors = new List<string>();
        }
        public void AddError(string mess)
        {
            _errors.Add(mess);
        }

        public void SetService(string serviceType)
        {
            _currentService = TranslateServiceStrategyFactory.CreateStrategy(serviceType);
        }

        public void SaveSetting(string sourceLanguage, string targetLanguage, string token)
        {
            _sourceLanguage = sourceLanguage;
            _targetLanguage = targetLanguage;
            _token = token;
        }

        public async Task<List<string>> Translate(List<string> listResources)
        {
            return await _currentService.Translate(listResources);
        }
    }
}
