using MineSweeper.Lang;
using System;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class FormNewRecord : Form
    {
        private FormMain parent = null;
        public FormNewRecord()
        {
            InitializeComponent();
        }

        public FormNewRecord(FormMain parent) : this()
        {
            this.parent = parent;
        }

        private void FormNewRecord_Shown(object sender, EventArgs e)
        {
            L10N.SetUIText(this, SettingProvider.Settings.Config.Lang);
            labelText.Text = string.Format(L10N.GetText("NewRecord"), parent.CurrentDifficulty.Name.ToLower());
            textName.Text = Environment.UserName;
            textName.Select();
            textName.SelectAll();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SettingProvider.DifficultyLookup[parent.CurrentDifficulty.Id].Name = textName.Text;
            Close();
        }
    }
}
