using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;
using System.Collections.Generic;
using System.Linq;

namespace Splus_Extras.OfficeContentType.PPT
{
    public class Table : OfficePhrase
    {
        private readonly List<TextRange> _tableTexts;
        public Table(Slide activeSlide)
        {
            _tableTexts = activeSlide.Shapes.Cast<Microsoft.Office.Interop.PowerPoint.Shape>()
                .Where(shape => shape.HasTable == MsoTriState.msoTrue)
                .SelectMany(shape => GetTableContent(shape.Table))
                .ToList();

            Table._listLength = _tableTexts.Count;
        }

        private IEnumerable<TextRange> GetTableContent(Microsoft.Office.Interop.PowerPoint.Table table)
        {
            return Enumerable.Range(1, table.Rows.Count)
                .SelectMany(row => Enumerable.Range(1, table.Columns.Count)
                .Select(col => table.Cell(row, col).Shape.TextFrame.TextRange))
                .Where(range => !string.IsNullOrWhiteSpace(range.Text));
        }

        public async override System.Threading.Tasks.Task TranslateAndReplace()
        {
            List<string> listTexts = new List<string>();

            foreach (var textBox in _tableTexts)
            {
                listTexts.Add(textBox.Text.Replace("\n", " \n "));
            }

            List<string> listTranslatedTexts = await _translator.Translate(listTexts);

            for (int i = _tableTexts.Count - 1; i >= 0; i--)
            {
                _tableTexts[i].Text = listTranslatedTexts[i];
            }
        }
    }
}
