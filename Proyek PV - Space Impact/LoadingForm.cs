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
        public LoadingForm()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar2.Value < 100)
            {
                progressBar2.Value += 25;
            }
            if (progressBar2.Value == 25)
            {
                label1.Text = "Check Information...";
                label1.Location = new Point((this.Width / 2) - 132, 425);
            }
            else if (progressBar2.Value == 50)
            {
                label1.Text = "Loading Information...";
                label1.Location = new Point((this.Width / 2) - 138, 425);
            }
            else if (progressBar2.Value == 75)
            {
                label1.Text = "Get Information...";
                label1.Location = new Point((this.Width / 2) - 120, 425);
            }
            else if (progressBar2.Value == 100)
            {
                label1.Text = "File Open. Please Wait...";
                label1.Location = new Point((this.Width / 2) - 155, 425);
                timer1.Stop();
                timer2.Start();
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            progressBar1.Visible = false;
            progressBar2.Visible = false;
            label1.Text = "Opening File...";
            label1.Location = new Point((this.Width / 2) - 100, 425);
            timer1.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 10;
            }
            if (progressBar1.Value == 100)
            {
                timer2.Stop();
                this.Close();
            }
        }
    }
}
