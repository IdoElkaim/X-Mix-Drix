using System;
using System.Windows.Forms;

namespace GameUserInterface
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private void cbPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            if(cbPlayer2.Checked == true)
            {
                tbPlayerName2.Enabled = true;
                tbPlayerName2.Text = string.Empty;
            }
            else
            {
                tbPlayerName2.Enabled = false;
                tbPlayerName2.Text = "[Computer]";
            }
        }

        private void nUDRows_ValueChanged(object sender, EventArgs e)
        {
            nUDCols.Value = nUDRows.Value;
        }

        private void nUDCols_ValueChanged(object sender, EventArgs e)
        {
            nUDRows.Value = nUDCols.Value;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormGame GameUI = new FormGame(
                int.Parse(nUDRows.Text), cbPlayer2.Checked, tbPlayerName1.Text, tbPlayerName2.Text);
            GameUI.ShowDialog();
            this.Close();
        }
    }
}
