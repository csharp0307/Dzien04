using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstWinApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //String s = String.Format("Wprowadziłeś: {0}", tbFirstName.Text);
            //MessageBox.Show(s);
            mnuFile.Enabled = !mnuFile.Enabled;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = ofdFile.ShowDialog();
            if (result==DialogResult.OK)
            {
                MessageBox.Show(ofdFile.FileName);
            }
        }

        FormExternal form = null;
        private void button6_Click(object sender, EventArgs e)
        {
            if (form != null)
            {
                form.Focus();
                return;
            }
            form = new FormExternal();
            form.Show();
            //form.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (form != null)
            {
                form.Close();
                //form.Dispose();
                form = null;
            }
        }
    }
}
