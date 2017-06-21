namespace Mine
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioOpen = new System.Windows.Forms.RadioButton();
            this.radioProtection = new System.Windows.Forms.RadioButton();
            this.radioNoProtection = new System.Windows.Forms.RadioButton();
            this.checkAllowFlag = new System.Windows.Forms.CheckBox();
            this.checkAllowMark = new System.Windows.Forms.CheckBox();
            this.checkAllowCheat = new System.Windows.Forms.CheckBox();
            this.check4DigitsTimeAndMines = new System.Windows.Forms.CheckBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkAllowRestartPlayHighScore = new System.Windows.Forms.CheckBox();
            this.checkTimeStartFromZero = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioOpen);
            this.groupBox1.Controls.Add(this.radioProtection);
            this.groupBox1.Controls.Add(this.radioNoProtection);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 119);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "On The First Click";
            // 
            // radioOpen
            // 
            this.radioOpen.AutoSize = true;
            this.radioOpen.Location = new System.Drawing.Point(6, 76);
            this.radioOpen.Name = "radioOpen";
            this.radioOpen.Size = new System.Drawing.Size(275, 28);
            this.radioOpen.TabIndex = 3;
            this.radioOpen.TabStop = true;
            this.radioOpen.Text = "Open an area. Always get an opening on the\r\nfirst click.";
            this.radioOpen.UseVisualStyleBackColor = true;
            // 
            // radioProtection
            // 
            this.radioProtection.AutoSize = true;
            this.radioProtection.Location = new System.Drawing.Point(6, 54);
            this.radioProtection.Name = "radioProtection";
            this.radioProtection.Size = new System.Drawing.Size(245, 16);
            this.radioProtection.TabIndex = 2;
            this.radioProtection.TabStop = true;
            this.radioProtection.Text = "Standard. First click is always safe.";
            this.radioProtection.UseVisualStyleBackColor = true;
            // 
            // radioNoProtection
            // 
            this.radioNoProtection.AutoSize = true;
            this.radioNoProtection.Location = new System.Drawing.Point(6, 20);
            this.radioNoProtection.Name = "radioNoProtection";
            this.radioNoProtection.Size = new System.Drawing.Size(281, 28);
            this.radioNoProtection.TabIndex = 1;
            this.radioNoProtection.TabStop = true;
            this.radioNoProtection.Text = "No protection. It is possible to hit a mine\r\non the first click.";
            this.radioNoProtection.UseVisualStyleBackColor = true;
            // 
            // checkAllowFlag
            // 
            this.checkAllowFlag.AutoSize = true;
            this.checkAllowFlag.Location = new System.Drawing.Point(12, 137);
            this.checkAllowFlag.Name = "checkAllowFlag";
            this.checkAllowFlag.Size = new System.Drawing.Size(138, 16);
            this.checkAllowFlag.TabIndex = 1;
            this.checkAllowFlag.Text = "Allow setting flags";
            this.checkAllowFlag.UseVisualStyleBackColor = true;
            this.checkAllowFlag.CheckedChanged += new System.EventHandler(this.checkAllowFlag_CheckedChanged);
            // 
            // checkAllowMark
            // 
            this.checkAllowMark.AutoSize = true;
            this.checkAllowMark.Location = new System.Drawing.Point(30, 159);
            this.checkAllowMark.Name = "checkAllowMark";
            this.checkAllowMark.Size = new System.Drawing.Size(90, 16);
            this.checkAllowMark.TabIndex = 2;
            this.checkAllowMark.Text = "Allow marks";
            this.checkAllowMark.UseVisualStyleBackColor = true;
            // 
            // checkAllowCheat
            // 
            this.checkAllowCheat.AutoSize = true;
            this.checkAllowCheat.Location = new System.Drawing.Point(12, 247);
            this.checkAllowCheat.Name = "checkAllowCheat";
            this.checkAllowCheat.Size = new System.Drawing.Size(84, 16);
            this.checkAllowCheat.TabIndex = 3;
            this.checkAllowCheat.Text = "Cheat mode";
            this.checkAllowCheat.UseVisualStyleBackColor = true;
            // 
            // check4DigitsTimeAndMines
            // 
            this.check4DigitsTimeAndMines.AutoSize = true;
            this.check4DigitsTimeAndMines.Location = new System.Drawing.Point(12, 203);
            this.check4DigitsTimeAndMines.Name = "check4DigitsTimeAndMines";
            this.check4DigitsTimeAndMines.Size = new System.Drawing.Size(222, 16);
            this.check4DigitsTimeAndMines.TabIndex = 4;
            this.check4DigitsTimeAndMines.Text = "Show 4-digit mine number and time";
            this.check4DigitsTimeAndMines.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(61, 269);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(190, 269);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // checkAllowRestartPlayHighScore
            // 
            this.checkAllowRestartPlayHighScore.AutoSize = true;
            this.checkAllowRestartPlayHighScore.Location = new System.Drawing.Point(12, 225);
            this.checkAllowRestartPlayHighScore.Name = "checkAllowRestartPlayHighScore";
            this.checkAllowRestartPlayHighScore.Size = new System.Drawing.Size(294, 16);
            this.checkAllowRestartPlayHighScore.TabIndex = 7;
            this.checkAllowRestartPlayHighScore.Text = "Allow best time recording for restarted games";
            this.checkAllowRestartPlayHighScore.UseVisualStyleBackColor = true;
            // 
            // checkTimeStartFromZero
            // 
            this.checkTimeStartFromZero.AutoSize = true;
            this.checkTimeStartFromZero.Location = new System.Drawing.Point(12, 181);
            this.checkTimeStartFromZero.Name = "checkTimeStartFromZero";
            this.checkTimeStartFromZero.Size = new System.Drawing.Size(210, 16);
            this.checkTimeStartFromZero.TabIndex = 8;
            this.checkTimeStartFromZero.Text = "Time start from 0 rather than 1";
            this.checkTimeStartFromZero.UseVisualStyleBackColor = true;
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 302);
            this.Controls.Add(this.checkTimeStartFromZero);
            this.Controls.Add(this.checkAllowRestartPlayHighScore);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.check4DigitsTimeAndMines);
            this.Controls.Add(this.checkAllowCheat);
            this.Controls.Add(this.checkAllowMark);
            this.Controls.Add(this.checkAllowFlag);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Config";
            this.Shown += new System.EventHandler(this.FormConfig_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioOpen;
        private System.Windows.Forms.RadioButton radioProtection;
        private System.Windows.Forms.RadioButton radioNoProtection;
        private System.Windows.Forms.CheckBox checkAllowFlag;
        private System.Windows.Forms.CheckBox checkAllowMark;
        private System.Windows.Forms.CheckBox checkAllowCheat;
        private System.Windows.Forms.CheckBox check4DigitsTimeAndMines;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkAllowRestartPlayHighScore;
        private System.Windows.Forms.CheckBox checkTimeStartFromZero;
    }
}