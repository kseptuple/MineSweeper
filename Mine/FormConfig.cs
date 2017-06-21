using System;
using System.Windows.Forms;

namespace Mine
{
    public partial class FormConfig : Form
    {
        private FormMain parent;

        public FormConfig()
        {
            InitializeComponent();
        }

        public FormConfig(FormMain parent) : this()
        {
            this.parent = parent;
        }

        private void FormConfig_Shown(object sender, EventArgs e)
        {
            switch (parent.FirstClick)
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
            if (parent.AllowFlag)
            {
                checkAllowFlag.Checked = true;
                checkAllowMark.Checked = parent.AllowMark;
            }
            else
            {
                checkAllowFlag.Checked = false;
                checkAllowMark.Enabled = false;
            }
            checkAllowCheat.Checked = parent.AllowCheat;
            check4DigitsTimeAndMines.Checked = parent.Show4DigitsNumber;
            checkAllowRestartPlayHighScore.Checked = parent.AllowRestartGameHighScore;
            checkTimeStartFromZero.Checked = parent.TimeStartFromZero;
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
                parent.FirstClick = MineFields.FirstClickType.NoProtection;
            else if (radioProtection.Checked)
                parent.FirstClick = MineFields.FirstClickType.Protection;
            else if (radioOpen.Checked)
                parent.FirstClick = MineFields.FirstClickType.Open;
            parent.AllowFlag = checkAllowFlag.Checked;
            parent.AllowMark = checkAllowMark.Checked;
            parent.AllowCheat = checkAllowCheat.Checked;
            parent.Show4DigitsNumber = check4DigitsTimeAndMines.Checked;
            parent.AllowRestartGameHighScore = checkAllowRestartPlayHighScore.Checked;
            parent.TimeStartFromZero = checkTimeStartFromZero.Checked;
            Hide();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
