using Microsoft.Office.Interop.Word;
using Microsoft.Office.Core;
using Splus_Extras.OfficeContentType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splus_Extras.OfficeContentType.Word
{
    public class SmartArt : OfficePhrase
    {
        private readonly List<TextRange2> _listSmartArtRanges;

        public SmartArt(Document activeDoc)
        {
            _listSmartArtRanges = activeDoc.InlineShapes.Cast<Microsoft.Office.Interop.Word.InlineShape>()
                                    .SelectMany(shape => GetAllSmartArtShape(shape))
                                    .Where(shape => shape.HasText != MsoTriState.msoFalse)
                                    .Select(shape => shape.TextRange)
                                    .ToList();
        }

        private IEnumerable<TextFrame2> GetAllSmartArtShape(Microsoft.Office.Interop.Word.InlineShape inlineShape)
        {
            if (inlineShape.Type == WdInlineShapeType.wdInlineShapeSmartArt)
            {
                return inlineShape.GroupItems.Cast<Microsoft.Office.Interop.Word.Shape>()
                    .Select(s => s.TextFrame2);
            }
            else
            {
                return Enumerable.Empty<TextFrame2>();
            }
        }

        public override async System.Threading.Tasks.Task TranslateAndReplace()
        {
            List<string> listTexts = new List<string>();

            foreach (var textBox in _listSmartArtRanges)
            {
                listTexts.Add(textBox.Text.Replace("\n", " \n "));
            }

            List<string> listTranslatedTexts = await _translator.Translate(listTexts);

            for (int i = _listSmartArtRanges.Count - 1; i >= 0; i--)
            {
                _listSmartArtRanges[i].Text = listTranslatedTexts[i];
            }
        }
    }
}
