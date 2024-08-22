using Microsoft.Office.Tools.Ribbon;
using Splus_Extras.Translator;
using Splus_Extras.OfficeContentType.Excel;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Threading.Tasks;

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

        private async void BookButton_Click(object sender, RibbonControlEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = Globals.ThisAddIn.Application;
            Workbook activeWorkbook = excelApp.ActiveWorkbook;

            var sheets = activeWorkbook.Sheets;

            var tasks = new Task[sheets.Count];

            for(int i = 0; i < tasks.Length; i++)
            {
                var selectedSheet = sheets[i + 1];

                tasks[i] = Task.Run(() => TranslateSheet(selectedSheet));
            }

            await Task.WhenAll(tasks);
        }

        private async void SheetButton_Click(object sender, RibbonControlEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Microsoft.Office.Interop.Excel.Application excelApp = Globals.ThisAddIn.Application;
            Workbook activeWorkbook = excelApp.ActiveWorkbook;
            Worksheet activeSheet = activeWorkbook.ActiveSheet;

            await TranslateSheet(activeSheet);
        }

        private void SelectionButton_Click(object sender, RibbonControlEventArgs e)
        {

        }

        private void SettingButton_Click(object sender, RibbonControlEventArgs e)
        {
            _settingForm.StartPosition = FormStartPosition.CenterParent;
            _settingForm.ShowDialog();
        }

        private async Task TranslateSheet(Worksheet selectedSheet)
        {
            OfficeContentType.Excel.Cell cell = new OfficeContentType.Excel.Cell(selectedSheet);
            OfficeContentType.Excel.TextBox textBox = new OfficeContentType.Excel.TextBox(selectedSheet);
            OfficeContentType.Excel.SheetName sheetName = new OfficeContentType.Excel.SheetName(selectedSheet);

            await Task.WhenAll(cell.RunTask(), textBox.RunTask(), sheetName.RunTask());
        }
    }
}
