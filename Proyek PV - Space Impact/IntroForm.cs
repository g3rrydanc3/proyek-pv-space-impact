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
        Graphics g;
        Image logo1;
        Image roketluncur;

        public IntroForm()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message message)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            switch (message.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = message.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }

            base.WndProc(ref message);
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
            pictureBox1.BackgroundImage = Image.FromFile(Application.StartupPath + "/asset/background1.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            logo1 = Image.FromFile(Application.StartupPath + "/asset/logo1.png");
            roketluncur = Image.FromFile(Application.StartupPath + "/asset/roketluncur.png");
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
                    this.BackgroundImage = Image.FromFile(Application.StartupPath + "/asset/background2.jpg");
                    this.Invalidate();
                }
            }
            else if(timer > 4)
            {
                Cursor = Cursors.Default;
                this.Invalidate();
                splashed = 2;
                timer1.Stop();
                Label label = new Label();
                label.Text = "Press any key or click to continue...";
                label.Size = new Size(826, 70);
                label.Font = new Font("Century gothic", 18, FontStyle.Bold);
                label.Location = new Point(0, 500);
                label.ForeColor = Color.White;
                label.BackColor = Color.Transparent;
                this.Controls.Add(label);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawImage(logo1, 300, 210, 200, 100);
            g.DrawImage(roketluncur, 450, 200, 100, 200);
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
