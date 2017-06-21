using System;
using System.Windows.Forms;

namespace Mine
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
            labelText.Text = "You have the fastest time\n" +
                $"for {parent.CurrentDifficulty.Name} level.\n" +
                "Please enter your name.";
            textName.Text = Environment.UserName;
            textName.Select();
            textName.SelectAll();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            parent.CurrentDifficulty.HighScoreName = textName.Text;
            Hide();
        }
    }
}
