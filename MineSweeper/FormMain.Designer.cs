namespace MineSweeper
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
            components = new System.ComponentModel.Container();
            MineFrame = new PictureBox();
            MineField = new PictureBox();
            menuMain = new MenuStrip();
            ToolStripMenuItemGame = new ToolStripMenuItem();
            ToolStripMenuItemStart = new ToolStripMenuItem();
            ToolStripMenuItemRestart = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            ToolStripMenuItemBeginner = new ToolStripMenuItem();
            ToolStripMenuItemIntermediate = new ToolStripMenuItem();
            ToolStripMenuItemExpert = new ToolStripMenuItem();
            ToolStripMenuItemCustomize = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripSeparator();
            ToolStripMenuItemBestTimes = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripSeparator();
            ToolStripMenuItemExit = new ToolStripMenuItem();
            ToolStripMenuItemOption = new ToolStripMenuItem();
            ToolStripMenuItemConfig = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            ToolStripMenuItemLanguage = new ToolStripMenuItem();
            pictureFace = new PictureBox();
            pictureFlagNum = new PictureBox();
            pictureTime = new PictureBox();
            gameTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)MineFrame).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MineField).BeginInit();
            menuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureFace).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureFlagNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureTime).BeginInit();
            SuspendLayout();
            // 
            // MineFrame
            // 
            MineFrame.BackColor = SystemColors.Control;
            MineFrame.Location = new Point(1, 35);
            MineFrame.Margin = new Padding(0);
            MineFrame.Name = "MineFrame";
            MineFrame.Size = new Size(336, 350);
            MineFrame.TabIndex = 3;
            MineFrame.TabStop = false;
            MineFrame.Paint += MineFrame_Paint;
            MineFrame.MouseDown += OutsideMineField_MouseDown;
            MineFrame.MouseMove += OutsideMineField_MouseMove;
            MineFrame.MouseUp += OutsideMineField_MouseUp;
            // 
            // MineField
            // 
            MineField.Location = new Point(32, 58);
            MineField.Margin = new Padding(4, 5, 4, 5);
            MineField.Name = "MineField";
            MineField.Size = new Size(62, 84);
            MineField.TabIndex = 5;
            MineField.TabStop = false;
            MineField.Paint += MineField_Paint;
            MineField.MouseCaptureChanged += MineField_MouseCaptureChanged;
            MineField.MouseDown += MineField_MouseDown;
            MineField.MouseMove += MineField_MouseMove;
            MineField.MouseUp += MineField_MouseUp;
            // 
            // menuMain
            // 
            menuMain.ImageScalingSize = new Size(20, 20);
            menuMain.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemGame, ToolStripMenuItemOption });
            menuMain.Location = new Point(0, 0);
            menuMain.Name = "menuMain";
            menuMain.Padding = new Padding(5, 2, 0, 2);
            menuMain.Size = new Size(346, 25);
            menuMain.TabIndex = 6;
            menuMain.Text = "menuStrip1";
            // 
            // ToolStripMenuItemGame
            // 
            ToolStripMenuItemGame.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemStart, ToolStripMenuItemRestart, toolStripMenuItem1, ToolStripMenuItemBeginner, ToolStripMenuItemIntermediate, ToolStripMenuItemExpert, ToolStripMenuItemCustomize, toolStripMenuItem4, ToolStripMenuItemBestTimes, toolStripMenuItem5, ToolStripMenuItemExit });
            ToolStripMenuItemGame.Name = "ToolStripMenuItemGame";
            ToolStripMenuItemGame.ShortcutKeys = Keys.F2;
            ToolStripMenuItemGame.Size = new Size(44, 21);
            ToolStripMenuItemGame.Text = "游戏";
            // 
            // ToolStripMenuItemStart
            // 
            ToolStripMenuItemStart.Name = "ToolStripMenuItemStart";
            ToolStripMenuItemStart.ShortcutKeys = Keys.F2;
            ToolStripMenuItemStart.Size = new Size(145, 22);
            ToolStripMenuItemStart.Text = "新游戏";
            ToolStripMenuItemStart.Click += ToolStripMenuItemStart_Click;
            // 
            // ToolStripMenuItemRestart
            // 
            ToolStripMenuItemRestart.Enabled = false;
            ToolStripMenuItemRestart.Name = "ToolStripMenuItemRestart";
            ToolStripMenuItemRestart.ShortcutKeys = Keys.F3;
            ToolStripMenuItemRestart.Size = new Size(145, 22);
            ToolStripMenuItemRestart.Text = "重玩";
            ToolStripMenuItemRestart.Click += ToolStripMenuItemRestart_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(142, 6);
            // 
            // ToolStripMenuItemBeginner
            // 
            ToolStripMenuItemBeginner.Name = "ToolStripMenuItemBeginner";
            ToolStripMenuItemBeginner.Size = new Size(145, 22);
            ToolStripMenuItemBeginner.Text = "初级";
            ToolStripMenuItemBeginner.Click += ToolStripMenuItemBeginner_Click;
            // 
            // ToolStripMenuItemIntermediate
            // 
            ToolStripMenuItemIntermediate.Name = "ToolStripMenuItemIntermediate";
            ToolStripMenuItemIntermediate.Size = new Size(145, 22);
            ToolStripMenuItemIntermediate.Text = "中级";
            ToolStripMenuItemIntermediate.Click += ToolStripMenuItemIntermediate_Click;
            // 
            // ToolStripMenuItemExpert
            // 
            ToolStripMenuItemExpert.Name = "ToolStripMenuItemExpert";
            ToolStripMenuItemExpert.Size = new Size(145, 22);
            ToolStripMenuItemExpert.Text = "高级";
            ToolStripMenuItemExpert.Click += ToolStripMenuItemExpert_Click;
            // 
            // ToolStripMenuItemCustomize
            // 
            ToolStripMenuItemCustomize.Name = "ToolStripMenuItemCustomize";
            ToolStripMenuItemCustomize.Size = new Size(145, 22);
            ToolStripMenuItemCustomize.Text = "自定义...";
            ToolStripMenuItemCustomize.Click += ToolStripMenuItemCustomize_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(142, 6);
            // 
            // ToolStripMenuItemBestTimes
            // 
            ToolStripMenuItemBestTimes.Name = "ToolStripMenuItemBestTimes";
            ToolStripMenuItemBestTimes.Size = new Size(145, 22);
            ToolStripMenuItemBestTimes.Text = "最佳时间...";
            ToolStripMenuItemBestTimes.Click += ToolStripMenuItemBestTimes_Click;
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(142, 6);
            // 
            // ToolStripMenuItemExit
            // 
            ToolStripMenuItemExit.Name = "ToolStripMenuItemExit";
            ToolStripMenuItemExit.ShortcutKeys = Keys.Alt | Keys.F4;
            ToolStripMenuItemExit.Size = new Size(145, 22);
            ToolStripMenuItemExit.Text = "退出";
            ToolStripMenuItemExit.Click += ToolStripMenuItemExit_Click;
            // 
            // ToolStripMenuItemOption
            // 
            ToolStripMenuItemOption.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItemConfig, toolStripMenuItem2, ToolStripMenuItemLanguage });
            ToolStripMenuItemOption.Name = "ToolStripMenuItemOption";
            ToolStripMenuItemOption.Size = new Size(44, 21);
            ToolStripMenuItemOption.Text = "选项";
            // 
            // ToolStripMenuItemConfig
            // 
            ToolStripMenuItemConfig.Name = "ToolStripMenuItemConfig";
            ToolStripMenuItemConfig.Size = new Size(180, 22);
            ToolStripMenuItemConfig.Text = "配置";
            ToolStripMenuItemConfig.Click += ToolStripMenuItemConfig_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(177, 6);
            // 
            // ToolStripMenuItemLanguage
            // 
            ToolStripMenuItemLanguage.Name = "ToolStripMenuItemLanguage";
            ToolStripMenuItemLanguage.Size = new Size(180, 22);
            ToolStripMenuItemLanguage.Text = "语言";
            // 
            // pictureFace
            // 
            pictureFace.Location = new Point(14, 171);
            pictureFace.Margin = new Padding(4, 5, 4, 5);
            pictureFace.Name = "pictureFace";
            pictureFace.Size = new Size(28, 34);
            pictureFace.TabIndex = 7;
            pictureFace.TabStop = false;
            pictureFace.Paint += pictureFace_Paint;
            pictureFace.MouseDown += pictureFace_MouseDown;
            pictureFace.MouseMove += pictureFace_MouseMove;
            pictureFace.MouseUp += pictureFace_MouseUp;
            // 
            // pictureFlagNum
            // 
            pictureFlagNum.BackColor = SystemColors.Control;
            pictureFlagNum.Location = new Point(113, 58);
            pictureFlagNum.Margin = new Padding(0);
            pictureFlagNum.Name = "pictureFlagNum";
            pictureFlagNum.Size = new Size(97, 41);
            pictureFlagNum.TabIndex = 8;
            pictureFlagNum.TabStop = false;
            pictureFlagNum.Paint += pictureFlagNum_Paint;
            pictureFlagNum.MouseDown += OutsideMineField_MouseDown;
            pictureFlagNum.MouseMove += OutsideMineField_MouseMove;
            pictureFlagNum.MouseUp += OutsideMineField_MouseUp;
            // 
            // pictureTime
            // 
            pictureTime.BackColor = SystemColors.Control;
            pictureTime.Location = new Point(113, 100);
            pictureTime.Margin = new Padding(0);
            pictureTime.Name = "pictureTime";
            pictureTime.Size = new Size(53, 41);
            pictureTime.TabIndex = 9;
            pictureTime.TabStop = false;
            pictureTime.Paint += pictureTime_Paint;
            pictureTime.MouseDown += OutsideMineField_MouseDown;
            pictureTime.MouseMove += OutsideMineField_MouseMove;
            pictureTime.MouseUp += OutsideMineField_MouseUp;
            // 
            // gameTimer
            // 
            gameTimer.Interval = 1000;
            gameTimer.Tick += gameTimer_Tick;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(346, 499);
            Controls.Add(pictureTime);
            Controls.Add(pictureFlagNum);
            Controls.Add(pictureFace);
            Controls.Add(MineField);
            Controls.Add(MineFrame);
            Controls.Add(menuMain);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuMain;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MineSweeper";
            FormClosed += FormMain_FormClosed;
            Load += FormMain_Load;
            KeyPress += FormMain_KeyPress;
            ((System.ComponentModel.ISupportInitialize)MineFrame).EndInit();
            ((System.ComponentModel.ISupportInitialize)MineField).EndInit();
            menuMain.ResumeLayout(false);
            menuMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureFace).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureFlagNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureTime).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox MineFrame;
        private System.Windows.Forms.PictureBox MineField;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemGame;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemStart;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExit;
        private System.Windows.Forms.PictureBox pictureFace;
        private System.Windows.Forms.PictureBox pictureFlagNum;
        private System.Windows.Forms.PictureBox pictureTime;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemBeginner;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemIntermediate;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemExpert;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemCustomize;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemBestTimes;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemRestart;
        private ToolStripMenuItem ToolStripMenuItemOption;
        private ToolStripMenuItem ToolStripMenuItemConfig;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem ToolStripMenuItemLanguage;
    }
}

