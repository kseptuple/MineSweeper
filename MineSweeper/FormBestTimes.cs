using MineSweeper.Lang;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class FormBestTimes : Form
    {
        public FormBestTimes()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormBestTimes_Shown(object sender, EventArgs e)
        {
            L10N.SetUIText(this, SettingProvider.Settings.Config.Lang);
            var second = L10N.GetText("Second");
            labelBegTime.Text = (SettingProvider.Settings.HighScores.Beginner.Score / 1000.0).ToString("0.00") + second;
            labelIntTime.Text = (SettingProvider.Settings.HighScores.Intermediate.Score / 1000.0).ToString("0.00") + second;
            labelExpTime.Text = (SettingProvider.Settings.HighScores.Expert.Score / 1000.0).ToString("0.00") + second;
            labelBegName.Text = SettingProvider.Settings.HighScores.Beginner.Name;
            labelIntName.Text = SettingProvider.Settings.HighScores.Intermediate.Name;
            labelExpName.Text = SettingProvider.Settings.HighScores.Expert.Name;
        }

        private void buttonResetScore_Click(object sender, EventArgs e)
        {
            SettingProvider.Settings.HighScores.Beginner.Score = 9999990;
            SettingProvider.Settings.HighScores.Intermediate.Score = 9999990;
            SettingProvider.Settings.HighScores.Expert.Score = 9999990;
            var anonymousText = L10N.GetText("Anonymous");
            SettingProvider.Settings.HighScores.Beginner.Name = anonymousText;
            SettingProvider.Settings.HighScores.Intermediate.Name = anonymousText;
            SettingProvider.Settings.HighScores.Expert.Name = anonymousText;
            FormBestTimes_Shown(sender, e);
        }
    }
}
