namespace MineSweeper
{
    partial class FormCustom
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
            labelHeight = new Label();
            labelWidth = new Label();
            labelMines = new Label();
            textHeight = new TextBox();
            textWidth = new TextBox();
            textMines = new TextBox();
            buttonOK = new Button();
            buttonCancel = new Button();
            SuspendLayout();
            // 
            // labelHeight
            // 
            labelHeight.AutoSize = true;
            labelHeight.Location = new Point(13, 9);
            labelHeight.Margin = new Padding(4, 0, 4, 0);
            labelHeight.Name = "labelHeight";
            labelHeight.Size = new Size(44, 17);
            labelHeight.TabIndex = 0;
            labelHeight.Text = "高度：";
            // 
            // labelWidth
            // 
            labelWidth.AutoSize = true;
            labelWidth.Location = new Point(13, 40);
            labelWidth.Margin = new Padding(4, 0, 4, 0);
            labelWidth.Name = "labelWidth";
            labelWidth.Size = new Size(44, 17);
            labelWidth.TabIndex = 1;
            labelWidth.Text = "宽度：";
            // 
            // labelMines
            // 
            labelMines.AutoSize = true;
            labelMines.Location = new Point(12, 71);
            labelMines.Margin = new Padding(4, 0, 4, 0);
            labelMines.Name = "labelMines";
            labelMines.Size = new Size(44, 17);
            labelMines.TabIndex = 2;
            labelMines.Text = "雷数：";
            // 
            // textHeight
            // 
            textHeight.Location = new Point(76, 6);
            textHeight.Margin = new Padding(4, 4, 4, 4);
            textHeight.MaxLength = 2;
            textHeight.Name = "textHeight";
            textHeight.Size = new Size(76, 23);
            textHeight.TabIndex = 3;
            textHeight.KeyPress += textNumeric_KeyPress;
            // 
            // textWidth
            // 
            textWidth.Location = new Point(76, 37);
            textWidth.Margin = new Padding(4, 4, 4, 4);
            textWidth.MaxLength = 2;
            textWidth.Name = "textWidth";
            textWidth.Size = new Size(76, 23);
            textWidth.TabIndex = 4;
            textWidth.KeyPress += textNumeric_KeyPress;
            // 
            // textMines
            // 
            textMines.Location = new Point(76, 68);
            textMines.Margin = new Padding(4, 4, 4, 4);
            textMines.MaxLength = 4;
            textMines.Name = "textMines";
            textMines.Size = new Size(76, 23);
            textMines.TabIndex = 5;
            textMines.KeyPress += textNumeric_KeyPress;
            // 
            // buttonOK
            // 
            buttonOK.DialogResult = DialogResult.OK;
            buttonOK.Location = new Point(160, 5);
            buttonOK.Margin = new Padding(4, 4, 4, 4);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 25);
            buttonOK.TabIndex = 6;
            buttonOK.Text = "确定";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(160, 67);
            buttonCancel.Margin = new Padding(4, 4, 4, 4);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 25);
            buttonCancel.TabIndex = 7;
            buttonCancel.Text = "取消";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // FormCustom
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(247, 103);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(textMines);
            Controls.Add(textWidth);
            Controls.Add(textHeight);
            Controls.Add(labelMines);
            Controls.Add(labelWidth);
            Controls.Add(labelHeight);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 4, 4, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormCustom";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "自定义";
            Shown += FormCustom_Shown;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label labelMines;
        private System.Windows.Forms.TextBox textHeight;
        private System.Windows.Forms.TextBox textWidth;
        private System.Windows.Forms.TextBox textMines;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}