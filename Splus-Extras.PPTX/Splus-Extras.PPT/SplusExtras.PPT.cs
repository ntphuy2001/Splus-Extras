using Microsoft.Office.Interop.PowerPoint;
using Microsoft.Office.Tools.Ribbon;
using Splus_Extras.SettingForm;
using Splus_Extras.Translator;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Splus_Extras.PPT
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

        private async void PresentationButton_Click(object sender, RibbonControlEventArgs e)
        {
            Presentation activePresentation = Globals.ThisAddIn.Application.ActivePresentation;
            Slides slides = activePresentation.Slides;


            var tasks = new Task[slides.Count];

            for (int i = 0; i < tasks.Length; i++)
            {
                var selectedSlide = slides[i + 1];

                tasks[i] = Task.Run(() => TranslateSlide(selectedSlide));
            }

            await Task.WhenAll(tasks);
        }

        private async void SlideButton_Click(object sender, RibbonControlEventArgs e)
        {
            int slideIndex = Globals.ThisAddIn.Application.ActiveWindow.View.Slide.SlideIndex;
            Presentation activePresentation = Globals.ThisAddIn.Application.ActivePresentation;
            Slide activeSlide = activePresentation.Slides[slideIndex];

            await TranslateSlide(activeSlide);
        }

        private void SettingButton_Click(object sender, RibbonControlEventArgs e)
        {
            _settingForm.StartPosition = FormStartPosition.CenterParent;
            _settingForm.ShowDialog();
        }

        private async Task TranslateSlide(Slide selectedSheet)
        {
            OfficeContentType.PPT.TextBox textBox = new OfficeContentType.PPT.TextBox(selectedSheet);
            OfficeContentType.PPT.Table table = new OfficeContentType.PPT.Table(selectedSheet);

            await Task.WhenAll(textBox.RunTask(), table.RunTask());
        }
    }
}
