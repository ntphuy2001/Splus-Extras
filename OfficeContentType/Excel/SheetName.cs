using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Splus_Extras.OfficeContentType.Excel
{
    public class SheetName: OfficePhrase
    {
        private readonly Worksheet _activeSheet;

        public SheetName(Worksheet activeSheet)
        {
            _activeSheet = activeSheet;
        }

        ////public Cell(Worksheet activeSheet, Range range)
        ////{

        ////}


        public override async Task TranslateAndReplace()
        {
            List<string> listTexts = new List<string> { _activeSheet.Name };
            List<string> listTranslatedTexts = await _translator.Translate(listTexts);
            _activeSheet.Name = listTranslatedTexts[0];
        }
    }
}
