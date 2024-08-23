using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Splus_Extras.OfficeContentType.Word
{
    public class Table : OfficePhrase
    {
        private List<Range> _tableTexts;
        public Table(Document activeDoc) 
        {
            _tableTexts = activeDoc.Tables.Cast<Microsoft.Office.Interop.Word.Table>()
                .SelectMany(table => GetTableContent(table))
                .ToList();

            Table._listLength = _tableTexts.Count;
        }

        private IEnumerable<Range> GetTableContent(Microsoft.Office.Interop.Word.Table table)
        {
            return table.Rows.Cast<Row>()
                .SelectMany(row => row.Cells.Cast<Cell>()
                    .Select(cell => cell.Range)
                    .Where(range => !string.IsNullOrWhiteSpace(range.Text.TrimEnd('\a', '\r'))));
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
