using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Splus_Extras.Translator;

namespace OfficeContentType
{
    public abstract class OfficePhrase
    {
        public TranslationServiceSingleton _translator;

        public OfficePhrase()
        {
            _translator = TranslationServiceSingleton.Instance;
        }

        public abstract Task TranslateAndReplace();
    }
}
