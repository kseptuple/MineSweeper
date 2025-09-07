namespace MineSweeper
{
    partial class FormBestTimes
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
            tableLayoutPanel1 = new TableLayoutPanel();
            labelBegTime = new Label();
            labelExpert = new Label();
            labelIntermediate = new Label();
            labelBeginner = new Label();
            labelIntTime = new Label();
            labelExpTime = new Label();
            labelBegName = new Label();
            labelIntName = new Label();
            labelExpName = new Label();
            buttonOK = new Button();
            buttonResetScore = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.Controls.Add(labelBegTime, 1, 0);
            tableLayoutPanel1.Controls.Add(labelExpert, 0, 2);
            tableLayoutPanel1.Controls.Add(labelIntermediate, 0, 1);
            tableLayoutPanel1.Controls.Add(labelBeginner, 0, 0);
            tableLayoutPanel1.Controls.Add(labelIntTime, 1, 1);
            tableLayoutPanel1.Controls.Add(labelExpTime, 1, 2);
            tableLayoutPanel1.Controls.Add(labelBegName, 2, 0);
            tableLayoutPanel1.Controls.Add(labelIntName, 2, 1);
            tableLayoutPanel1.Controls.Add(labelExpName, 2, 2);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(4);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.34F));
            tableLayoutPanel1.Size = new Size(312, 88);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // labelBegTime
            // 
            labelBegTime.Dock = DockStyle.Fill;
            labelBegTime.Location = new Point(97, 0);
            labelBegTime.Margin = new Padding(4, 0, 4, 0);
            labelBegTime.Name = "labelBegTime";
            labelBegTime.Size = new Size(85, 29);
            labelBegTime.TabIndex = 4;
            labelBegTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelExpert
            // 
            labelExpert.Dock = DockStyle.Fill;
            labelExpert.Location = new Point(4, 58);
            labelExpert.Margin = new Padding(4, 0, 4, 0);
            labelExpert.Name = "labelExpert";
            labelExpert.Size = new Size(85, 30);
            labelExpert.TabIndex = 4;
            labelExpert.Text = "高级：";
            labelExpert.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelIntermediate
            // 
            labelIntermediate.Dock = DockStyle.Fill;
            labelIntermediate.Location = new Point(4, 29);
            labelIntermediate.Margin = new Padding(4, 0, 4, 0);
            labelIntermediate.Name = "labelIntermediate";
            labelIntermediate.Size = new Size(85, 29);
            labelIntermediate.TabIndex = 4;
            labelIntermediate.Text = "中级：";
            labelIntermediate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelBeginner
            // 
            labelBeginner.Dock = DockStyle.Fill;
            labelBeginner.Location = new Point(4, 0);
            labelBeginner.Margin = new Padding(4, 0, 4, 0);
            labelBeginner.Name = "labelBeginner";
            labelBeginner.Size = new Size(85, 29);
            labelBeginner.TabIndex = 1;
            labelBeginner.Text = "初级：";
            labelBeginner.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelIntTime
            // 
            labelIntTime.Dock = DockStyle.Fill;
            labelIntTime.Location = new Point(97, 29);
            labelIntTime.Margin = new Padding(4, 0, 4, 0);
            labelIntTime.Name = "labelIntTime";
            labelIntTime.Size = new Size(85, 29);
            labelIntTime.TabIndex = 5;
            labelIntTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelExpTime
            // 
            labelExpTime.Dock = DockStyle.Fill;
            labelExpTime.Location = new Point(97, 58);
            labelExpTime.Margin = new Padding(4, 0, 4, 0);
            labelExpTime.Name = "labelExpTime";
            labelExpTime.Size = new Size(85, 30);
            labelExpTime.TabIndex = 6;
            labelExpTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelBegName
            // 
            labelBegName.Dock = DockStyle.Fill;
            labelBegName.Location = new Point(190, 0);
            labelBegName.Margin = new Padding(4, 0, 4, 0);
            labelBegName.Name = "labelBegName";
            labelBegName.Size = new Size(118, 29);
            labelBegName.TabIndex = 7;
            labelBegName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelIntName
            // 
            labelIntName.Dock = DockStyle.Fill;
            labelIntName.Location = new Point(190, 29);
            labelIntName.Margin = new Padding(4, 0, 4, 0);
            labelIntName.Name = "labelIntName";
            labelIntName.Size = new Size(118, 29);
            labelIntName.TabIndex = 8;
            labelIntName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelExpName
            // 
            labelExpName.Dock = DockStyle.Fill;
            labelExpName.Location = new Point(190, 58);
            labelExpName.Margin = new Padding(4, 0, 4, 0);
            labelExpName.Name = "labelExpName";
            labelExpName.Size = new Size(118, 30);
            labelExpName.TabIndex = 9;
            labelExpName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonOK
            // 
            buttonOK.Location = new Point(197, 96);
            buttonOK.Margin = new Padding(4);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(75, 25);
            buttonOK.TabIndex = 4;
            buttonOK.Text = "确定";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonResetScore
            // 
            buttonResetScore.Location = new Point(27, 96);
            buttonResetScore.Margin = new Padding(4);
            buttonResetScore.Name = "buttonResetScore";
            buttonResetScore.Size = new Size(100, 25);
            buttonResetScore.TabIndex = 5;
            buttonResetScore.Text = "重新计分";
            buttonResetScore.UseVisualStyleBackColor = true;
            buttonResetScore.Click += buttonResetScore_Click;
            // 
            // FormBestTimes
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(312, 127);
            Controls.Add(buttonResetScore);
            Controls.Add(buttonOK);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormBestTimes";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "最佳时间";
            Shown += FormBestTimes_Shown;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelBeginner;
        private System.Windows.Forms.Label labelBegTime;
        private System.Windows.Forms.Label labelExpert;
        private System.Windows.Forms.Label labelIntermediate;
        private System.Windows.Forms.Label labelIntTime;
        private System.Windows.Forms.Label labelExpTime;
        private System.Windows.Forms.Label labelBegName;
        private System.Windows.Forms.Label labelIntName;
        private System.Windows.Forms.Label labelExpName;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonResetScore;
    }
}