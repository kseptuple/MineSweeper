
using MineSweeper.Core;
using MineSweeper.Lang;
using MineSweeper.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MineSweeper
{
    public partial class FormMain : Form
    {
        private readonly MouseButtons validButtons = MouseButtons.Left | MouseButtons.Right | MouseButtons.Middle;
        private const int cellSize = 16;
        private const int faceSize = 24;
        private const int digitWidth = 13;
        private const int digitHeight = 23;

        private const int cellImageCount = 17;
        private const int faceImageCount = 5;
        private const int digitImageCount = 12;



        private MineFields field = null;

        //鼠标移动时，重绘格子
        private int previousX = -1;
        private int previousY = -1;

        //无视左键的状态，用于双键打开后的状态
        private bool ignoreLeftClick = false;

        public int MineWidth { get; set; }
        public int MineHeight { get; set; }
        public int TotalMines { get; set; }

        private bool allowMark => SettingProvider.Settings.Config.GameConfig.AllowMark;
        private bool allowFlag => SettingProvider.Settings.Config.GameConfig.AllowFlag;
        private MineFields.FirstClickType FirstClickType => SettingProvider.Settings.Config.GameConfig.FirstClickType;

        private bool show4DigitsNumber => SettingProvider.Settings.Config.GameConfig.Show4DigitsNumber;
        private bool showMines => SettingProvider.Settings.Config.Cheat.ShowMines;
        private bool allowHighScoreInRestartGame => SettingProvider.Settings.Config.GameConfig.AllowHighScoreInRestartGame;
        private bool timeStartFromZero => SettingProvider.Settings.Config.GameConfig.TimeStartFromZero;

        public DifficultyInfo CurrentDifficulty { get; private set; }

        private Bitmap[] mineCellBitmap = new Bitmap[cellImageCount];
        private Bitmap[] faceBitmap = new Bitmap[faceImageCount];
        private Bitmap[] numbersBitmap = new Bitmap[digitImageCount];

        //used for painting borders
        private const int mainBorderWidth = 6;
        private readonly Pen whitePen = new Pen(Color.FromArgb(255, 255, 255));
        private readonly Pen darkPen = new Pen(Color.FromArgb(128, 128, 128));
        private readonly Brush lightBrush = new SolidBrush(Color.FromArgb(192, 192, 192));

        //used when painting is needed not inside that control's event 
        private Graphics mineFieldGraphic = null;
        private Graphics faceGraphic = null;

        //only used for display
        private int time = 0;
        //used for best time
        private int startTime = 0;
        private int endTime = 0;


        //preloaded forms
        private FormCustom formCustom = null;
        private FormBestTimes formBestTimes = null;
        private FormNewRecord formNewRecord = null;
        private FormConfig formConfig = null;

        public FormMain()
        {
            InitializeComponent();
            MineFrame.BackColor = Color.FromArgb(192, 192, 192);

            //initializing resources
            Bitmap mineCells = Resources.MineCells;
            Bitmap faces = Resources.Faces;
            Bitmap numbers = Resources.Numbers;
            for (int i = 0; i < cellImageCount; i++)
            {
                mineCellBitmap[i] = mineCells.Clone(new Rectangle(0, (cellImageCount - 1) * cellSize - cellSize * i, cellSize, cellSize), mineCells.PixelFormat);
            }
            for (int i = 0; i < faceImageCount; i++)
            {
                faceBitmap[i] = faces.Clone(new Rectangle(0, (faceImageCount - 1) * faceSize - faceSize * i, faceSize, faceSize), faces.PixelFormat);
            }
            for (int i = 0; i < digitImageCount; i++)
            {
                numbersBitmap[i] = numbers.Clone(new Rectangle(0, (digitImageCount - 1) * digitHeight - digitHeight * i, digitWidth, digitHeight), numbers.PixelFormat);
            }

            //pre-initialize forms
            formCustom = new FormCustom(this);
            formBestTimes = new FormBestTimes();
            formNewRecord = new FormNewRecord(this);
            formConfig = new FormConfig();

            initLangMenu();
            changeDifficulty(DifficultyInfo.Difficulties[(int)SettingProvider.Settings.Config.GameConfig.Difficulty]);

        }

        private void initLangMenu()
        {
            if (L10N.LanguageModels.Count > 1)
            {
                foreach (var language in L10N.LanguageModels)
                {
                    ToolStripMenuItem LanguageItem = new ToolStripMenuItem();
                    LanguageItem.Text = language.Name;
                    LanguageItem.Tag = language.AreaCode;
                    LanguageItem.Click += ToolStripMenuItemLanguageItem_Click;
                    ToolStripMenuItemLanguage.DropDownItems.Add(LanguageItem);
                }
                ToolStripMenuItemLanguage.Visible = true;
            }

            var actualLanguage = L10N.GetLang(SettingProvider.Settings.Config.Lang);
            if (!string.IsNullOrEmpty(actualLanguage))
            {
                L10N.SetUIText(this, actualLanguage);
                DifficultyInfo.SetDifficultyName();
                var languageMenuItems = ToolStripMenuItemLanguage.DropDownItems;
                if (languageMenuItems != null)
                {
                    foreach (ToolStripMenuItem languageMenuItem in languageMenuItems)
                    {
                        if (languageMenuItem.Tag.ToString() == actualLanguage)
                        {
                            languageMenuItem.Checked = true;
                            break;
                        }
                    }
                }
            }
        }

        private void ToolStripMenuItemLanguageItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem target = sender as ToolStripMenuItem;
            if (target != null)
            {
                var languageMenuItems = ToolStripMenuItemLanguage.DropDownItems;
                if (languageMenuItems != null)
                {
                    foreach (ToolStripMenuItem languageMenuItem in languageMenuItems)
                    {
                        languageMenuItem.Checked = false;
                    }
                }
                target.Checked = true;
                var lang = target.Tag as string;
                SettingProvider.Settings.Config.Lang = lang;
                L10N.SetUIText(this, lang);
                DifficultyInfo.SetDifficultyName();
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            switch (CurrentDifficulty.Id)
            {
                case 0:
                    ToolStripMenuItemBeginner.Checked = true;
                    break;
                case 1:
                    ToolStripMenuItemIntermediate.Checked = true;
                    break;
                case 2:
                    ToolStripMenuItemExpert.Checked = true;
                    break;
                case 3:
                    ToolStripMenuItemCustomize.Checked = true;
                    break;
            }
            Top = SettingProvider.Settings.Config.WindowTop;
            Left = SettingProvider.Settings.Config.WindowLeft;
            ToolStripMenuItemStart_Click(sender, e);
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //release objects
            //mineFieldGraphic?.Dispose();
            //faceGraphic?.Dispose();
            //formCustom?.Dispose();
            //formBestTimes?.Dispose();
            //formNewRecord?.Dispose();
            //formConfig?.Dispose();

            //save settings


            //SettingProvider.Settings.Config.GameConfig.AllowFlag = AllowFlag;
            //SettingProvider.Settings.Config.GameConfig.AllowMark = AllowMark;

            //SettingProvider.Settings.Config.GameConfig.Difficulty = (Difficulty)CurrentDifficulty.Id;

            //setting.HighScoreBeginner = DifficultyInfo.Beginner.HighScore;
            //setting.HighScoreIntermediate = DifficultyInfo.Intermediate.HighScore;
            //setting.HighScoreExpert = DifficultyInfo.Expert.HighScore;
            //setting.HighScoreBeginnerName = DifficultyInfo.Beginner.HighScoreName;
            //setting.HighScoreIntermediateName = DifficultyInfo.Intermediate.HighScoreName;
            //setting.HighScoreExpertName = DifficultyInfo.Expert.HighScoreName;

            SettingProvider.Settings.Config.WindowTop = Top;
            SettingProvider.Settings.Config.WindowLeft = Left;

            //SettingProvider.Settings.Config.CustomizedConfig.Height = field?.Height ?? 9;
            //SettingProvider.Settings.Config.CustomizedConfig.Width = field?.Width ?? 9;
            //SettingProvider.Settings.Config.CustomizedConfig.MineCount = field?.MineNumbers ?? 10;

            //SettingProvider.Settings.Config.GameConfig.FirstClickType = FirstClick;
            //SettingProvider.Settings.Config.GameConfig.Show4DigitsNumber = Show4DigitsNumber;
            //SettingProvider.Settings.Config.GameConfig.AllowHighScoreInRestartGame = AllowHighScoreInRestartGame;
            //SettingProvider.Settings.Config.GameConfig.TimeStartFromZero = TimeStartFromZero;

            //SettingProvider.Settings.Config.Cheat.ShowMines = ShowMines;

            SettingProvider.SaveSettings();


            Application.Exit();
        }

        //press esc to minimize
        private void FormMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                WindowState = FormWindowState.Minimized;
            }
        }

        private void ToolStripMenuItemStart_Click(object sender, EventArgs e)
        {
            int digits = show4DigitsNumber ? 4 : 3;
            field = new MineFields(MineWidth, MineHeight, TotalMines);

            //reset control position
            #region reset control position
            //do not make the form too small
            MineFrame.Width = (MineWidth < 9 ? 9 : MineWidth) * cellSize + mainBorderWidth * 2 + 6;
            MineFrame.Height = MineHeight * cellSize + mainBorderWidth * 3 + 43;
            MineField.Top = MineFrame.Top + mainBorderWidth * 2 + 40;
            MineField.Left = MineFrame.Left + mainBorderWidth + 3;
            MineField.Width = MineWidth * cellSize;
            MineField.Height = MineHeight * cellSize;
            pictureFace.Top = MineFrame.Top + mainBorderWidth + 8;
            pictureFace.Left = MineFrame.Left + MineFrame.ClientRectangle.Width / 2 - 12;
            pictureFace.Width = faceSize;
            pictureFace.Height = faceSize;
            pictureFlagNum.Left = MineFrame.Left + mainBorderWidth + 7;
            pictureFlagNum.Top = MineFrame.Top + mainBorderWidth + 8;
            pictureFlagNum.Height = digitHeight;
            pictureFlagNum.Width = digits * digitWidth;

            pictureTime.Left = MineFrame.Left + MineFrame.ClientRectangle.Width - mainBorderWidth - digits * digitWidth - 8;
            pictureTime.Top = MineFrame.Top + mainBorderWidth + 8;
            pictureTime.Height = digitHeight;
            pictureTime.Width = digits * digitWidth;

            //try to move the form back to screen
            Rectangle rect = Screen.FromControl(this).WorkingArea;
            if (Bottom > rect.Height)
            {
                if (Height > rect.Height)
                    Top = 0;
                else
                    Top = rect.Height - Height;
            }
            if (Right > rect.Width)
            {
                if (Width > rect.Width)
                    Left = 0;
                else
                    Left = rect.Width - Width;
            }
            #endregion

            //required, because the controls are moved and resized
            mineFieldGraphic?.Dispose();
            mineFieldGraphic = MineField.CreateGraphics();
            faceGraphic?.Dispose();
            faceGraphic = pictureFace.CreateGraphics();

            resetGame();
        }

        private void ToolStripMenuItemRestart_Click(object sender, EventArgs e)
        {
            field.RestartGame();
            resetGame();
        }

        private void resetGame()
        {
            field.FirstClickProtection = FirstClickType;
            field.AllowMark = allowMark;
            field.AllowFlag = allowFlag;
            MineFrame.Refresh();
            MineField.Refresh();

            //isAutoOpen = false;
            ignoreLeftClick = false;

            gameTimer.Enabled = false;
            ToolStripMenuItemRestart.Enabled = false;
            time = 0;
            pictureTime.Refresh();
            pictureFlagNum.Refresh();
            pictureFace.Refresh();
        }

        private void ToolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ToolStripMenuItemBeginner_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemBeginner.Checked = true;
            ToolStripMenuItemIntermediate.Checked = false;
            ToolStripMenuItemExpert.Checked = false;
            ToolStripMenuItemCustomize.Checked = false;
            changeDifficulty(DifficultyInfo.Beginner);
            ToolStripMenuItemStart_Click(sender, e);
        }

        private void ToolStripMenuItemIntermediate_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemBeginner.Checked = false;
            ToolStripMenuItemIntermediate.Checked = true;
            ToolStripMenuItemExpert.Checked = false;
            ToolStripMenuItemCustomize.Checked = false;
            changeDifficulty(DifficultyInfo.Intermediate);
            ToolStripMenuItemStart_Click(sender, e);
        }

        private void ToolStripMenuItemExpert_Click(object sender, EventArgs e)
        {
            ToolStripMenuItemBeginner.Checked = false;
            ToolStripMenuItemIntermediate.Checked = false;
            ToolStripMenuItemExpert.Checked = true;
            ToolStripMenuItemCustomize.Checked = false;
            changeDifficulty(DifficultyInfo.Expert);
            ToolStripMenuItemStart_Click(sender, e);
        }

        private void ToolStripMenuItemCustomize_Click(object sender, EventArgs e)
        {
            var result = formCustom.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                ToolStripMenuItemBeginner.Checked = false;
                ToolStripMenuItemIntermediate.Checked = false;
                ToolStripMenuItemExpert.Checked = false;
                ToolStripMenuItemCustomize.Checked = true;
                changeDifficulty(DifficultyInfo.Customized);
                ToolStripMenuItemStart_Click(sender, e);
            }
        }

        private void changeDifficulty(DifficultyInfo difficulty)
        {
            CurrentDifficulty = difficulty;
            MineHeight = CurrentDifficulty.Height;
            MineWidth = CurrentDifficulty.Width;
            TotalMines = CurrentDifficulty.Mines;
            SettingProvider.Settings.Config.GameConfig.Difficulty = (Difficulty)CurrentDifficulty.Id;
        }

        private void ToolStripMenuItemConfig_Click(object sender, EventArgs e)
        {
            var result = formConfig.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                MineFrame.Refresh();
                ToolStripMenuItemStart_Click(sender, e);
            }
        }

        private void ToolStripMenuItemBestTimes_Click(object sender, EventArgs e)
        {
            formBestTimes.ShowDialog(this);
        }

        private void MineField_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & validButtons) == 0) return;
            int mineX = e.X / cellSize;
            int mineY = e.Y / cellSize;
            //not initialized
            if (field == null) return;
            //already win or lose
            if (field.IsWin || field.IsLost) return;

            //区域外
            if (mineX > field.Width - 1 || mineY > field.Height - 1 || e.X < 0 || e.Y < 0)
            {
                pictureFace.Refresh();
                return;
            }
            //both button are pressed
            if ((MouseButtons & MouseButtons.Middle) != 0 || MouseButtons == (MouseButtons.Left | MouseButtons.Right))
            {
                previousX = mineX;
                previousY = mineY;
                Helper.CallFor9Cells(paintFieldClick, mineX, mineY);
            }
            else if (e.Button == MouseButtons.Left)
            {
                previousX = mineX;
                previousY = mineY;
                paintFieldClick(mineX, mineY);
            }
            else if (e.Button == MouseButtons.Right)
            {
                field.setFlag(mineX, mineY);
                pictureFlagNum.Refresh();
                MineField.Refresh();
            }
            pictureFace.Refresh();
        }

        private void MineField_MouseMove(object sender, MouseEventArgs e)
        {
            int mineX = e.X / cellSize;
            int mineY = e.Y / cellSize;
            //not initialized
            if (field == null) return;
            //already win or lose
            if (field.IsWin || field.IsLost) return;

            //区域外
            if (mineX > field.Width - 1 || mineY > field.Height - 1 || e.X < 0 || e.Y < 0)
            {
                if (previousX >= 0)
                {
                    MineField.Refresh();
                    previousX = -1;
                }
                return;
            }
            //both button are pressed
            if ((MouseButtons & MouseButtons.Middle) != 0 || MouseButtons == (MouseButtons.Left | MouseButtons.Right))
            {
                if (previousX == mineX && previousY == mineY) return;
                if (previousX >= 0)
                {
                    Helper.CallFor9Cells(paintFieldRelease, previousX, previousY);
                }
                previousX = mineX;
                previousY = mineY;
                Helper.CallFor9Cells(paintFieldClick, mineX, mineY);
                return;
            }
            if (MouseButtons == MouseButtons.Left && !ignoreLeftClick)
            {
                if (previousX == mineX && previousY == mineY) return;
                if (previousX >= 0)
                {
                    paintFieldRelease(previousX, previousY);
                }
                previousX = mineX;
                previousY = mineY;

                paintFieldClick(mineX, mineY);
            }
        }

        private void MineField_MouseUp(object sender, MouseEventArgs e)
        {
            if ((e.Button & validButtons) == 0) return;
            bool doAutoOpen = false;
            int mineX = e.X / cellSize;
            int mineY = e.Y / cellSize;
            //not initialized
            if (field == null) return;
            //already win or lose
            if (field.IsWin || field.IsLost) return;

            //松开右键
            if (e.Button == MouseButtons.Right)
            {
                if ((MouseButtons & MouseButtons.Left) != 0)
                {
                    doAutoOpen = true;
                    ignoreLeftClick = true;
                }
            }
            //松开中键
            else if (e.Button == MouseButtons.Middle)
            {
                doAutoOpen = true;
            }
            //松开左键
            else
            {
                if ((MouseButtons & MouseButtons.Right) != 0)
                {
                    doAutoOpen = true;
                }
            }

            //区域外
            if (mineX > field.Width - 1 || mineY > field.Height - 1 || e.X < 0 || e.Y < 0)
            {
                pictureFace.Refresh();
                return;
            }
            //打开一片
            if (doAutoOpen)
            {
                //on the first click, start the timer
                //like windows minesweeper, invalid auto open alse activate timer
                StartTimer();

                MineFields.MineCell cell = field.getMineCell(mineX, mineY);
                //open 9 cells
                if (cell.State == MineFields.CellState.Opened && field.getSurroundingFlagCount(mineX, mineY) == cell.MineNum)
                {
                    Helper.CallFor9Cells(field.openMine, mineX, mineY);
                }
            }
            else if (e.Button == MouseButtons.Left && !ignoreLeftClick)
            {
                //on the first click, start the timer
                StartTimer();
                field.openMine(mineX, mineY);
            }

            if (e.Button == MouseButtons.Left)
            {
                ignoreLeftClick = false;
            }

            pictureFace.Refresh();
            MineField.Refresh();
            if ((MouseButtons & MouseButtons.Middle) != 0 || ((MouseButtons & MouseButtons.Left) != 0 && (MouseButtons & MouseButtons.Right) != 0))
            {
                Helper.CallFor9Cells(paintFieldClick, mineX, mineY);
            }
            if (field.IsWin)
            {
                endTime = Environment.TickCount;
                int gameTime = endTime - startTime;
                gameTimer.Enabled = false;
                pictureFlagNum.Refresh();
                //test if beat the high score
                if (!showMines && !CurrentDifficulty.IsCustomized)
                {
                    var difficulty = SettingProvider.DifficultyLookup[CurrentDifficulty.Id];
                    if (gameTime < difficulty.Score && (!field.IsRestartedGame || allowHighScoreInRestartGame))
                    {
                        difficulty.Score = gameTime;
                        formNewRecord.ShowDialog(this);
                        formBestTimes.ShowDialog(this);
                    }
                }
            }
            if (field.IsLost)
            {
                gameTimer.Enabled = false;
                pictureFlagNum.Refresh();
            }
        }

        private void StartTimer()
        {
            if (!gameTimer.Enabled)
            {
                if (!timeStartFromZero) time = 1;
                pictureTime.Refresh();
                gameTimer.Enabled = true;
                ToolStripMenuItemRestart.Enabled = true;
                startTime = Environment.TickCount;
            }
        }

        private void MineField_Paint(object sender, PaintEventArgs e)
        {
            if (field == null) return;
            for (int i = 0; i < field.Width; i++)
            {
                for (int j = 0; j < field.Height; j++)
                {
                    MineFields.MineCell cell = field.getMineCell(i, j);
                    switch (cell.State)
                    {
                        case MineFields.CellState.Unopened:
                            if (showMines && cell.HasMine)
                            {
                                e.Graphics.DrawImage(mineCellBitmap[16], i * cellSize, j * cellSize);
                            }
                            else
                            {
                                e.Graphics.DrawImage(mineCellBitmap[15], i * cellSize, j * cellSize);
                            }
                            break;
                        case MineFields.CellState.Opened:
                            if (cell.HasMine)
                                e.Graphics.DrawImage(mineCellBitmap[12], i * cellSize, j * cellSize);
                            else
                                e.Graphics.DrawImage(mineCellBitmap[cell.MineNum], i * 16, j * 16);
                            break;
                        case MineFields.CellState.Flagged:
                            e.Graphics.DrawImage(mineCellBitmap[14], i * cellSize, j * cellSize);
                            break;
                        case MineFields.CellState.Marked:
                            e.Graphics.DrawImage(mineCellBitmap[13], i * cellSize, j * cellSize);
                            break;
                        case MineFields.CellState.OpenedByExplosion:
                            if (cell.HasMine)
                                e.Graphics.DrawImage(mineCellBitmap[10], i * cellSize, j * cellSize);
                            else
                                e.Graphics.DrawImage(mineCellBitmap[11], i * cellSize, j * cellSize);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void paintFieldClick(int xPos, int yPos)
        {
            if (xPos < 0 || yPos < 0 || xPos > field.Width - 1 || yPos > field.Height - 1) return;
            MineFields.MineCell cell = field.getMineCell(xPos, yPos);
            switch (cell.State)
            {
                case MineFields.CellState.Unopened:
                    mineFieldGraphic.DrawImage(mineCellBitmap[0], xPos * cellSize, yPos * cellSize);
                    break;
                case MineFields.CellState.Marked:
                    mineFieldGraphic.DrawImage(mineCellBitmap[9], xPos * cellSize, yPos * cellSize);
                    break;
                default:
                    break;
            }
        }

        private void paintFieldRelease(int xPos, int yPos)
        {
            if (xPos < 0 || yPos < 0 || xPos > field.Width - 1 || yPos > field.Height - 1) return;
            MineFields.MineCell cell = field.getMineCell(xPos, yPos);
            switch (cell.State)
            {
                case MineFields.CellState.Unopened:
                    if (showMines && cell.HasMine)
                    {
                        mineFieldGraphic.DrawImage(mineCellBitmap[16], xPos * cellSize, yPos * cellSize);
                    }
                    else
                    {
                        mineFieldGraphic.DrawImage(mineCellBitmap[15], xPos * cellSize, yPos * cellSize);
                    }
                    break;
                case MineFields.CellState.Marked:
                    mineFieldGraphic.DrawImage(mineCellBitmap[13], xPos * cellSize, yPos * cellSize);
                    break;
                default:
                    break;
            }
        }

        private void MineFrame_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int rightMost = MineFrame.ClientRectangle.Width - mainBorderWidth;
            int bottomMost = MineFrame.ClientRectangle.Height - mainBorderWidth;
            int upperBoxInnerHeight = 33;
            int bottomBoxTop = mainBorderWidth * 2 + upperBoxInnerHeight + 4;
            int digits = show4DigitsNumber ? 4 : 3;
            drawBorder(g, mainBorderWidth, mainBorderWidth, rightMost - mainBorderWidth, upperBoxInnerHeight + 4, 2);
            drawBorder(g, mainBorderWidth, bottomBoxTop, rightMost - mainBorderWidth, bottomMost - bottomBoxTop, 3);
            drawBorder(g, mainBorderWidth + 6, mainBorderWidth + 7, digits * digitWidth + 2, 25, 1);
            drawBorder(g, rightMost - digits * digitWidth - 9, mainBorderWidth + 7, digits * digitWidth + 2, 25, 1);
            g.DrawRectangle(darkPen, MineFrame.ClientRectangle.Width / 2 - digitWidth, mainBorderWidth + 7, 25, 25);
        }

        private void drawBorder(Graphics g, float x, float y, float width, float height, int borderWidth)
        {
            for (int i = 0; i < borderWidth; i++)
            {
                g.DrawLine(darkPen, x, y + i, x + width - 2 - i, y + i);
                g.DrawLine(darkPen, x + i, y + borderWidth, x + i, y + height - 2 - i);
                g.DrawLine(whitePen, x + 1 + i, y + height - 1 - i, x + width - 1, y + height - 1 - i);
                g.DrawLine(whitePen, x + width - 1 - i, y + 1 + i, x + width - 1 - i, y + height - 1 - borderWidth);
                g.FillRectangle(lightBrush, x + i, y + height - 1 - i, 1, 1);
                g.FillRectangle(lightBrush, x + width - 1 - i, y + i, 1, 1);
            }
        }

        private void pictureFace_Paint(object sender, PaintEventArgs e)
        {
            if (field != null && field.IsWin)
            {
                e.Graphics.DrawImage(faceBitmap[3], 0, 0);
                return;
            }
            if (field != null && field.IsLost)
            {
                e.Graphics.DrawImage(faceBitmap[2], 0, 0);
                return;
            }
            if ((MouseButtons & MouseButtons.Middle) == 0 && ((MouseButtons & MouseButtons.Left) == 0 ||
                (ignoreLeftClick && (MouseButtons & MouseButtons.Right) == 0)))
            {
                e.Graphics.DrawImage(faceBitmap[0], 0, 0);
            }
            else
            {
                e.Graphics.DrawImage(faceBitmap[1], 0, 0);
            }
        }

        private void pictureTime_Paint(object sender, PaintEventArgs e)
        {
            paintNumber(e.Graphics, time);
        }

        private void pictureFlagNum_Paint(object sender, PaintEventArgs e)
        {
            paintNumber(e.Graphics, field?.FlagsRemain ?? 0);
        }

        private void paintNumber(Graphics g, int number)
        {
            if (show4DigitsNumber)
            {
                if (number > 9999) number = 9999;
                else if (number < -999) number = -999;
                if (number < 0)
                    g.DrawImage(numbersBitmap[11], 0, 0);
                else
                    g.DrawImage(numbersBitmap[number / 1000], 0, 0);
                g.DrawImage(numbersBitmap[Math.Abs((number / 100) % 10)], digitWidth, 0);
                g.DrawImage(numbersBitmap[Math.Abs((number / 10) % 10)], digitWidth * 2, 0);
                g.DrawImage(numbersBitmap[Math.Abs(number % 10)], digitWidth * 3, 0);
            }
            else
            {
                if (number > 999) number = 999;
                else if (number < -99) number = -99;
                if (number < 0)
                    g.DrawImage(numbersBitmap[11], 0, 0);
                else
                    g.DrawImage(numbersBitmap[number / 100], 0, 0);
                g.DrawImage(numbersBitmap[Math.Abs((number / 10) % 10)], digitWidth, 0);
                g.DrawImage(numbersBitmap[Math.Abs(number % 10)], digitWidth * 2, 0);
            }
        }

        private void pictureFace_MouseDown(object sender, MouseEventArgs e)
        {
            if ((MouseButtons & MouseButtons.Left) == 0) return;
            faceGraphic.DrawImage(faceBitmap[4], 0, 0);
        }

        private void pictureFace_MouseMove(object sender, MouseEventArgs e)
        {
            if ((MouseButtons & MouseButtons.Left) == 0) return;
            if (e.X > faceSize || e.X < 0 || e.Y > faceSize || e.Y < 0)
            {
                faceGraphic.DrawImage(faceBitmap[0], 0, 0);
            }
            else
            {
                faceGraphic.DrawImage(faceBitmap[4], 0, 0);
            }
        }

        private void pictureFace_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            faceGraphic.DrawImage(faceBitmap[0], 0, 0);
            if (e.X >= 0 && e.X <= faceSize && e.Y >= 0 && e.Y <= faceSize)
                ToolStripMenuItemStart_Click(sender, e);
        }

        private void OutsideMineField_MouseDown(object sender, MouseEventArgs e)
        {
            Point mousePos = MineField.PointToClient(((Control)sender).PointToScreen(new Point(e.X, e.Y)));
            int x = mousePos.X;
            int y = mousePos.Y;
            var mouseEvent = new MouseEventArgs(e.Button, e.Clicks, x, y, e.Delta);
            MineField_MouseDown(sender, mouseEvent);
        }

        private void OutsideMineField_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = MineField.PointToClient(((Control)sender).PointToScreen(new Point(e.X, e.Y)));
            int x = mousePos.X;
            int y = mousePos.Y;
            var mouseEvent = new MouseEventArgs(e.Button, e.Clicks, x, y, e.Delta);
            MineField_MouseMove(sender, mouseEvent);
        }

        private void OutsideMineField_MouseUp(object sender, MouseEventArgs e)
        {
            Point mousePos = MineField.PointToClient(((Control)sender).PointToScreen(new Point(e.X, e.Y)));
            int x = mousePos.X;
            int y = mousePos.Y;
            var mouseEvent = new MouseEventArgs(e.Button, e.Clicks, x, y, e.Delta);
            MineField_MouseUp(sender, mouseEvent);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (time >= 999 && !show4DigitsNumber) return;
            if (time >= 9999 && show4DigitsNumber) return;
            time++;
            pictureTime.Refresh();
        }

        private void MineField_MouseCaptureChanged(object sender, EventArgs e)
        {
            //有鼠标按键时不能失去鼠标捕获
            if (!MineField.Capture && MouseButtons != MouseButtons.None)
            {
                MineField.Capture = true;
            }
        }
    }
}