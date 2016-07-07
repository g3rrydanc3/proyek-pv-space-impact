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
    public partial class LoadingForm : Form
    {
        public bool finished = false;
        int loading = 0;
        public LoadingForm()
        {
            InitializeComponent();
            Cursor = Cursors.WaitCursor; 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            loading += 1;
            label1.Text = loading.ToString();
            if (loading <= 25)
            {
                label1.Text = label1.Text + "% Check Information...";
                label1.TextAlign = ContentAlignment.TopCenter;
                label1.Location = new Point((this.Width / 2) - 132, 425);
            }
            else if (loading > 25 && loading <= 50)
            {
                label1.Text = label1.Text + "% Loading Information...";
                label1.Location = new Point((this.Width / 2) - 138, 425);
            }
            else if (loading > 50 && loading <= 75)
            {
                label1.Text = label1.Text + "% Get Information...";
                label1.Location = new Point((this.Width / 2) - 120, 425);
            }
            else if (loading >= 75 && loading <= 100)
            {
                label1.Text = label1.Text + "% File Open. Please Wait...";
                label1.Location = new Point((this.Width / 2) - 155, 425);
            }
            else
            {
                finished = true;
                this.Close();
            }
        }
    }
}
