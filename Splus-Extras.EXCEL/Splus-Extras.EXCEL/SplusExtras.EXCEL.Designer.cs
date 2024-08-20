namespace Splus_Extras.EXCEL
{
    partial class SplusExtras : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public SplusExtras()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplusExtras));
            this.TranslatorTab = this.Factory.CreateRibbonTab();
            this.TranslatorGroup = this.Factory.CreateRibbonGroup();
            this.translatorBox = this.Factory.CreateRibbonBox();
            this.BookButton = this.Factory.CreateRibbonButton();
            this.SheetButton = this.Factory.CreateRibbonButton();
            this.SelectionButton = this.Factory.CreateRibbonButton();
            this.BoxSeparator = this.Factory.CreateRibbonSeparator();
            this.settingBox = this.Factory.CreateRibbonBox();
            this.SettingButton = this.Factory.CreateRibbonButton();
            this.TranslatorTab.SuspendLayout();
            this.TranslatorGroup.SuspendLayout();
            this.translatorBox.SuspendLayout();
            this.settingBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // TranslatorTab
            // 
            this.TranslatorTab.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.TranslatorTab.Groups.Add(this.TranslatorGroup);
            this.TranslatorTab.Label = "Splus-Extras";
            this.TranslatorTab.Name = "TranslatorTab";
            // 
            // TranslatorGroup
            // 
            this.TranslatorGroup.Items.Add(this.translatorBox);
            this.TranslatorGroup.Items.Add(this.BoxSeparator);
            this.TranslatorGroup.Items.Add(this.settingBox);
            this.TranslatorGroup.Label = "Translator";
            this.TranslatorGroup.Name = "TranslatorGroup";
            // 
            // translatorBox
            // 
            this.translatorBox.Items.Add(this.BookButton);
            this.translatorBox.Items.Add(this.SheetButton);
            this.translatorBox.Items.Add(this.SelectionButton);
            this.translatorBox.Name = "translatorBox";
            // 
            // BookButton
            // 
            this.BookButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.BookButton.Image = ((System.Drawing.Image)(resources.GetObject("BookButton.Image")));
            this.BookButton.Label = "Book";
            this.BookButton.Name = "BookButton";
            this.BookButton.ScreenTip = "2";
            this.BookButton.ShowImage = true;
            this.BookButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.BookButton_Click);
            // 
            // SheetButton
            // 
            this.SheetButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.SheetButton.Image = ((System.Drawing.Image)(resources.GetObject("SheetButton.Image")));
            this.SheetButton.Label = "Sheet";
            this.SheetButton.Name = "SheetButton";
            this.SheetButton.ShowImage = true;
            this.SheetButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.SheetButton_Click);
            // 
            // SelectionButton
            // 
            this.SelectionButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.SelectionButton.Image = ((System.Drawing.Image)(resources.GetObject("SelectionButton.Image")));
            this.SelectionButton.Label = "Selection";
            this.SelectionButton.Name = "SelectionButton";
            this.SelectionButton.ShowImage = true;
            this.SelectionButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.SelectionButton_Click);
            // 
            // BoxSeparator
            // 
            this.BoxSeparator.Name = "BoxSeparator";
            // 
            // settingBox
            // 
            this.settingBox.Items.Add(this.SettingButton);
            this.settingBox.Name = "settingBox";
            // 
            // SettingButton
            // 
            this.SettingButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.SettingButton.Image = ((System.Drawing.Image)(resources.GetObject("SettingButton.Image")));
            this.SettingButton.Label = "Setting";
            this.SettingButton.Name = "SettingButton";
            this.SettingButton.ShowImage = true;
            this.SettingButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.SettingButton_Click);
            // 
            // SplusExtras
            // 
            this.Name = "SplusExtras";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.TranslatorTab);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.SplusExtras_Load);
            this.TranslatorTab.ResumeLayout(false);
            this.TranslatorTab.PerformLayout();
            this.TranslatorGroup.ResumeLayout(false);
            this.TranslatorGroup.PerformLayout();
            this.translatorBox.ResumeLayout(false);
            this.translatorBox.PerformLayout();
            this.settingBox.ResumeLayout(false);
            this.settingBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        internal Microsoft.Office.Tools.Ribbon.RibbonTab TranslatorTab;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup TranslatorGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox translatorBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton BookButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton SelectionButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox settingBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton SettingButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator BoxSeparator;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton SheetButton;
    }

    partial class ThisRibbonCollection
    {
        internal SplusExtras SplusExtras
        {
            get { return this.GetRibbon<SplusExtras>(); }
        }
    }
}
