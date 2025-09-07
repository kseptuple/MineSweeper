using MineSweeper.Core;
using MineSweeper.Lang;
using System;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class FormConfig : Form
    {
        public FormConfig()
        {
            InitializeComponent();
        }

        private void FormConfig_Shown(object sender, EventArgs e)
        {
            L10N.SetUIText(this, SettingProvider.Settings.Config.Lang);
            switch (SettingProvider.Settings.Config.GameConfig.FirstClickType)
            {
                case MineFields.FirstClickType.NoProtection:
                    radioNoProtection.Checked = true;
                    break;
                case MineFields.FirstClickType.Protection:
                    radioProtection.Checked = true;
                    break;
                case MineFields.FirstClickType.Open:
                    radioOpen.Checked = true;
                    break;
                default:
                    break;
            }
            if (SettingProvider.Settings.Config.GameConfig.AllowFlag)
            {
                checkAllowFlag.Checked = true;
                checkAllowMark.Checked = SettingProvider.Settings.Config.GameConfig.AllowMark;
            }
            else
            {
                checkAllowFlag.Checked = false;
                checkAllowMark.Enabled = false;
            }
            checkShowMine.Checked = SettingProvider.Settings.Config.Cheat.ShowMines;
            check4DigitsTimeAndMines.Checked = SettingProvider.Settings.Config.GameConfig.Show4DigitsNumber;
            checkAllowRestartPlayHighScore.Checked = SettingProvider.Settings.Config.GameConfig.AllowHighScoreInRestartGame;
            checkTimeStartFromZero.Checked = SettingProvider.Settings.Config.GameConfig.TimeStartFromZero;
        }

        private void checkAllowFlag_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkAllowFlag.Checked)
            {
                checkAllowMark.Checked = false;
                checkAllowMark.Enabled = false;
            }
            else
            {
                checkAllowMark.Enabled = true;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (radioNoProtection.Checked)
                SettingProvider.Settings.Config.GameConfig.FirstClickType = MineFields.FirstClickType.NoProtection;
            else if (radioProtection.Checked)
                SettingProvider.Settings.Config.GameConfig.FirstClickType = MineFields.FirstClickType.Protection;
            else if (radioOpen.Checked)
                SettingProvider.Settings.Config.GameConfig.FirstClickType = MineFields.FirstClickType.Open;

            SettingProvider.Settings.Config.GameConfig.AllowFlag = checkAllowFlag.Checked;
            SettingProvider.Settings.Config.GameConfig.AllowMark = checkAllowMark.Checked;
            SettingProvider.Settings.Config.Cheat.ShowMines = checkShowMine.Checked;
            SettingProvider.Settings.Config.GameConfig.Show4DigitsNumber = check4DigitsTimeAndMines.Checked;
            SettingProvider.Settings.Config.GameConfig.AllowHighScoreInRestartGame = checkAllowRestartPlayHighScore.Checked;
            SettingProvider.Settings.Config.GameConfig.TimeStartFromZero = checkTimeStartFromZero.Checked;

            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
