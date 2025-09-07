namespace MineSweeper
{
    partial class FormConfig
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
            groupBoxFirstClick = new GroupBox();
            radioOpen = new RadioButton();
            radioProtection = new RadioButton();
            radioNoProtection = new RadioButton();
            checkAllowFlag = new CheckBox();
            checkAllowMark = new CheckBox();
            checkShowMine = new CheckBox();
            check4DigitsTimeAndMines = new CheckBox();
            buttonOK = new Button();
            buttonCancel = new Button();
            checkAllowRestartPlayHighScore = new CheckBox();
            checkTimeStartFromZero = new CheckBox();
            tabControl1 = new TabControl();
            tabPageGameConfig = new TabPage();
            tabPageProfile = new TabPage();
            tabPageCheat = new TabPage();
            button1 = new Button();
            groupBoxFirstClick.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageGameConfig.SuspendLayout();
            tabPageCheat.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxFirstClick
            // 
            groupBoxFirstClick.Controls.Add(radioOpen);
            groupBoxFirstClick.Controls.Add(radioProtection);
            groupBoxFirstClick.Controls.Add(radioNoProtection);
            groupBoxFirstClick.Location = new Point(7, 7);
            groupBoxFirstClick.Margin = new Padding(4);
            groupBoxFirstClick.Name = "groupBoxFirstClick";
            groupBoxFirstClick.Padding = new Padding(4);
            groupBoxFirstClick.Size = new Size(487, 111);
            groupBoxFirstClick.TabIndex = 0;
            groupBoxFirstClick.TabStop = false;
            groupBoxFirstClick.Text = "第一次点击";
            // 
            // radioOpen
            // 
            radioOpen.AutoSize = true;
            radioOpen.Location = new Point(7, 82);
            radioOpen.Margin = new Padding(4);
            radioOpen.Name = "radioOpen";
            radioOpen.Size = new Size(74, 21);
            radioOpen.TabIndex = 3;
            radioOpen.TabStop = true;
            radioOpen.Text = "打开一片";
            radioOpen.UseVisualStyleBackColor = true;
            // 
            // radioProtection
            // 
            radioProtection.AutoSize = true;
            radioProtection.Location = new Point(7, 53);
            radioProtection.Margin = new Padding(4);
            radioProtection.Name = "radioProtection";
            radioProtection.Size = new Size(50, 21);
            radioProtection.TabIndex = 2;
            radioProtection.TabStop = true;
            radioProtection.Text = "保护";
            radioProtection.UseVisualStyleBackColor = true;
            // 
            // radioNoProtection
            // 
            radioNoProtection.AutoSize = true;
            radioNoProtection.Location = new Point(7, 24);
            radioNoProtection.Margin = new Padding(4);
            radioNoProtection.Name = "radioNoProtection";
            radioNoProtection.Size = new Size(62, 21);
            radioNoProtection.TabIndex = 1;
            radioNoProtection.TabStop = true;
            radioNoProtection.Text = "无保护";
            radioNoProtection.UseVisualStyleBackColor = true;
            // 
            // checkAllowFlag
            // 
            checkAllowFlag.AutoSize = true;
            checkAllowFlag.Location = new Point(7, 126);
            checkAllowFlag.Margin = new Padding(4);
            checkAllowFlag.Name = "checkAllowFlag";
            checkAllowFlag.Size = new Size(51, 21);
            checkAllowFlag.TabIndex = 1;
            checkAllowFlag.Text = "旗帜";
            checkAllowFlag.UseVisualStyleBackColor = true;
            checkAllowFlag.CheckedChanged += checkAllowFlag_CheckedChanged;
            // 
            // checkAllowMark
            // 
            checkAllowMark.AutoSize = true;
            checkAllowMark.Location = new Point(21, 155);
            checkAllowMark.Margin = new Padding(4);
            checkAllowMark.Name = "checkAllowMark";
            checkAllowMark.Size = new Size(51, 21);
            checkAllowMark.TabIndex = 2;
            checkAllowMark.Text = "标记";
            checkAllowMark.UseVisualStyleBackColor = true;
            // 
            // checkShowMine
            // 
            checkShowMine.AutoSize = true;
            checkShowMine.Location = new Point(7, 7);
            checkShowMine.Margin = new Padding(4);
            checkShowMine.Name = "checkShowMine";
            checkShowMine.Size = new Size(75, 21);
            checkShowMine.TabIndex = 3;
            checkShowMine.Text = "显示地雷";
            checkShowMine.UseVisualStyleBackColor = true;
            // 
            // check4DigitsTimeAndMines
            // 
            check4DigitsTimeAndMines.AutoSize = true;
            check4DigitsTimeAndMines.Location = new Point(7, 213);
            check4DigitsTimeAndMines.Margin = new Padding(4);
            check4DigitsTimeAndMines.Name = "check4DigitsTimeAndMines";
            check4DigitsTimeAndMines.Size = new Size(106, 21);
            check4DigitsTimeAndMines.TabIndex = 4;
            check4DigitsTimeAndMines.Text = "4位雷数和计时";
            check4DigitsTimeAndMines.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            buttonOK.DialogResult = DialogResult.OK;
            buttonOK.Location = new Point(359, 426);
            buttonOK.Margin = new Padding(4);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 25);
            buttonOK.TabIndex = 5;
            buttonOK.Text = "确定";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(442, 426);
            buttonCancel.Margin = new Padding(4);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 25);
            buttonCancel.TabIndex = 6;
            buttonCancel.Text = "取消";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // checkAllowRestartPlayHighScore
            // 
            checkAllowRestartPlayHighScore.AutoSize = true;
            checkAllowRestartPlayHighScore.Location = new Point(7, 242);
            checkAllowRestartPlayHighScore.Margin = new Padding(4);
            checkAllowRestartPlayHighScore.Name = "checkAllowRestartPlayHighScore";
            checkAllowRestartPlayHighScore.Size = new Size(123, 21);
            checkAllowRestartPlayHighScore.TabIndex = 7;
            checkAllowRestartPlayHighScore.Text = "重玩允许最佳时间";
            checkAllowRestartPlayHighScore.UseVisualStyleBackColor = true;
            // 
            // checkTimeStartFromZero
            // 
            checkTimeStartFromZero.AutoSize = true;
            checkTimeStartFromZero.Location = new Point(7, 184);
            checkTimeStartFromZero.Margin = new Padding(4);
            checkTimeStartFromZero.Name = "checkTimeStartFromZero";
            checkTimeStartFromZero.Size = new Size(94, 21);
            checkTimeStartFromZero.TabIndex = 8;
            checkTimeStartFromZero.Text = "计时从0开始";
            checkTimeStartFromZero.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageGameConfig);
            tabControl1.Controls.Add(tabPageProfile);
            tabControl1.Controls.Add(tabPageCheat);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(509, 411);
            tabControl1.TabIndex = 9;
            // 
            // tabPageGameConfig
            // 
            tabPageGameConfig.Controls.Add(checkAllowRestartPlayHighScore);
            tabPageGameConfig.Controls.Add(checkTimeStartFromZero);
            tabPageGameConfig.Controls.Add(groupBoxFirstClick);
            tabPageGameConfig.Controls.Add(checkAllowFlag);
            tabPageGameConfig.Controls.Add(checkAllowMark);
            tabPageGameConfig.Controls.Add(check4DigitsTimeAndMines);
            tabPageGameConfig.Location = new Point(4, 26);
            tabPageGameConfig.Name = "tabPageGameConfig";
            tabPageGameConfig.Padding = new Padding(3);
            tabPageGameConfig.Size = new Size(501, 381);
            tabPageGameConfig.TabIndex = 0;
            tabPageGameConfig.Text = "tabPage1";
            tabPageGameConfig.UseVisualStyleBackColor = true;
            // 
            // tabPageProfile
            // 
            tabPageProfile.Location = new Point(4, 26);
            tabPageProfile.Name = "tabPageProfile";
            tabPageProfile.Padding = new Padding(3);
            tabPageProfile.Size = new Size(501, 381);
            tabPageProfile.TabIndex = 1;
            tabPageProfile.Text = "tabPage2";
            tabPageProfile.UseVisualStyleBackColor = true;
            // 
            // tabPageCheat
            // 
            tabPageCheat.Controls.Add(checkShowMine);
            tabPageCheat.Location = new Point(4, 26);
            tabPageCheat.Name = "tabPageCheat";
            tabPageCheat.Size = new Size(501, 381);
            tabPageCheat.TabIndex = 2;
            tabPageCheat.Text = "tabPageCheat";
            tabPageCheat.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(404, 489);
            button1.Name = "button1";
            button1.Size = new Size(8, 8);
            button1.TabIndex = 10;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // FormConfig
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(531, 462);
            Controls.Add(button1);
            Controls.Add(tabControl1);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormConfig";
            StartPosition = FormStartPosition.CenterParent;
            Text = "配置";
            Shown += FormConfig_Shown;
            groupBoxFirstClick.ResumeLayout(false);
            groupBoxFirstClick.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPageGameConfig.ResumeLayout(false);
            tabPageGameConfig.PerformLayout();
            tabPageCheat.ResumeLayout(false);
            tabPageCheat.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFirstClick;
        private System.Windows.Forms.RadioButton radioOpen;
        private System.Windows.Forms.RadioButton radioProtection;
        private System.Windows.Forms.RadioButton radioNoProtection;
        private System.Windows.Forms.CheckBox checkAllowFlag;
        private System.Windows.Forms.CheckBox checkAllowMark;
        private System.Windows.Forms.CheckBox checkShowMine;
        private System.Windows.Forms.CheckBox check4DigitsTimeAndMines;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkAllowRestartPlayHighScore;
        private System.Windows.Forms.CheckBox checkTimeStartFromZero;
        private TabControl tabControl1;
        private TabPage tabPageGameConfig;
        private TabPage tabPageProfile;
        private TabPage tabPageCheat;
        private Button button1;
    }
}