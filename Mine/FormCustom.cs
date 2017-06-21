using System;
using System.Windows.Forms;

namespace Mine
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

            DifficultyInfo.Customized.Width = width;
            DifficultyInfo.Customized.Height = height;
            DifficultyInfo.Customized.Mines = mines;
            Hide();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void FormCustom_Shown(object sender, EventArgs e)
        {
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
