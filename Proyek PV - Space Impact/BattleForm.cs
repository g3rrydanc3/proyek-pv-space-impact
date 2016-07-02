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
    public partial class BattleForm : Form
    {
        public BattleForm()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        
        Random rand = new Random();

        int x;
        int y;
        Image imgPlayer;
        Image imgBullet;
        Image imgMusuh1;
        Image imgMusuh2;
        List<int> bulletArrX = new List<int>();
        List<int> bulletArrY = new List<int>();
        List<bool> bulletArr = new List<bool>();

        List<int> wallX = new List<int>();
        List<int> wallHeight = new List<int>();

        int[] xMusuh;
        int[] yMusuh;
        int[] jenis;
        int waktu = 0;

        private void Form6_Load(object sender, EventArgs e)
        {
            imgPlayer = Image.FromFile("pesawat1.png");
            imgBullet = Image.FromFile("peluru.png");
            imgMusuh1 = Image.FromFile("musuh1.png");
            imgMusuh2 = Image.FromFile("musuh2.png");
            this.BackgroundImage = Image.FromFile("backgroundgame.jpg");

            x = 0;
            y = this.Height / 2 - 50;
            xMusuh = new int[5];
            yMusuh = new int[5];
            jenis = new int[5];
            for (int i = 0; i < 5; i++)
            {
                jenis[i] = rand.Next(0, 2);
                xMusuh[i] = rand.Next(800, 850);
                yMusuh[i] = rand.Next(40, 425);
            }

            for (int i = 0; i < 30; i++)
            {
                wallX.Add(i*60);
                wallHeight.Add(rand.Next(10,300));
            }

        }

        private void Form6_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush b = new SolidBrush(Color.Green);

            for (int i = 0; i < wallHeight.Count(); i++)
            {
                g.FillRectangle(b, wallX[i], 540 - wallHeight[i], 50, wallHeight[i]);
            }

            g.DrawImage(imgPlayer, x, y, 80, 80);

            for (int i = 0; i < bulletArrX.Count(); i++)
            {
                if (bulletArr[i] == true)
                {
                    g.DrawImage(imgBullet, bulletArrX[i], bulletArrY[i], 20, 20);
                }
            }

            for (int i = 0; i < 5; i++)
            {
                if (jenis[i] == 0)
                {
                    g.DrawImage(imgMusuh1, xMusuh[i], yMusuh[i], 40, 40);
                }
                else if (jenis[i] == 1)
                {
                    g.DrawImage(imgMusuh1, xMusuh[i], yMusuh[i], 40, 40);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < bulletArrX.Count(); i++)
            {
                if (bulletArr[i] == true)
                {
                    bulletArrX[i] += 40;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                //xMusuh[i] -= 10;
                if (xMusuh[i] == 0)
                {
                    yMusuh[i] = rand.Next(40, 440);
                    xMusuh[i] = rand.Next(700, 900);
                }
                else
                {
                    xMusuh[i] -= 10;
                }

                for (int j = 0; j < bulletArrX.Count(); j++)
                {
                    if (bulletArrX[j] >= xMusuh[i] && bulletArrX[j] < xMusuh[i] + 40 && bulletArrY[j] >= yMusuh[i] && bulletArrY[j] < yMusuh[i] + 40)
                    {
                        int nilai = 0;
                        if (jenis[i] == 0)
                        {
                            nilai = 10;
                        }
                        else if (jenis[i] == 1)
                        {
                            nilai = 5;
                        }
                        yMusuh[i] = rand.Next(40, 440);
                        xMusuh[i] = rand.Next(700, 900);
                        bulletArrX[j] = -1000;
                        bulletArrY[j] = -1000;
                        bulletArr[j] = false;
                        label2.Text = (Int32.Parse(label2.Text) + nilai).ToString();
                    }
                }
            }

            for (int i = 0; i < wallHeight.Count(); i++)
            {
                wallX[i] -= 10;
                if (wallX[i] >= x && wallX[i] < x - 80 && wallHeight[i] >= y && wallHeight[i] < y - 80)
                {
                    MessageBox.Show("test");
                    int lives = Convert.ToInt32(label7.Text);
                    lives -= 1;
                    label7.Text = lives.ToString();
                    x = 0;
                    y = this.Height / 2 - 50;
                }
            }
            this.Invalidate();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int hitungWaktu = int.Parse(label3.Text);
            hitungWaktu += 1;
            label3.Text = hitungWaktu.ToString();
            waktu++;
            if (label5.Text == "1")
            {
                if (waktu == 30)
                {
                    label3.Text = "0";
                    label5.Text = "2";
                    t1Gerak.Enabled = false;
                    t2Waktu.Enabled = false;
                    MessageBox.Show("Next Level");
                    t1Gerak.Enabled = true;
                    t2Waktu.Enabled = true;
                }
            }
            if (label5.Text == "2")
            {

                if (waktu == 50)
                {
                    label3.Text = "0";
                    label5.Text = "3";
                }
            }
            //this.Invalidate();
        }

        private void BattleForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (y > 30)
                {
                    y -= 10;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (y < 470)
                {
                    y += 10;
                }
            }
            if (e.KeyCode == Keys.Left)
            {
                if (x > 30)
                {
                    x -= 10;
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                if (x < 740)
                {
                    x += 10;
                }
            }
            if (e.KeyCode == Keys.Space)
            {
                bulletArrX.Add(x + 80);
                bulletArrY.Add(y + 30);
                bulletArr.Add(true);
            }
            //this.Invalidate();
        }
    }
}
