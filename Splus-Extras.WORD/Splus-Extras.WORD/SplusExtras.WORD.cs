using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Splus_Extras.Translator;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.Runtime.Remoting.Messaging;
using Splus_Extras.OfficeContentType.Word;
using Microsoft.Office.Core;

namespace Splus_Extras.WORD
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

        private void SettingButton_Click(object sender, RibbonControlEventArgs e)
        {
            _settingForm.StartPosition = FormStartPosition.CenterParent;
            _settingForm.ShowDialog();
        }

        private async void DocButton_Click(object sender, RibbonControlEventArgs e)
        {
            Document activeDoc = Globals.ThisAddIn.Application.ActiveDocument;

            await TranslateDocument(activeDoc);
        }

        private async System.Threading.Tasks.Task TranslateDocument(Document activeDoc)
        {
            OfficeContentType.Word.MainDoc mainDoc = new OfficeContentType.Word.MainDoc(activeDoc);
            OfficeContentType.Word.TextBox textBox = new OfficeContentType.Word.TextBox(activeDoc);
            OfficeContentType.Word.SmartArt smartArt = new OfficeContentType.Word.SmartArt(activeDoc);
            OfficeContentType.Word.Table table = new OfficeContentType.Word.Table(activeDoc);

            await System.Threading.Tasks.Task.WhenAll(mainDoc.RunTask(), textBox.RunTask(), smartArt.RunTask(), table.RunTask());
        }
    }
}
