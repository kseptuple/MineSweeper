using Mine.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Mine
{
    public partial class FormMain : Form
    {
        private MineFields field = null;

        //used for repainting on mouse moving
        private int previousX = -1;
        private int previousY = -1;

        //true if both left and right button are pressed
        private bool isAutoOpen = false;
        //true after release one button after both button is pressed
        private bool isAutoOpenReleased = false;

        public int MineWidth { get; set; }
        public int MineHeight { get; set; }
        public int TotalMines { get; set; }

        public bool AllowMark { get; set; }
        public bool AllowFlag { get; set; }
        public MineFields.FirstClickType FirstClick { get; set; }

        public bool Show4DigitsNumber { get; set; }
        public bool AllowCheat { get; set; }
        public bool AllowRestartGameHighScore { get; set; }
        public bool TimeStartFromZero { get; set; }

        public DifficultyInfo CurrentDifficulty { get; private set; }

        private Bitmap[] mineGridBitmap = new Bitmap[17];
        private Bitmap[] faceBitmap = new Bitmap[5];
        private Bitmap[] numbersBitmap = new Bitmap[12];

        //used for painting borders
        private int mainBorder = 6;
        private Pen whitePen = new Pen(Color.FromArgb(255, 255, 255));
        private Pen darkPen = new Pen(Color.FromArgb(128, 128, 128));
        private Brush lightBrush = new SolidBrush(Color.FromArgb(192, 192, 192));

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
            Bitmap mineGrids = Resources.MineGrids;
            Bitmap faces = Resources.Faces;
            Bitmap numbers = Resources.Numbers;
            for (int i = 0; i < 17; i++)
            {
                mineGridBitmap[i] = mineGrids.Clone(new Rectangle(0, 256 - 16 * i, 16, 16), mineGrids.PixelFormat);
            }
            for (int i = 0; i < 5; i++)
            {
                faceBitmap[i] = faces.Clone(new Rectangle(0, 96 - 24 * i, 24, 24), faces.PixelFormat);
            }
            for (int i = 0; i < 12; i++)
            {
                numbersBitmap[i] = numbers.Clone(new Rectangle(0, 253 - 23 * i, 13, 23), numbers.PixelFormat);
            }

            //pre-initialize forms
            formCustom = new FormCustom(this);
            formBestTimes = new FormBestTimes(this);
            formNewRecord = new FormNewRecord(this);
            formConfig = new FormConfig(this);

            //load settings
            changeDifficulty(DifficultyInfo.Difficulties[Settings.Default.Difficulty]);
            AllowMark = Settings.Default.AllowMark;
            AllowFlag = Settings.Default.AllowFlag;
            FirstClick = (MineFields.FirstClickType)Settings.Default.FirstClickType;
            Show4DigitsNumber = Settings.Default.Show4DigitsNumber;
            AllowCheat = Settings.Default.AllowCheat;
            AllowRestartGameHighScore = Settings.Default.AllowRestartGameHighScore;
            TimeStartFromZero = Settings.Default.TimeStartFromZero;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            switch (CurrentDifficulty.Id)
            {
                case 0:
                    beginnerToolStripMenuItem.Checked = true;
                    break;
                case 1:
                    intermediateToolStripMenuItem.Checked = true;
                    break;
                case 2:
                    expertToolStripMenuItem.Checked = true;
                    break;
                case 3:
                    customizeToolStripMenuItem.Checked = true;
                    break;
            }
            Top = Settings.Default.WindowTop;
            Left = Settings.Default.WindowLeft;
            startToolStripMenuItem_Click(sender, e);
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //release objects
            mineFieldGraphic?.Dispose();
            faceGraphic?.Dispose();
            formCustom?.Dispose();
            formBestTimes?.Dispose();
            formNewRecord?.Dispose();
            formConfig?.Dispose();

            //save settings
            #region save settings
            var setting = Settings.Default;
            setting.AllowMark = AllowMark;
            setting.CustomHeight = field?.Height ?? 9;
            setting.CustomWidth = field?.Width ?? 9;
            setting.CustomMines = field?.MineNumbers ?? 10;
            setting.Difficulty = CurrentDifficulty.Id;
            setting.HighScoreBegginer = DifficultyInfo.Beginner.HighScore;
            setting.HighScoreIntermediate = DifficultyInfo.Intermediate.HighScore;
            setting.HighScoreExpert = DifficultyInfo.Expert.HighScore;
            setting.HighScoreBegginerName = DifficultyInfo.Beginner.HighScoreName;
            setting.HighScoreIntermediateName = DifficultyInfo.Intermediate.HighScoreName;
            setting.HighScoreExpertName = DifficultyInfo.Expert.HighScoreName;
            setting.WindowTop = Top;
            setting.WindowLeft = Left;
            setting.AllowFlag = AllowFlag;
            setting.FirstClickType = (int)FirstClick;
            setting.Show4DigitsNumber = Show4DigitsNumber;
            setting.AllowCheat = AllowCheat;
            setting.AllowRestartGameHighScore = AllowRestartGameHighScore;
            setting.TimeStartFromZero = TimeStartFromZero;
            setting.Save();
            #endregion

            Application.Exit();
        }

        //press esc to minimize
        private void FormMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape) WindowState = FormWindowState.Minimized;
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int digits = Show4DigitsNumber ? 4 : 3;
            field = new MineFields(MineWidth, MineHeight, TotalMines);

            //reset control position
            #region reset control position
            //do not make the form too small
            MineFrame.Width = (MineWidth < 9 ? 9 : MineWidth) * 16 + mainBorder * 2 + 6;
            MineFrame.Height = MineHeight * 16 + mainBorder * 3 + 43;
            MineField.Top = MineFrame.Top + mainBorder * 2 + 40;
            MineField.Left = MineFrame.Left + mainBorder + 3;
            MineField.Width = MineWidth * 16;
            MineField.Height = MineHeight * 16;
            pictureFace.Top = MineFrame.Top + mainBorder + 8;
            pictureFace.Left = MineFrame.Left + MineFrame.ClientRectangle.Width / 2 - 12;
            pictureFlagNum.Left = MineFrame.Left + mainBorder + 7;
            pictureFlagNum.Top = MineFrame.Top + mainBorder + 8;
            pictureFlagNum.Height = 23;
            pictureFlagNum.Width = digits * 13;

            pictureTime.Left = MineFrame.Left + MineFrame.ClientRectangle.Width - mainBorder - digits * 13 - 8;
            pictureTime.Top = MineFrame.Top + mainBorder + 8;
            pictureTime.Height = 23;
            pictureTime.Width = digits * 13;

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

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            field.RestartGame();
            resetGame();
        }

        private void resetGame()
        {
            field.FirstClickProtection = FirstClick;
            field.AllowMark = AllowMark;
            field.AllowFlag = AllowFlag;
            MineFrame.Refresh();
            MineField.Refresh();

            isAutoOpen = false;
            isAutoOpenReleased = false;

            gameTimer.Enabled = false;
            restartToolStripMenuItem.Enabled = false;
            time = 0;
            pictureTime.Refresh();
            pictureFlagNum.Refresh();
            pictureFace.Refresh();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void beginnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beginnerToolStripMenuItem.Checked = true;
            intermediateToolStripMenuItem.Checked = false;
            expertToolStripMenuItem.Checked = false;
            customizeToolStripMenuItem.Checked = false;
            changeDifficulty(DifficultyInfo.Beginner);
            startToolStripMenuItem_Click(sender, e);
        }

        private void intermediateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beginnerToolStripMenuItem.Checked = false;
            intermediateToolStripMenuItem.Checked = true;
            expertToolStripMenuItem.Checked = false;
            customizeToolStripMenuItem.Checked = false;
            changeDifficulty(DifficultyInfo.Intermediate);
            startToolStripMenuItem_Click(sender, e);
        }

        private void expertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beginnerToolStripMenuItem.Checked = false;
            intermediateToolStripMenuItem.Checked = false;
            expertToolStripMenuItem.Checked = true;
            customizeToolStripMenuItem.Checked = false;
            changeDifficulty(DifficultyInfo.Expert);
            startToolStripMenuItem_Click(sender, e);
        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = formCustom.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                beginnerToolStripMenuItem.Checked = false;
                intermediateToolStripMenuItem.Checked = false;
                expertToolStripMenuItem.Checked = false;
                customizeToolStripMenuItem.Checked = true;
                changeDifficulty(DifficultyInfo.Customized);
                startToolStripMenuItem_Click(sender, e);
            }
        }

        private void changeDifficulty(DifficultyInfo difficulty)
        {
            CurrentDifficulty = difficulty;
            MineHeight = CurrentDifficulty.Height;
            MineWidth = CurrentDifficulty.Width;
            TotalMines = CurrentDifficulty.Mines;
        }

        private void configToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = formConfig.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                MineFrame.Refresh();
                startToolStripMenuItem_Click(sender, e);
            }
        }

        private void bestTimesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formBestTimes.ShowDialog(this);
        }

        private void MineField_MouseDown(object sender, MouseEventArgs e)
        {
            int mineX = e.X / 16;
            int mineY = e.Y / 16;
            //not initialized
            if (field == null) return;
            //already win or lose
            if (field.IsWin || field.IsLost) return;
            //bugfix
            isAutoOpenReleased = false;

            //outside the field
            if (mineX > field.Width - 1 || mineY > field.Height - 1 || e.X < 0 || e.Y < 0)
            {
                if ((MouseButtons & MouseButtons.Left) != 0)
                {
                    paintFaceMouseDown();
                    if ((MouseButtons & MouseButtons.Right) != 0)
                    {
                        isAutoOpen = true;
                    }
                }

                return;
            }
            //both button are pressed
            if (MouseButtons == (MouseButtons.Left | MouseButtons.Right))
            {
                paintFaceMouseDown();
                isAutoOpen = true;
                previousX = mineX;
                previousY = mineY;
                paintFieldClick(mineX - 1, mineY - 1);
                paintFieldClick(mineX - 1, mineY);
                paintFieldClick(mineX - 1, mineY + 1);
                paintFieldClick(mineX, mineY - 1);
                paintFieldClick(mineX, mineY);
                paintFieldClick(mineX, mineY + 1);
                paintFieldClick(mineX + 1, mineY - 1);
                paintFieldClick(mineX + 1, mineY);
                paintFieldClick(mineX + 1, mineY + 1);

                return;
            }
            isAutoOpen = false;
            if (e.Button == MouseButtons.Left)
            {
                paintFaceMouseDown();
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
        }

        private void MineField_MouseMove(object sender, MouseEventArgs e)
        {
            int mineX = e.X / 16;
            int mineY = e.Y / 16;
            //not initialized
            if (field == null) return;
            //already win or lose
            if (field.IsWin || field.IsLost) return;
            //outside the field
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
            if (MouseButtons == (MouseButtons.Left | MouseButtons.Right))
            {
                isAutoOpen = true;
                if (previousX == mineX && previousY == mineY) return;
                if (previousX >= 0)
                {
                    paintFieldRelease(previousX - 1, previousY - 1);
                    paintFieldRelease(previousX - 1, previousY);
                    paintFieldRelease(previousX - 1, previousY + 1);
                    paintFieldRelease(previousX, previousY - 1);
                    paintFieldRelease(previousX, previousY);
                    paintFieldRelease(previousX, previousY + 1);
                    paintFieldRelease(previousX + 1, previousY - 1);
                    paintFieldRelease(previousX + 1, previousY);
                    paintFieldRelease(previousX + 1, previousY + 1);
                }
                previousX = mineX;
                previousY = mineY;
                paintFieldClick(mineX - 1, mineY - 1);
                paintFieldClick(mineX - 1, mineY);
                paintFieldClick(mineX - 1, mineY + 1);
                paintFieldClick(mineX, mineY - 1);
                paintFieldClick(mineX, mineY);
                paintFieldClick(mineX, mineY + 1);
                paintFieldClick(mineX + 1, mineY - 1);
                paintFieldClick(mineX + 1, mineY);
                paintFieldClick(mineX + 1, mineY + 1);
                return;
            }
            isAutoOpen = false;
            if (e.Button == MouseButtons.Left && !isAutoOpenReleased)
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
            if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right) return;
            int mineX = e.X / 16;
            int mineY = e.Y / 16;
            //not initialized
            if (field == null) return;
            //already win or lose
            if (field.IsWin || field.IsLost) return;
            //outside the field
            if (mineX > field.Width - 1 || mineY > field.Height - 1 || e.X < 0 || e.Y < 0)
            {
                paintFaceMouseUp();
                if (isAutoOpen)
                {
                    isAutoOpen = false;
                    isAutoOpenReleased = true;
                }
                //not work, MouseUp event only triggered once if outside the form (bug?)
                //else if (MouseButtons == MouseButtons.None)
                //{ 
                //    isAutoOpenReleased = false;                    
                //}
                return;
            }
            //release button after both button pressed
            if (isAutoOpen)
            {
                //on the first click, start the timer
                //like windows minesweeper, invalid auto open alse activate timer
                if (!gameTimer.Enabled)
                {
                    if (!TimeStartFromZero) time = 1;
                    pictureTime.Refresh();
                    gameTimer.Enabled = true;
                    restartToolStripMenuItem.Enabled = true;
                    startTime = Environment.TickCount;
                }
                isAutoOpen = false;
                isAutoOpenReleased = true;
                MineFields.MineGrid grid = field.getMineGrid(mineX, mineY);
                //open 9 grids
                if (grid.State == MineFields.GridState.Opened &&
                    field.getSurroundingFlagCount(mineX, mineY) == grid.MineNum)
                {
                    field.openMine(mineX - 1, mineY - 1);
                    field.openMine(mineX - 1, mineY);
                    field.openMine(mineX - 1, mineY + 1);
                    field.openMine(mineX, mineY - 1);
                    field.openMine(mineX, mineY);
                    field.openMine(mineX, mineY + 1);
                    field.openMine(mineX + 1, mineY - 1);
                    field.openMine(mineX + 1, mineY);
                    field.openMine(mineX + 1, mineY + 1);
                }
                //do not return here
            }
            else if (e.Button == MouseButtons.Left && !isAutoOpenReleased)
            {
                //on the first click, start the timer
                if (!gameTimer.Enabled)
                {
                    if (!TimeStartFromZero) time = 1;
                    pictureTime.Refresh();
                    gameTimer.Enabled = true;
                    restartToolStripMenuItem.Enabled = true;
                    startTime = Environment.TickCount;
                }
                field.openMine(mineX, mineY);
            }
            else if (MouseButtons == MouseButtons.None)
            {
                isAutoOpenReleased = false;
                return;
            }
            MineField.Refresh();
            pictureFace.Refresh();
            if (field.IsWin)
            {
                endTime = Environment.TickCount;
                int gameTime = endTime - startTime;
                gameTimer.Enabled = false;
                pictureFlagNum.Refresh();
                //test if beat the high score
                if (!AllowCheat && !CurrentDifficulty.IsCustomized && gameTime < CurrentDifficulty.HighScore)
                {
                    if (!field.IsRestartedGame || AllowRestartGameHighScore)
                    {
                        CurrentDifficulty.HighScore = gameTime;
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

        private void MineField_Paint(object sender, PaintEventArgs e)
        {
            if (field == null) return;
            for (int i = 0; i < field.Width; i++)
            {
                for (int j = 0; j < field.Height; j++)
                {
                    MineFields.MineGrid grid = field.getMineGrid(i, j);
                    switch (grid.State)
                    {
                        case MineFields.GridState.Unopened:
                            if (AllowCheat && grid.HasMine)
                            {
                                e.Graphics.DrawImage(mineGridBitmap[16], i * 16, j * 16);
                            }
                            else
                            {
                                e.Graphics.DrawImage(mineGridBitmap[15], i * 16, j * 16);
                            }
                            break;
                        case MineFields.GridState.Opened:
                            if (grid.HasMine)
                                e.Graphics.DrawImage(mineGridBitmap[12], i * 16, j * 16);
                            else
                                e.Graphics.DrawImage(mineGridBitmap[grid.MineNum], i * 16, j * 16);
                            break;
                        case MineFields.GridState.Flagged:
                            e.Graphics.DrawImage(mineGridBitmap[14], i * 16, j * 16);
                            break;
                        case MineFields.GridState.Marked:
                            e.Graphics.DrawImage(mineGridBitmap[13], i * 16, j * 16);
                            break;
                        case MineFields.GridState.OpenedByExplosion:
                            if (grid.HasMine)
                                e.Graphics.DrawImage(mineGridBitmap[10], i * 16, j * 16);
                            else
                                e.Graphics.DrawImage(mineGridBitmap[11], i * 16, j * 16);
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
            MineFields.MineGrid grid = field.getMineGrid(xPos, yPos);
            switch (grid.State)
            {
                case MineFields.GridState.Unopened:
                    mineFieldGraphic.DrawImage(mineGridBitmap[0], xPos * 16, yPos * 16);
                    break;
                case MineFields.GridState.Marked:
                    mineFieldGraphic.DrawImage(mineGridBitmap[9], xPos * 16, yPos * 16);
                    break;
                default:
                    break;
            }
        }

        private void paintFieldRelease(int xPos, int yPos)
        {
            if (xPos < 0 || yPos < 0 || xPos > field.Width - 1 || yPos > field.Height - 1) return;
            MineFields.MineGrid grid = field.getMineGrid(xPos, yPos);
            switch (grid.State)
            {
                case MineFields.GridState.Unopened:
                    mineFieldGraphic.DrawImage(mineGridBitmap[15], xPos * 16, yPos * 16);
                    break;
                case MineFields.GridState.Marked:
                    mineFieldGraphic.DrawImage(mineGridBitmap[13], xPos * 16, yPos * 16);
                    break;
                default:
                    break;
            }
        }

        private void MineFrame_Paint(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;
            int rightMost = MineFrame.ClientRectangle.Width - mainBorder;
            int bottomMost = MineFrame.ClientRectangle.Height - mainBorder;
            int upperBoxInnerHeight = 33;
            int bottomBoxTop = mainBorder * 2 + upperBoxInnerHeight + 4;
            int digits = Show4DigitsNumber ? 4 : 3;
            drawBorder(g, mainBorder, mainBorder, rightMost - mainBorder, upperBoxInnerHeight + 4, 2);
            drawBorder(g, mainBorder, bottomBoxTop, rightMost - mainBorder, bottomMost - bottomBoxTop, 3);
            drawBorder(g, mainBorder + 6, mainBorder + 7, digits * 13 + 2, 25, 1);
            drawBorder(g, rightMost - digits * 13 - 9, mainBorder + 7, digits * 13 + 2, 25, 1);
            g.DrawRectangle(darkPen, MineFrame.ClientRectangle.Width / 2 - 13, mainBorder + 7, 25, 25);
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
            e.Graphics.DrawImage(faceBitmap[0], 0, 0);
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
            if (Show4DigitsNumber)
            {
                if (number > 9999) number = 9999;
                else if (number < -999) number = -999;
                if (number < 0)
                    g.DrawImage(numbersBitmap[11], 0, 0);
                else
                    g.DrawImage(numbersBitmap[number / 1000], 0, 0);
                g.DrawImage(numbersBitmap[Math.Abs((number / 100) % 10)], 13, 0);
                g.DrawImage(numbersBitmap[Math.Abs((number / 10) % 10)], 26, 0);
                g.DrawImage(numbersBitmap[Math.Abs(number % 10)], 39, 0);
            }
            else
            {
                if (number > 999) number = 999;
                else if (number < -99) number = -99;
                if (number < 0)
                    g.DrawImage(numbersBitmap[11], 0, 0);
                else
                    g.DrawImage(numbersBitmap[number / 100], 0, 0);
                g.DrawImage(numbersBitmap[Math.Abs((number / 10) % 10)], 13, 0);
                g.DrawImage(numbersBitmap[Math.Abs(number % 10)], 26, 0);
            }
        }

        private void paintFaceMouseDown()
        {
            faceGraphic.DrawImage(faceBitmap[1], 0, 0);
        }

        private void paintFaceMouseUp()
        {
            faceGraphic.DrawImage(faceBitmap[0], 0, 0);
        }

        private void pictureFace_MouseDown(object sender, MouseEventArgs e)
        {
            if ((MouseButtons & MouseButtons.Left) == 0) return;
            faceGraphic.DrawImage(faceBitmap[4], 0, 0);
        }

        private void pictureFace_MouseMove(object sender, MouseEventArgs e)
        {
            if ((MouseButtons & MouseButtons.Left) == 0) return;
            if (e.X > 24 || e.X < 0 || e.Y > 24 || e.Y < 0)
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
            if (e.X >= 0 && e.X <= 24 && e.Y >= 0 && e.Y <= 24)
                startToolStripMenuItem_Click(sender, e);
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
            if (time >= 999 && !Show4DigitsNumber) return;
            if (time >= 9999 && Show4DigitsNumber) return;
            time++;
            pictureTime.Refresh();
        }
    }
}