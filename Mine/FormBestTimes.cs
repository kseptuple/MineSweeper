using System;
using System.Windows.Forms;

namespace Mine
{
    public partial class FormBestTimes : Form
    {
        private FormMain parent = null;
        public FormBestTimes()
        {
            InitializeComponent();
        }

        public FormBestTimes(FormMain parent) : this()
        {
            this.parent = parent;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void FormBestTimes_Shown(object sender, EventArgs e)
        {
            labelBegTime.Text = (DifficultyInfo.Beginner.HighScore / 1000.0).ToString("0.00") + "s";
            labelIntTime.Text = (DifficultyInfo.Intermediate.HighScore / 1000.0).ToString("0.00") + "s";
            labelExpTime.Text = (DifficultyInfo.Expert.HighScore / 1000.0).ToString("0.00") + "s";
            labelBegName.Text = DifficultyInfo.Beginner.HighScoreName;
            labelIntName.Text = DifficultyInfo.Intermediate.HighScoreName;
            labelExpName.Text = DifficultyInfo.Expert.HighScoreName;
        }

        private void buttonResetScore_Click(object sender, EventArgs e)
        {
            DifficultyInfo.Beginner.HighScore = 9999990;
            DifficultyInfo.Intermediate.HighScore = 9999990;
            DifficultyInfo.Expert.HighScore = 9999990;
            DifficultyInfo.Beginner.HighScoreName = "Anonymous";
            DifficultyInfo.Intermediate.HighScoreName = "Anonymous";
            DifficultyInfo.Expert.HighScoreName = "Anonymous";
            FormBestTimes_Shown(sender, e);
        }
    }
}
