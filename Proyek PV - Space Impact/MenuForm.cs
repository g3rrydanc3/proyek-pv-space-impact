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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        Image roket;
        Image judul;
        Image world;
        Image planet;
        Image ufo;
        Rectangle[] menu = new Rectangle[3];

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

        private void Form3_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile("background.jpg");
            roket = Image.FromFile("roket.png");
            judul = Image.FromFile("judul.png");
            world = Image.FromFile("world.gif");
            planet = Image.FromFile("planet.png");
            ufo = Image.FromFile("ufo.png");
        }

        private void Form3_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush b = new SolidBrush(Color.BlueViolet);
            g.DrawImage(roket, ((this.Width / 2) - 300), 50, 100, 100);
            g.DrawImage(judul, ((this.Width / 2) - 115), 50, 200, 100);
            g.DrawImage(world, ((this.Width / 2) - 300), 350, 100, 100);
            g.DrawImage(planet, ((this.Width / 2) + 170), 50, 100, 100);
            g.DrawImage(ufo, ((this.Width / 2) + 170), 350, 100, 100);

            for (int i = 0; i < menu.Length; i++)
            {
                menu[0] = new Rectangle(235, 170, 310, 45);
                menu[1] = new Rectangle(235, 230, 310, 45);
                menu[2] = new Rectangle(235, 290, 310, 45);
                g.FillRectangle(b, menu[i]);
            }

            Font f = new Font("Berlin Sans FB", 20, FontStyle.Bold);
            f = new Font("Berlin Sans FB", 16, FontStyle.Regular);
            b = new SolidBrush(Color.WhiteSmoke);
            g.DrawString("New Game", f, b, 343, 180);
            g.DrawString("High Score", f, b, 347, 240);
            g.DrawString("Exit", f, b, 376, 300);
        }

        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            Rectangle rect_cursor = new Rectangle(e.X, e.Y, 1, 1);

            if (rect_cursor.IntersectsWith(menu[0]))
            {
                ChoosePlaneForm f = new ChoosePlaneForm();
                f.ShowDialog();
            }
            else if (rect_cursor.IntersectsWith(menu[1]))
            {
                HighScoreForm f = new HighScoreForm();
                f.ShowDialog();
            }
            else if (rect_cursor.IntersectsWith(menu[2]))
            {
                System.Environment.Exit(1);
            }
        }

        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                System.Environment.Exit(1);
            }
        }
    }
}
