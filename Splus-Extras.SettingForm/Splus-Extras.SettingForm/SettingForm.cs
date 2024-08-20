using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Splus_Extras.Translator;

namespace Splus_Extras.SettingForm
{
    public partial class SettingForm : Form
    {
        private TranslationServiceSingleton _translationService;

        public SettingForm()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;

        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            _translationService = TranslationServiceSingleton.Instance;

            LimitWordTextbox.Text = "1000";
            SourceLanguageComboBox.SelectedItem = _translationService.SourceLanguage;
            TargetLanguageComboBox.SelectedItem = _translationService.TargetLanguage;
            TranslatorComboBox.SelectedItem = _translationService.TranslateService;
            TokenTextBox.Text = _translationService.Token;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            string sourceLanguage = this.SourceLanguageComboBox.SelectedItem.ToString();
            string targetLanguage = this.TargetLanguageComboBox.SelectedItem.ToString();
            string token = this.TokenTextBox.Text;
            string translateService = this.TranslatorComboBox.SelectedItem.ToString();
            _translationService.SaveSetting(sourceLanguage, targetLanguage, token);
            _translationService.SetService(translateService);
        }

        private void LimitWordTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits, decimal point, and control characters
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
    }
}
