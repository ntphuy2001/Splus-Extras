using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Splus_Extras.SettingForm;
using Splus_Extras.Translator;
using Splus_Extras.OfficeContentType;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace Splus_Extras.EXCEL
{
    public partial class SplusExtras
    {
        private TranslationServiceSingleton _translationService;
        private SettingForm.SettingForm _settingForm;

        private void SplusExtras_Load(object sender, RibbonUIEventArgs e)
        {
            _translationService = TranslationServiceSingleton.Instance;
            _translationService.SaveSetting("English", "Japanese", "");
            _translationService.SetService("chatgpt");
            _settingForm = new SettingForm.SettingForm();
        }

        private void BookButton_Click(object sender, RibbonControlEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = Globals.ThisAddIn.Application;
            Workbook activeWorkbook = excelApp.ActiveWorkbook;
            Worksheet activeSheet = activeWorkbook.ActiveSheet;
            OfficeContentType.TextBox textBox = new OfficeContentType.TextBox(activeSheet);
            textBox.TranslateAndReplace();
        }

        private void SheetButton_Click(object sender, RibbonControlEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = Globals.ThisAddIn.Application;
            Workbook activeWorkbook = excelApp.ActiveWorkbook;
            Worksheet activeSheet = activeWorkbook.ActiveSheet;

            Cell cell = new Cell(activeSheet);
            cell.TranslateAndReplace();

            OfficeContentType.TextBox textBox = new OfficeContentType.TextBox(activeSheet);
            textBox.TranslateAndReplace();

            SheetName sheetName = new SheetName(activeSheet);
            sheetName.TranslateAndReplace();
        }

        private void SelectionButton_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void SettingButton_Click(object sender, RibbonControlEventArgs e)
        {
            _settingForm.StartPosition = FormStartPosition.CenterParent;
            _settingForm.ShowDialog();
        }
    }
}
