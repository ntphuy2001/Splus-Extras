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
            //this.MaximizeBox = false;
            //this.MinimizeBox = false;
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            _translationService = TranslationServiceSingleton.Instance;
            sourceLanguageComboBox.Text = _translationService.SourceLanguage;
            targetLanguageComboBox.Text = _translationService.TargetLanguage;
        }
    }
}
