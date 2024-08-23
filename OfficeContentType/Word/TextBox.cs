using Microsoft.Office.Core;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Splus_Extras.OfficeContentType.Word
{
    public class TextBox : OfficePhrase
    {
        private readonly List<Range> _listTextBoxRanges;

        public TextBox(Document activeDoc)
        {
            _listTextBoxRanges = activeDoc.Shapes.Cast<Microsoft.Office.Interop.Word.Shape>()
                                    .SelectMany(shape => GetAllShape(shape))
                                    .ToList();

            TextBox._listLength = _listTextBoxRanges.Count;
        }

        private IEnumerable<Range> GetAllShape(Microsoft.Office.Interop.Word.Shape shape)
        {
            if (shape.Type == Microsoft.Office.Core.MsoShapeType.msoGroup)
            {
                return shape.GroupItems.Cast<Microsoft.Office.Interop.Word.Shape>()
                    .Select(s => s.TextFrame.TextRange);
            }
            else if (shape.TextFrame.HasText != 0 || shape.Type == Microsoft.Office.Core.MsoShapeType.msoTextEffect)
            {
                return new[] { shape.TextFrame.TextRange };
            }
            else
            {
                return Enumerable.Empty<Range>();
            }
        }

        public override async System.Threading.Tasks.Task TranslateAndReplace()
        {
            List<string> listTexts = new List<string>();

            foreach (var textBox in _listTextBoxRanges)
            {
                listTexts.Add(textBox.Text.Replace("\n", " \n "));
            }

            List<string> listTranslatedTexts = await _translator.Translate(listTexts);

            for (int i = _listTextBoxRanges.Count - 1; i >= 0; i--)
            {
                _listTextBoxRanges[i].Text = listTranslatedTexts[i];
            }
        }
    }
}
