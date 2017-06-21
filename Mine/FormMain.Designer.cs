namespace Mine
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MineFrame = new System.Windows.Forms.PictureBox();
            this.MineField = new System.Windows.Forms.PictureBox();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.beginnerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intermediateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.bestTimesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureFace = new System.Windows.Forms.PictureBox();
            this.pictureFlagNum = new System.Windows.Forms.PictureBox();
            this.pictureTime = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MineFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineField)).BeginInit();
            this.menuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFlagNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTime)).BeginInit();
            this.SuspendLayout();
            // 
            // MineFrame
            // 
            this.MineFrame.BackColor = System.Drawing.SystemColors.Control;
            this.MineFrame.Location = new System.Drawing.Point(1, 25);
            this.MineFrame.Margin = new System.Windows.Forms.Padding(0);
            this.MineFrame.Name = "MineFrame";
            this.MineFrame.Size = new System.Drawing.Size(288, 247);
            this.MineFrame.TabIndex = 3;
            this.MineFrame.TabStop = false;
            this.MineFrame.Paint += new System.Windows.Forms.PaintEventHandler(this.MineFrame_Paint);
            this.MineFrame.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OutsideMineField_MouseDown);
            this.MineFrame.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OutsideMineField_MouseMove);
            this.MineFrame.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OutsideMineField_MouseUp);
            // 
            // MineField
            // 
            this.MineField.Location = new System.Drawing.Point(28, 41);
            this.MineField.Name = "MineField";
            this.MineField.Size = new System.Drawing.Size(53, 59);
            this.MineField.TabIndex = 5;
            this.MineField.TabStop = false;
            this.MineField.Paint += new System.Windows.Forms.PaintEventHandler(this.MineField_Paint);
            this.MineField.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MineField_MouseDown);
            this.MineField.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MineField_MouseMove);
            this.MineField.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MineField_MouseUp);
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(297, 25);
            this.menuMain.TabIndex = 6;
            this.menuMain.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.toolStripMenuItem1,
            this.beginnerToolStripMenuItem,
            this.intermediateToolStripMenuItem,
            this.expertToolStripMenuItem,
            this.customizeToolStripMenuItem,
            this.toolStripMenuItem4,
            this.configToolStripMenuItem,
            this.toolStripMenuItem3,
            this.bestTimesToolStripMenuItem,
            this.toolStripMenuItem5,
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(54, 21);
            this.gameToolStripMenuItem.Text = "&Game";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.startToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.startToolStripMenuItem.Text = "&New Game";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Enabled = false;
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.restartToolStripMenuItem.Text = "&Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // beginnerToolStripMenuItem
            // 
            this.beginnerToolStripMenuItem.Name = "beginnerToolStripMenuItem";
            this.beginnerToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.beginnerToolStripMenuItem.Text = "&Beginner";
            this.beginnerToolStripMenuItem.Click += new System.EventHandler(this.beginnerToolStripMenuItem_Click);
            // 
            // intermediateToolStripMenuItem
            // 
            this.intermediateToolStripMenuItem.Name = "intermediateToolStripMenuItem";
            this.intermediateToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.intermediateToolStripMenuItem.Text = "&Intermediate";
            this.intermediateToolStripMenuItem.Click += new System.EventHandler(this.intermediateToolStripMenuItem_Click);
            // 
            // expertToolStripMenuItem
            // 
            this.expertToolStripMenuItem.Name = "expertToolStripMenuItem";
            this.expertToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.expertToolStripMenuItem.Text = "&Expert";
            this.expertToolStripMenuItem.Click += new System.EventHandler(this.expertToolStripMenuItem_Click);
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.customizeToolStripMenuItem.Text = "&Customize...";
            this.customizeToolStripMenuItem.Click += new System.EventHandler(this.customizeToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(149, 6);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.configToolStripMenuItem.Text = "Con&fig...";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(149, 6);
            // 
            // bestTimesToolStripMenuItem
            // 
            this.bestTimesToolStripMenuItem.Name = "bestTimesToolStripMenuItem";
            this.bestTimesToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.bestTimesToolStripMenuItem.Text = "Best &Times...";
            this.bestTimesToolStripMenuItem.Click += new System.EventHandler(this.bestTimesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pictureFace
            // 
            this.pictureFace.Location = new System.Drawing.Point(12, 121);
            this.pictureFace.Name = "pictureFace";
            this.pictureFace.Size = new System.Drawing.Size(24, 24);
            this.pictureFace.TabIndex = 7;
            this.pictureFace.TabStop = false;
            this.pictureFace.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureFace_Paint);
            this.pictureFace.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureFace_MouseDown);
            this.pictureFace.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureFace_MouseMove);
            this.pictureFace.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureFace_MouseUp);
            // 
            // pictureFlagNum
            // 
            this.pictureFlagNum.BackColor = System.Drawing.SystemColors.Control;
            this.pictureFlagNum.Location = new System.Drawing.Point(97, 41);
            this.pictureFlagNum.Margin = new System.Windows.Forms.Padding(0);
            this.pictureFlagNum.Name = "pictureFlagNum";
            this.pictureFlagNum.Size = new System.Drawing.Size(83, 29);
            this.pictureFlagNum.TabIndex = 8;
            this.pictureFlagNum.TabStop = false;
            this.pictureFlagNum.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureFlagNum_Paint);
            this.pictureFlagNum.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OutsideMineField_MouseDown);
            this.pictureFlagNum.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OutsideMineField_MouseMove);
            this.pictureFlagNum.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OutsideMineField_MouseUp);
            // 
            // pictureTime
            // 
            this.pictureTime.BackColor = System.Drawing.SystemColors.Control;
            this.pictureTime.Location = new System.Drawing.Point(97, 70);
            this.pictureTime.Margin = new System.Windows.Forms.Padding(0);
            this.pictureTime.Name = "pictureTime";
            this.pictureTime.Size = new System.Drawing.Size(46, 29);
            this.pictureTime.TabIndex = 9;
            this.pictureTime.TabStop = false;
            this.pictureTime.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureTime_Paint);
            this.pictureTime.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OutsideMineField_MouseDown);
            this.pictureTime.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OutsideMineField_MouseMove);
            this.pictureTime.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OutsideMineField_MouseUp);
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 1000;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(297, 352);
            this.Controls.Add(this.pictureTime);
            this.Controls.Add(this.pictureFlagNum);
            this.Controls.Add(this.pictureFace);
            this.Controls.Add(this.MineField);
            this.Controls.Add(this.MineFrame);
            this.Controls.Add(this.menuMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuMain;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(179, 141);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MineSweeper";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormMain_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.MineFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MineField)).EndInit();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureFlagNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox MineFrame;
        private System.Windows.Forms.PictureBox MineField;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureFace;
        private System.Windows.Forms.PictureBox pictureFlagNum;
        private System.Windows.Forms.PictureBox pictureTime;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.ToolStripMenuItem beginnerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intermediateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bestTimesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
    }
}

