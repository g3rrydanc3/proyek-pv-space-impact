using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Proyek_PV___Space_Impact
{
    public partial class BattleForm : Form
    {
        public BattleForm(int pesawatTemp)
        {
            InitializeComponent();
            pesawat = pesawatTemp;
        }

        Random rand = new Random();
        int waktu, level, life, blink, score;
        List<int> waktuLevel = new List<int>();

        int x;
        int y;
        int pesawat;
        List<Image> imgPesawat = new List<Image>();
        List<Image> imgPesawatTransparent = new List<Image>();
        Image imgMusuh1;
        Image imgMusuh2;
        Image imgMusuh3;
        Image imgBoss;

        Image imgBullet;
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
        List<int> jenisMusuh = new List<int>();
        List<int> nyawaMusuh = new List<int>();

        SoundPlayer boss_die = new SoundPlayer(Application.StartupPath + "/sfx/boss_die.wav");
        SoundPlayer enemy_die = new SoundPlayer(Application.StartupPath + "/sfx/enemy_die.wav");
        SoundPlayer low_life = new SoundPlayer(Application.StartupPath + "/sfx/low_life.wav");
        SoundPlayer player_die = new SoundPlayer(Application.StartupPath + "/sfx/player_die.wav");
        SoundPlayer shot = new SoundPlayer(Application.StartupPath + "/sfx/shot.wav");

        private void playerDie()
        {
            life--;
            refreshLife();
            x = 30;
            y = this.Height / 2 - 50;
            blink = 10;
        }

        private void nextLevel()
        {
            level++;
            t1Gerak.Enabled = false;
            t2Waktu.Enabled = false;
            MessageBox.Show("Congratulation, You finished level " + (level - 1), "Next Level");
            x = 30;
            y = this.Height / 2 - 50;
            t1Gerak.Enabled = true;
            t2Waktu.Enabled = true;
            if (level == 2)
            {
                waktu = waktuLevel[level-1];
                label5.Text = level.ToString();
                label3.Text = waktu.ToString();
                bulletArr.Clear();
                bulletArrX.Clear();
                bulletArrY.Clear();
                xMusuh.Clear();
                yMusuh.Clear();
                nyawaMusuh.Clear();
                jenisMusuh.Clear();
                wallBotHeight.Clear();
                wallBotX.Clear();
                wallTopHeight.Clear();
                wallTopX.Clear();
                newRandom();
            }
            else if (level == 3)
            {
                waktu = waktuLevel[level-1];
                label5.Text = level.ToString();
                label3.Text = waktu.ToString();
                bulletArr.Clear();
                bulletArrX.Clear();
                bulletArrY.Clear();
                xMusuh.Clear();
                yMusuh.Clear();
                nyawaMusuh.Clear();
                jenisMusuh.Clear();
                wallBotHeight.Clear();
                wallBotX.Clear();
                wallTopHeight.Clear();
                wallTopX.Clear();
                newRandom();
            }

        }

        private void newRandom()
        {
            ///////////////////random wall
            if (level != 3)
            {
                for (int i = 0; i < 30; i++)
                {
                    wallBotX.Add(rand.Next(i * 400, i * 500));
                    wallBotHeight.Add(rand.Next(0, 4) * 50);
                    wallTopX.Add(rand.Next(i * 300, i * 400));
                    wallTopHeight.Add(rand.Next(0, 4) * 50);
                }
            }
            ///////////////////random musuh
            if (level == 1)
            {
                for (int i = 0; i < 5; i++)
                {
                    jenisMusuh.Add(rand.Next(0, 2));
                    xMusuh.Add(rand.Next(600, 1200));
                    yMusuh.Add(rand.Next(50, 425));
                    nyawaMusuh.Add(1);
                }
            }
            else if (level == 2)
            {
                for (int i = 0; i < 5; i++)
                {
                    jenisMusuh.Add(rand.Next(0, 3));
                    xMusuh.Add(rand.Next(600, 1200));
                    yMusuh.Add(rand.Next(50, 425));
                    if (jenisMusuh[i] == 2)
                    {
                        nyawaMusuh.Add(2);
                    }
                    else
                    {
                        nyawaMusuh.Add(1);
                    }
                }
            }
            else if (level == 3)
            {
                jenisMusuh.Add(3);
                xMusuh.Add(rand.Next(600, 1200));
                yMusuh.Add(rand.Next(50, 341));
                nyawaMusuh.Add(10);
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
                player_die.Play();
            }
            else if (life == 1)
            {
                low_life.PlayLooping();
                life1.Visible = true;
                life2.Visible = false;
                life3.Visible = false;
                player_die.Play();
            }
            else
            {
                life1.Visible = false;
                life2.Visible = false;
                life3.Visible = false;
                t1Gerak.Enabled = false;
                t2Waktu.Enabled = false;
                t3Refresh.Enabled = false;
                player_die.Play();

                ///////////////////highscore
                GameOverForm f = new GameOverForm(score);
                if (f.ShowDialog() == DialogResult.No)
                {
                    MessageBox.Show("Game Over");
                }
                this.Close();
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            ///////////////////load image
            for (int i = 1; i <= 3; i++)
            {
                imgPesawat.Add(Image.FromFile(Application.StartupPath + "/asset/battle/pesawat" + i + ".png"));
                imgPesawatTransparent.Add(Image.FromFile(Application.StartupPath + "/asset/battle/pesawat" + i + "Transparent.png"));
            }
            imgBullet = Image.FromFile(Application.StartupPath + "/asset/battle/peluru.png");
            imgMusuh1 = Image.FromFile(Application.StartupPath + "/asset/battle/musuh1.png");
            imgMusuh2 = Image.FromFile(Application.StartupPath + "/asset/battle/musuh2.png");
            imgMusuh3 = Image.FromFile(Application.StartupPath + "/asset/battle/musuh3.png");
            imgBoss = Image.FromFile(Application.StartupPath + "/asset/battle/boss.png");
            imgGround = Image.FromFile(Application.StartupPath + "/asset/battle/groundSprite.png");

            ///////////////////waktu level setting
            waktuLevel.Add(20);
            waktuLevel.Add(25);
            waktuLevel.Add(30);

            ///////////////////initital
            level = 1;
            life = 3;
            blink = 10;
            waktu = waktuLevel[level-1];
            label3.Text = waktu.ToString();
            newRandom();

            ///////////////////start position
            x = 30;
            y = this.Height / 2 - 50;
        }

        private void Form6_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
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
            if (blink >=1)
	        {
		        if (blink % 2 == 0)
                {
                    g.DrawImage(imgPesawatTransparent[pesawat], x, y, 80, 80);
                }
	        }
            else
	        {
                g.DrawImage(imgPesawat[pesawat], x, y, 80, 80);
	        }
            
            
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
                if (jenisMusuh[i] == 0)
                {
                    g.DrawImage(imgMusuh1, xMusuh[i], yMusuh[i], 40, 40);
                }
                else if (jenisMusuh[i] == 1)
                {
                    g.DrawImage(imgMusuh2, xMusuh[i], yMusuh[i], 40, 40);
                }
                else if(jenisMusuh[i] == 2)
                {
                    g.DrawImage(imgMusuh3, xMusuh[i], yMusuh[i], 40, 40);
                }
                else if (jenisMusuh[i] == 3)
                {
                    g.DrawImage(imgBoss, xMusuh[i], yMusuh[i], 200, 246);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ///////////////////loop musuh
            for (int i = 0; i < xMusuh.Count(); i++)
            {
                if (xMusuh[i] <= 0)
                {
                    yMusuh[i] = rand.Next(50, 440);
                    xMusuh[i] = rand.Next(700, 900);
                }
                else
                {
                    xMusuh[i] -= 10;
                }
                
                ///////////////////loop bullet
                for (int j = 0; j < bulletArrX.Count(); j++)
                {
                    ///////////////////check musuh ketembak
                    if (level == 3)
                    {
                        if (bulletArrX[j] >= xMusuh[i] && bulletArrX[j] < xMusuh[i] + 200 && bulletArrY[j] >= yMusuh[i] && bulletArrY[j] < yMusuh[i] + 246)
                        {
                            bulletArrX[j] = -1000;
                            bulletArrY[j] = -1000;
                            bulletArr[j] = false;
                            nyawaMusuh[i]--;
                            if (nyawaMusuh[i] == 0)
                            {
                                score += 100;
                                boss_die.Play();
                                life = 0;
                                refreshLife();
                            }
                        }
                    }
                    else if (bulletArrX[j] >= xMusuh[i] && bulletArrX[j] < xMusuh[i] + 40 && bulletArrY[j] >= yMusuh[i] && bulletArrY[j] < yMusuh[i] + 40)
                    {
                        bulletArrX[j] = -1000;
                        bulletArrY[j] = -1000;
                        bulletArr[j] = false;
                        nyawaMusuh[i]--;
                        if (nyawaMusuh[i] == 0)
                        {
                            enemy_die.Play();
                            yMusuh[i] = rand.Next(50, 440);
                            xMusuh[i] = rand.Next(700, 900);
                            if (jenisMusuh[i] == 0)
                            {
                                score += 5;
                                nyawaMusuh[i] = 1;
                            }
                            else if (jenisMusuh[i] == 1)
                            {
                                score += 10;
                                nyawaMusuh[i] = 1;
                            }
                            else if (jenisMusuh[i] == 2)
                            {
                                score += 15;
                                nyawaMusuh[i] = 2;
                            }
                            else if (jenisMusuh[i] == 3)
                            {
                                score += 25;
                            }
                        }
                        label2.Text = score.ToString();
                    }
                }
            }

            ///////////////////gerak wall
            for (int i = 0; i < wallTopHeight.Count(); i++)
            {
                wallTopX[i] -= 10;
            }
            for (int i = 0; i < wallBotHeight.Count(); i++)
            {
                wallBotX[i] -= 10;
            }
            
            ///////////////////gerak bullet
            for (int i = 0; i < bulletArrX.Count(); i++)
            {
                if (bulletArr[i] == true)
                {
                    bulletArrX[i] += 20;
                }
            }

            if (blink >= 1)
            {
                blink--;
            }
            else
            {
                for (int i = 0; i < xMusuh.Count(); i++)
                {
                    ////////////////////check nabrak musuh & player
                    if (xMusuh[i] >= x && xMusuh[i] < x + 80 && yMusuh[i] >= y && yMusuh[i] < y + 80)
                    {
                        playerDie();
                    }
                }
                ////////////////////loop wall bot
                for (int i = 0; i < wallBotHeight.Count(); i++)
                {
                    if (wallBotX[i] >= x && wallBotX[i] < x + 80 && 540 - wallBotHeight[i] >= y && 540 - wallBotHeight[i] < y + 80)
                    {
                        playerDie();
                    }
                }
                ////////////////////loop wall top
                for (int i = 0; i < wallTopHeight.Count(); i++)
                {
                    if (wallTopX[i] >= x && wallTopX[i] < x + 80 && 50 + wallTopHeight[i] >= y && 50 + wallTopHeight[i] < y + 80)
                    {
                        playerDie();
                    }
                }
            }
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
            else if (level == 3)
            {
                if (waktu <= 0)
                {
                    life = 0;
                    refreshLife();
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
                shot.Play();
            }
        }

        private void t3Refresh_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void BattleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            t1Gerak.Enabled = false;
            t2Waktu.Enabled = false;
            t3Refresh.Enabled = false;
            bulletArrX.Clear();
            bulletArrY.Clear();
            bulletArr.Clear();
            wallTopX.Clear();
            wallTopHeight.Clear();
            wallBotX.Clear();
            wallBotHeight.Clear();
            xMusuh.Clear();
            yMusuh.Clear();
            nyawaMusuh.Clear();
            jenisMusuh.Clear();
            boss_die.Dispose();
            enemy_die.Dispose();
            low_life.Dispose();
            player_die.Dispose();
            shot.Dispose();
            boss_die.Stop();
            enemy_die.Stop();
            low_life.Stop();
            player_die.Stop();
            shot.Stop();
            this.Invalidate();
        }

        private void BattleForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X - 40 > 30 && e.X - 40 < 740)
            {
                x = e.X - 40;
            }
            if (e.Y - 40 > 50 && e.Y - 40 < 470)
            {
                y = e.Y - 40;
            }
        }

        private void BattleForm_MouseDown(object sender, MouseEventArgs e)
        {
            bulletArrX.Add(x + 80);
            bulletArrY.Add(y + 30);
            bulletArr.Add(true);
            shot.Play();
        }
    }
}