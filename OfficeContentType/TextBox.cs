using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using OfficeContentType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splus_Extras.OfficeContentType
{
    public class TextBox: OfficePhrase
    {
        private readonly List<TextRange2> _listTextBoxRanges;

        public TextBox(Worksheet activeSheet)
        {
            _listTextBoxRanges = activeSheet.Shapes.Cast<Microsoft.Office.Interop.Excel.Shape>()
                //.SelectMany(s => GetShapesRecursively(s))
                .Select(s => s.TextFrame2.TextRange)
                .Where(range => !string.IsNullOrWhiteSpace(range.Text))
                .ToList();
        }

        //private IEnumerable<Microsoft.Office.Interop.Excel.Shape> GetShapesRecursively(Microsoft.Office.Interop.Excel.Shape shape)
        //{
        //    if (shape.GroupItems.Count > 0)
        //    {
        //        return shape.GroupItems.Cast<Microsoft.Office.Interop.Excel.Shape>().SelectMany(GetShapesRecursively);
        //    }
        //    return new[] { shape };
        //}

        ////public Cell(Worksheet activeSheet, Range range)
        ////{

        ////}


        public override async void TranslateAndReplace()
        {
            List<string> listTexts = new List<string>();

            foreach (var textBox in _listTextBoxRanges)
            {
                listTexts.Add(textBox.Text.Replace("\n", " \n "));
            }

            List<string> listTranslatedTexts = await _translator.Translate(listTexts);

            for (int i = _listTextBoxRanges.Count - 1; i >= 0; i--)
            {
                _listTextBoxRanges[i].Text = listTranslatedTexts[i].Replace(" \n ", "\n").Trim('\'');
            }
        }
    }
}
