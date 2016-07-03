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
        }

        Random rand = new Random();
        int waktu, level, life;

        int x;
        int y;
        Image imgPlayer;
        Image imgBullet;
        Image imgMusuh1;
        Image imgMusuh2;
        Image imgGround;
        List<int> bulletArrX = new List<int>();
        List<int> bulletArrY = new List<int>();
        List<bool> bulletArr = new List<bool>();

        List<int> wallTopX = new List<int>();
        List<int> wallTopHeight = new List<int>();

        List<int> wallBotX = new List<int>();
        List<int> wallBotHeight = new List<int>();

        List<int> xMusuh = new List<int>();
        List<int> yMusuh = new List<int>();
        List<int> jenis = new List<int>();
        private void Form6_Load(object sender, EventArgs e)
        {            
            imgPlayer = Image.FromFile("pesawat1.png");
            imgBullet = Image.FromFile("peluru.png");
            imgMusuh1 = Image.FromFile("musuh1.png");
            imgMusuh2 = Image.FromFile("musuh2.png");
            imgGround = Image.FromFile("groundSprite.png");
            this.BackgroundImage = Image.FromFile("backgroundgame.jpg");

            waktu = 15;
            level = 1;
            life = 3;
            label3.Text = waktu.ToString();
            x = 30;
            y = this.Height / 2 - 50;
            ///////////////////init random
            newRandom();
        }

        private void Form6_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            TextureBrush bt = new TextureBrush(imgGround);

            ///////////////////gambar wall
            for (int i = 0; i < wallBotHeight.Count(); i++)
            {
                g.FillRectangle(bt, wallBotX[i], 540 - wallBotHeight[i], 50, wallBotHeight[i]);
            }

            for (int i = 0; i < wallTopHeight.Count(); i++)
            {
                g.FillRectangle(bt, wallTopX[i], 50, 50, wallTopHeight[i]);
            }

            ///////////////////gambar player
            g.DrawImage(imgPlayer, x, y, 80, 80);

            ///////////////////gambar bullet
            for (int i = 0; i < bulletArrX.Count(); i++)
            {
                if (bulletArr[i] == true)
                {
                    g.DrawImage(imgBullet, bulletArrX[i], bulletArrY[i], 20, 20);
                }
            }

            ///////////////////gambar musuh
            for (int i = 0; i < xMusuh.Count(); i++)
            {
                if (jenis[i] == 0)
                {
                    g.DrawImage(imgMusuh1, xMusuh[i], yMusuh[i], 40, 40);
                }
                else if (jenis[i] == 1)
                {
                    g.DrawImage(imgMusuh2, xMusuh[i], yMusuh[i], 40, 40);
                }
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ///////////////////gerak bullet
            for (int i = 0; i < bulletArrX.Count(); i++)
            {
                if (bulletArr[i] == true)
                {
                    bulletArrX[i] += 40;
                }
            }
            ///////////////////loop musuh
            for (int i = 0; i < xMusuh.Count(); i++)
            {
                if (xMusuh[i] <= 0)
                {
                    yMusuh[i] = rand.Next(40, 440);
                    xMusuh[i] = rand.Next(700, 900);
                }
                else
                {
                    xMusuh[i] -= 20;
                }

                ////////////////////check nabrak musuh & player
                if (xMusuh[i] >= x && xMusuh[i] < x + 80 && yMusuh[i] >= y && yMusuh[i] < y + 80)
                {
                    life--;
                    refreshLife();
                    x = 0;
                    y = this.Height / 2 - 50;
                }

                ///////////////////loop bullet
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
            //loop wall
            for (int i = 0; i < wallBotHeight.Count(); i++)
            {
                wallBotX[i] -= 20;
                if (wallBotX[i] >= x && wallBotX[i] < x + 80 && 540 - wallBotHeight[i] >= y && 540 - wallBotHeight[i] < y + 80)
                {
                    //MessageBox.Show("test");
                    life--;
                    refreshLife();
                    x = 0;
                    y = this.Height / 2 - 50;
                }
            }
            for (int i = 0; i < wallTopHeight.Count(); i++)
            {
                wallTopX[i] -= 20;
                if (wallTopX[i] >= x && wallTopX[i] < x + 80 && 50 >= y && 50 < y + 80)
                {
                    //MessageBox.Show("test");
                    life--;
                    refreshLife();
                    x = 0;
                    y = this.Height / 2 - 50;
                }
            }
            //this.Invalidate();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            waktu--;
            label3.Text = waktu.ToString();
            if (level == 1)
            {
                if (waktu <= 0)
                {
                    nextLevel();
                }
            }
            else if (level == 2)
            {
                if (waktu <= 0)
                {
                    nextLevel();
                }
            }
        }

        private void BattleForm_KeyDown(object sender, KeyEventArgs e)
        {
            ///////////////////gerak
            if (e.KeyCode == Keys.Up)
            {
                if (y > 50)
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

        private void nextLevel()
        {
            level++;
            t1Gerak.Enabled = false;
            t2Waktu.Enabled = false;
            MessageBox.Show("Congratulation, You finished level " + (level - 1), "Next Level");
            t1Gerak.Enabled = true;
            t2Waktu.Enabled = true;
            waktu = level * 40;
            label5.Text = level.ToString();
            label3.Text = waktu.ToString();
            bulletArr.Clear();
            bulletArrX.Clear();
            bulletArrY.Clear();
            xMusuh.Clear();
            yMusuh.Clear();
            jenis.Clear();
            wallBotHeight.Clear();
            wallBotX.Clear();
            wallTopHeight.Clear();
            wallTopX.Clear();
            newRandom();
        }

        private void newRandom()
        {
            ///////////////////random wall
            for (int i = 0; i < 30; i++)
            {
                wallBotX.Add(rand.Next(i * 400, i * 500));
                wallBotHeight.Add(rand.Next(0, 4) * 50);
                wallTopX.Add(rand.Next(i * 300, i * 400));
                wallTopHeight.Add(rand.Next(0, 4) * 50);
            }
            ///////////////////random musuh
            for (int i = 0; i < 5; i++)
            {
                jenis.Add(rand.Next(0, 2));
                xMusuh.Add(rand.Next(600, 1200));
                yMusuh.Add(rand.Next(50, 425));
            }
        }

        private void refreshLife()
        {
            if (life == 3)
            {
                life1.Visible = true;
                life2.Visible = true;
                life3.Visible = true;
            }
            else if (life == 2)
            {
                life1.Visible = true;
                life2.Visible = true;
                life3.Visible = false;
            }
            else if (life == 1)
            {
                life1.Visible = true;
                life2.Visible = false;
                life3.Visible = false;
            }
            else
            {
                life1.Visible = false;
                life2.Visible = false;
                life3.Visible = false;
            }
        }

        private void t3Refresh_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}