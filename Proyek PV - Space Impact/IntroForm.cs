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

        private void Form1_Load(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting; 
            pictureBox1.BackgroundImage = Image.FromFile("background1.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            logo1 = Image.FromFile("logo1.png");
            roketluncur = Image.FromFile("roketluncur.png");
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
                    this.BackgroundImage = Image.FromFile("background2.jpg");
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
                label.Text = "Press any key to continue...";
                label.Size = new Size(500, 70);
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
                MenuForm f = new MenuForm();
                f.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BattleForm f = new BattleForm(0);
            f.ShowDialog();
        }
    }
}
