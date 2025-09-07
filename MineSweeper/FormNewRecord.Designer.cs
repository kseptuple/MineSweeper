namespace MineSweeper
{
    partial class FormNewRecord
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
            buttonOK = new Button();
            textName = new TextBox();
            labelText = new Label();
            SuspendLayout();
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(72, 110);
            buttonOK.Margin = new Padding(4);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 25);
            buttonOK.TabIndex = 0;
            buttonOK.Text = "确定";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // textName
            // 
            textName.Location = new Point(13, 79);
            textName.Margin = new Padding(4);
            textName.Name = "textName";
            textName.Size = new Size(198, 23);
            textName.TabIndex = 1;
            // 
            // labelText
            // 
            labelText.Location = new Point(13, 9);
            labelText.Margin = new Padding(4, 0, 4, 0);
            labelText.Name = "labelText";
            labelText.Size = new Size(198, 62);
            labelText.TabIndex = 2;
            labelText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormNewRecord
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(224, 144);
            ControlBox = false;
            Controls.Add(labelText);
            Controls.Add(textName);
            Controls.Add(buttonOK);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            Name = "FormNewRecord";
            StartPosition = FormStartPosition.CenterParent;
            Text = "新纪录";
            Shown += FormNewRecord_Shown;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label labelText;
    }
}