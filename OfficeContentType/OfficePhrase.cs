using System.Threading.Tasks;
using Splus_Extras.Translator;

namespace OfficeContentType
{
    public abstract class OfficePhrase
    {
        public TranslationServiceSingleton _translator;
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
