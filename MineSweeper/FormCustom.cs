using MineSweeper.Lang;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class FormCustom : Form
    {
        private FormMain parent = null;

        public FormCustom()
        {
            InitializeComponent();
        }

        public FormCustom(FormMain parent) : this()
        {
            this.parent = parent;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            int.TryParse(textWidth.Text, out int width);
            int.TryParse(textHeight.Text, out int height);
            int.TryParse(textMines.Text, out int mines);
            if (width < 1) width = 1;
            else if (width > 50) width = 50;

            if (height < 1) height = 1;
            else if (height > 50) height = 50;

            if (mines < 0) mines = 0;
            else if (mines > width * height) mines = width * height;

            DifficultyInfo.Customized.Width = SettingProvider.Settings.Config.CustomizedConfig.Width = width;
            DifficultyInfo.Customized.Height = SettingProvider.Settings.Config.CustomizedConfig.Height = height;
            DifficultyInfo.Customized.Mines = SettingProvider.Settings.Config.CustomizedConfig.MineCount = mines;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormCustom_Shown(object sender, EventArgs e)
        {
            L10N.SetUIText(this, SettingProvider.Settings.Config.Lang);
            textWidth.Text = parent.MineWidth.ToString();
            textHeight.Text = parent.MineHeight.ToString();
            textMines.Text = parent.TotalMines.ToString();
            DifficultyInfo.Customized.Width = parent.MineWidth;
            DifficultyInfo.Customized.Height = parent.MineHeight;
            DifficultyInfo.Customized.Mines = parent.TotalMines;
        }

        private void textNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsControl(e.KeyChar) || char.IsNumber(e.KeyChar)))
                e.Handled = true;
        }
    }
}
