using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyek_PV___Space_Impact
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void _MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }
    }
}
