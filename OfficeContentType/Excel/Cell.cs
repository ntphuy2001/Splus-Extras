using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;


namespace Splus_Extras.OfficeContentType.Excel
{
    public class Cell: OfficePhrase
    {
        private readonly List<Range> _listCellRanges = new List<Range>();

        public Cell(Worksheet activeSheet)
        {
            Range usedRange = activeSheet.UsedRange;

            _listCellRanges = usedRange.Cells.Cast<Range>()
                                    .Where(cell => cell.Value != null)
                                    .ToList();
            Cell._listLength = _listCellRanges.Count;
        }

        ////public Cell(Worksheet activeSheet, Range range)
        ////{

        ////}


        public override async Task TranslateAndReplace()
        {
            List<string> listTexts = new List<string>();

            foreach (var cell in _listCellRanges)
            {
                listTexts.Add(cell.Value.ToString());
            }

            List<string> listTranslatedTexts = await _translator.Translate(listTexts);

            for (int i = _listCellRanges.Count - 1; i >= 0; i--)
            {
                _listCellRanges[i].Value = listTranslatedTexts[i];
            }
        }
    }
}
