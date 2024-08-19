using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splus_Extras.Translator
{
    public class TranslateServiceStrategyFactory
    {
        public static ITranslationService CreateStrategy(string strategyType, string token)
        {
            switch (strategyType.ToLower())
            {
                case "chatgpt": return new ChatGPT(token);
                case "ggtranslate": return new GGTranslate();
                case "deepl": return new DeepL();
                default: throw new ArgumentException("Invalid strategy type");
            }
        }
    }
}
