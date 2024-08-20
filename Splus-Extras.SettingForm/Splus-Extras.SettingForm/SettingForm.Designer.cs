namespace Splus_Extras.SettingForm
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.sourceLanguage = new System.Windows.Forms.Label();
            this.targetLanguage = new System.Windows.Forms.Label();
            this.SourceLanguageComboBox = new System.Windows.Forms.ComboBox();
            this.TargetLanguageComboBox = new System.Windows.Forms.ComboBox();
            this.token = new System.Windows.Forms.Label();
            this.TokenTextBox = new System.Windows.Forms.TextBox();
            this.limithWordLabel = new System.Windows.Forms.Label();
            this.LimitWordTextbox = new System.Windows.Forms.TextBox();
            this.limitWord = new System.Windows.Forms.Label();
            this.version = new System.Windows.Forms.Label();
            this.TranslateServiceGroup = new System.Windows.Forms.GroupBox();
            this.TranslatorComboBox = new System.Windows.Forms.ComboBox();
            this.TranslatorLable = new System.Windows.Forms.Label();
            this.TranslateServiceGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(299, 300);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 28);
            this.cancelButton.TabIndex = 0;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(407, 302);
            this.OkButton.Margin = new System.Windows.Forms.Padding(4);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(100, 28);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // sourceLanguage
            // 
            this.sourceLanguage.AutoSize = true;
            this.sourceLanguage.Location = new System.Drawing.Point(13, 80);
            this.sourceLanguage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sourceLanguage.Name = "sourceLanguage";
            this.sourceLanguage.Size = new System.Drawing.Size(99, 16);
            this.sourceLanguage.TabIndex = 2;
            this.sourceLanguage.Text = "Translate from: ";
            // 
            // targetLanguage
            // 
            this.targetLanguage.AutoSize = true;
            this.targetLanguage.Location = new System.Drawing.Point(13, 123);
            this.targetLanguage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.targetLanguage.Name = "targetLanguage";
            this.targetLanguage.Size = new System.Drawing.Size(81, 16);
            this.targetLanguage.TabIndex = 3;
            this.targetLanguage.Text = "Translate to:";
            // 
            // SourceLanguageComboBox
            // 
            this.SourceLanguageComboBox.FormattingEnabled = true;
            this.SourceLanguageComboBox.Items.AddRange(new object[] {
            "Chinese (mandarin)",
            "Chinese (cantonese)",
            "Korean",
            "English",
            "French",
            "German",
            "Japanese",
            "Vietnamese"});
            this.SourceLanguageComboBox.Location = new System.Drawing.Point(133, 74);
            this.SourceLanguageComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.SourceLanguageComboBox.Name = "SourceLanguageComboBox";
            this.SourceLanguageComboBox.Size = new System.Drawing.Size(256, 24);
            this.SourceLanguageComboBox.TabIndex = 4;
            // 
            // TargetLanguageComboBox
            // 
            this.TargetLanguageComboBox.FormattingEnabled = true;
            this.TargetLanguageComboBox.Items.AddRange(new object[] {
            "Chinese (mandarin)",
            "Chinese (cantonese)",
            "Korean",
            "English",
            "French",
            "German",
            "Japanese",
            "Vietnamese"});
            this.TargetLanguageComboBox.Location = new System.Drawing.Point(133, 117);
            this.TargetLanguageComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.TargetLanguageComboBox.Name = "TargetLanguageComboBox";
            this.TargetLanguageComboBox.Size = new System.Drawing.Size(256, 24);
            this.TargetLanguageComboBox.TabIndex = 5;
            // 
            // token
            // 
            this.token.AutoSize = true;
            this.token.Location = new System.Drawing.Point(8, 82);
            this.token.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.token.Name = "token";
            this.token.Size = new System.Drawing.Size(46, 16);
            this.token.TabIndex = 6;
            this.token.Text = "Token";
            // 
            // TokenTextBox
            // 
            this.TokenTextBox.Location = new System.Drawing.Point(125, 79);
            this.TokenTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.TokenTextBox.Name = "TokenTextBox";
            this.TokenTextBox.Size = new System.Drawing.Size(256, 22);
            this.TokenTextBox.TabIndex = 7;
            this.TokenTextBox.UseSystemPasswordChar = true;
            // 
            // limithWordLabel
            // 
            this.limithWordLabel.AutoSize = true;
            this.limithWordLabel.Location = new System.Drawing.Point(13, 37);
            this.limithWordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.limithWordLabel.Name = "limithWordLabel";
            this.limithWordLabel.Size = new System.Drawing.Size(103, 16);
            this.limithWordLabel.TabIndex = 8;
            this.limithWordLabel.Text = "Limit characters:";
            // 
            // LimitWordTextbox
            // 
            this.LimitWordTextbox.Location = new System.Drawing.Point(133, 31);
            this.LimitWordTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.LimitWordTextbox.Name = "LimitWordTextbox";
            this.LimitWordTextbox.Size = new System.Drawing.Size(256, 22);
            this.LimitWordTextbox.TabIndex = 9;
            this.LimitWordTextbox.KeyPress += LimitWordTextbox_KeyPress;
            // 
            // limitWord
            // 
            this.limitWord.AutoSize = true;
            this.limitWord.Location = new System.Drawing.Point(400, 34);
            this.limitWord.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.limitWord.Name = "limitWord";
            this.limitWord.Size = new System.Drawing.Size(93, 16);
            this.limitWord.TabIndex = 10;
            this.limitWord.Text = "(1.000~10.000)";
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.Location = new System.Drawing.Point(13, 308);
            this.version.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(41, 16);
            this.version.TabIndex = 14;
            this.version.Text = "v1.0.0";
            // 
            // TranslateServiceGroup
            // 
            this.TranslateServiceGroup.Controls.Add(this.TranslatorComboBox);
            this.TranslateServiceGroup.Controls.Add(this.TranslatorLable);
            this.TranslateServiceGroup.Controls.Add(this.token);
            this.TranslateServiceGroup.Controls.Add(this.TokenTextBox);
            this.TranslateServiceGroup.Location = new System.Drawing.Point(8, 154);
            this.TranslateServiceGroup.Margin = new System.Windows.Forms.Padding(4);
            this.TranslateServiceGroup.Name = "TranslateServiceGroup";
            this.TranslateServiceGroup.Padding = new System.Windows.Forms.Padding(4);
            this.TranslateServiceGroup.Size = new System.Drawing.Size(495, 122);
            this.TranslateServiceGroup.TabIndex = 15;
            this.TranslateServiceGroup.TabStop = false;
            this.TranslateServiceGroup.Text = "Translate services";
            // 
            // TranslatorComboBox
            // 
            this.TranslatorComboBox.FormattingEnabled = true;
            this.TranslatorComboBox.Items.AddRange(new object[] {
            "ChatGPT",
            "DeepL",
            "Google Translate"});
            this.TranslatorComboBox.Location = new System.Drawing.Point(125, 34);
            this.TranslatorComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.TranslatorComboBox.Name = "TranslatorComboBox";
            this.TranslatorComboBox.Size = new System.Drawing.Size(256, 24);
            this.TranslatorComboBox.TabIndex = 9;
            // 
            // TranslatorLable
            // 
            this.TranslatorLable.AutoSize = true;
            this.TranslatorLable.Location = new System.Drawing.Point(9, 42);
            this.TranslatorLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TranslatorLable.Name = "TranslatorLable";
            this.TranslatorLable.Size = new System.Drawing.Size(68, 16);
            this.TranslatorLable.TabIndex = 8;
            this.TranslatorLable.Text = "Translator";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 338);
            this.Controls.Add(this.TranslateServiceGroup);
            this.Controls.Add(this.version);
            this.Controls.Add(this.limitWord);
            this.Controls.Add(this.LimitWordTextbox);
            this.Controls.Add(this.limithWordLabel);
            this.Controls.Add(this.TargetLanguageComboBox);
            this.Controls.Add(this.SourceLanguageComboBox);
            this.Controls.Add(this.targetLanguage);
            this.Controls.Add(this.sourceLanguage);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.cancelButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingForm";
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.TranslateServiceGroup.ResumeLayout(false);
            this.TranslateServiceGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label sourceLanguage;
        private System.Windows.Forms.Label targetLanguage;
        private System.Windows.Forms.ComboBox SourceLanguageComboBox;
        private System.Windows.Forms.ComboBox TargetLanguageComboBox;
        private System.Windows.Forms.Label token;
        private System.Windows.Forms.TextBox TokenTextBox;
        private System.Windows.Forms.Label limithWordLabel;
        private System.Windows.Forms.TextBox LimitWordTextbox;
        private System.Windows.Forms.Label limitWord;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.GroupBox TranslateServiceGroup;
        private System.Windows.Forms.ComboBox TranslatorComboBox;
        private System.Windows.Forms.Label TranslatorLable;
    }
}