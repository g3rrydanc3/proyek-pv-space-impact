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
    public partial class IntroForm : Form
    {
        int timer = 0;
        int splashed = 0;

        public IntroForm()
        {
            InitializeComponent();
        }

        protected override void SetVisibleCore(bool value)
        {
            if (!this.IsHandleCreated)
            {
                this.CreateHandle();
                value = true;
            }
            base.SetVisibleCore(value);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer++;
            if(timer > 1 && timer < 4)
            {
                if (splashed == 0)
                {
                    splashed = 1;
                }
                else
                {
                    this.Controls.Remove(pictureBox1);
                }
            }
            else if(timer > 4)
            {
                Cursor = Cursors.Hand;
                splashed = 2;
                timer1.Stop();
                label1.Visible = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (splashed == 2)
            {
                SetVisibleCore(false);
                MenuForm f = new MenuForm();
                f.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BattleForm f = new BattleForm(0);
            f.ShowDialog();
        }

        private void PencetMouse(object sender, MouseEventArgs e)
        {
            if (splashed == 2)
            {
                SetVisibleCore(false);
                MenuForm f = new MenuForm();
                f.ShowDialog();
            }
        }
    }
}
