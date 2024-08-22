using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Splus_Extras.Translator;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;

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
            Microsoft.Office.Interop.Word.Application wordlApp = Globals.ThisAddIn.Application;
            Document activeDoc = wordlApp.ActiveDocument;

            Splus_Extras.OfficeContentType.Word.MainDoc md = new Splus_Extras.OfficeContentType.Word.MainDoc(activeDoc);
            Splus_Extras.OfficeContentType.Word.TextBox tb = new Splus_Extras.OfficeContentType.Word.TextBox(activeDoc);
            Splus_Extras.OfficeContentType.Word.SmartArt sa = new Splus_Extras.OfficeContentType.Word.SmartArt(activeDoc);
            await md.TranslateAndReplace();
            await tb.TranslateAndReplace();
            await sa.TranslateAndReplace();
        }
    }
}
