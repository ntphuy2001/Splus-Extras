using System.Threading.Tasks;
using Splus_Extras.Translator;

namespace Splus_Extras.OfficeContentType
{
    public abstract class OfficePhrase
    {
        protected TranslationServiceSingleton _translator;
        public static int _listLength;

        public OfficePhrase()
        {
            _translator = TranslationServiceSingleton.Instance;
        }

        public async Task RunTask ()
        {
            if (_listLength > 0)
            {
                await TranslateAndReplace();
            }
            _translator.AddError("Please!!!");
        }

        public abstract Task TranslateAndReplace();
    }
}
