using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Splus_Extras.OfficeContentType.Excel
{
    public class TextBox: OfficePhrase
    {
        private readonly List<TextRange2> _listTextBoxRanges = new List<TextRange2>();

        public TextBox(Worksheet activeSheet)
        {
            _listTextBoxRanges = activeSheet.Shapes.Cast<Microsoft.Office.Interop.Excel.Shape>()
                .SelectMany(s => GetGroupItemShapes(s))
                .Where(s => s.HasText == MsoTriState.msoTrue && !string.IsNullOrWhiteSpace(s.TextRange.Text))
                .Select(s => s.TextRange)
                .ToList();
            TextBox._listLength = _listTextBoxRanges.Count;
        }

        private IEnumerable<Microsoft.Office.Interop.Excel.TextFrame2> GetGroupItemShapes(Microsoft.Office.Interop.Excel.Shape shape)
        {
            if (shape.Type == MsoShapeType.msoGroup || shape.Type == MsoShapeType.msoSmartArt)
            {
                return shape.GroupItems.Cast<Microsoft.Office.Interop.Excel.Shape>()
                .SelectMany(s => GetGroupItemShapes(s) );
            } else
            {
                return  new[] { shape.TextFrame2 };
            }
        }

        ////public Cell(Worksheet activeSheet, Range range)
        ////{

        ////}


        public override async Task TranslateAndReplace()
        {
            List<string> listTexts = new List<string>();

            foreach (var textBox in _listTextBoxRanges)
            {
                listTexts.Add(textBox.Text.Replace("\n", " \n "));
            }

            List<string> listTranslatedTexts = await _translator.Translate(listTexts);

            for (int i = _listTextBoxRanges.Count - 1; i >= 0; i--)
            {
                _listTextBoxRanges[i].Text = listTranslatedTexts[i].Replace(" \n ", "\n");
            }
        }
    }
}
