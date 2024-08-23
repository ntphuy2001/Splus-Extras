using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Splus_Extras.OfficeContentType.Word
{
    public class MainDoc : OfficePhrase
    {
        private readonly List<Range> _mainTexts;
        public MainDoc(Document currentDoc)
        {
            _mainTexts = currentDoc.Paragraphs.Cast<Paragraph>()
                .Select(p => p.Range)
                .Where(t => !string.IsNullOrWhiteSpace(t.Text.Trim('\a', '\r')))
                .ToList();

            MainDoc._listLength = _mainTexts.Count;
        }

        public override async System.Threading.Tasks.Task TranslateAndReplace()
        {
            List<string> listTexts = new List<string>();

            foreach (var textBox in _mainTexts)
            {
                listTexts.Add(textBox.Text.Replace("\n", " \n "));
            }

            List<string> listTranslatedTexts = await _translator.Translate(listTexts);


            for (int i = _mainTexts.Count - 1; i >= 0; i--)
            {
                if (_mainTexts[i].ShapeRange.Count > 0) 
                {
                    FindAndReplace(_mainTexts[i], _mainTexts[i].Text, listTranslatedTexts[i] + Environment.NewLine);
                } else
                {
                    _mainTexts[i].Text = listTranslatedTexts[i] + Environment.NewLine;
                }
            }
        }

        private void FindAndReplace(Range range, object ToFindText, object replaceWithText)
        {

            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllforms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            range.Find.Execute(ref ToFindText,
               ref matchCase, ref matchWholeWord,
               ref matchWildCards, ref matchSoundLike,
               ref nmatchAllforms, ref forward,
               ref wrap, ref format, ref replaceWithText,
               ref replace, ref matchKashida,
               ref matchDiactitics, ref matchAlefHamza,
               ref matchControl);
        }
    }
}
