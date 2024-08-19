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

        public string TargetLanguage { get => _targetLanguage; }
        public string SourceLanguage { get => _sourceLanguage; }
        public string Token { get => _token; }

        public void SetService(string serviceType)
        {
            _currentService = TranslateServiceStrategyFactory.CreateStrategy(serviceType, _token);
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
