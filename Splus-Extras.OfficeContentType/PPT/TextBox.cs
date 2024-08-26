using Microsoft.Office.Interop.PowerPoint;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Splus_Extras.OfficeContentType.PPT
{
    public class TextBox : OfficePhrase
    {
        private readonly List<TextRange> _listTextBoxRanges;

        public TextBox(Slide activeSlide)
        {
            _listTextBoxRanges = activeSlide.Shapes.Cast<Shape>()
                .SelectMany(shape => GetAllShape(shape))
                .Where(range => !string.IsNullOrWhiteSpace(range.Text))
                .ToList();

            TextBox._listLength = _listTextBoxRanges.Count;
        }

        private IEnumerable<TextRange> GetAllShape(Shape shape)
        {
            if (shape.Type == Microsoft.Office.Core.MsoShapeType.msoGroup || 
                shape.Type == Microsoft.Office.Core.MsoShapeType.msoSmartArt)
            {
                return shape.GroupItems.Cast<Shape>()
                    .Select(s => s.TextFrame.TextRange);
            }
            else if (shape.TextFrame.HasText != 0 || shape.Type == Microsoft.Office.Core.MsoShapeType.msoTextEffect)
            {
                return new[] { shape.TextFrame.TextRange };
            }
            else
            {
                return Enumerable.Empty<TextRange>();
            }
        }

        public async override Task TranslateAndReplace()
        {
            List<string> listTexts = new List<string>();

            foreach (var textBox in _listTextBoxRanges)
            {
                string resultText = Regex.Replace(textBox.Text, @"(\r|\a|\v|\n)", " $1 ");
                listTexts.Add(resultText);
            }

            List<string> listTranslatedTexts = await _translator.Translate(listTexts);

            for (int i = _listTextBoxRanges.Count - 1; i >= 0; i--)
            {
                _listTextBoxRanges[i].Text = listTranslatedTexts[i];
            }
        }
    }
}
