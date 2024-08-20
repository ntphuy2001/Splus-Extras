﻿using Microsoft.Office.Interop.Excel;
using OfficeContentType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splus_Extras.OfficeContentType
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
