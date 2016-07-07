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
    public partial class ChoosePlaneForm : Form
    {
        public ChoosePlaneForm()
        {
            InitializeComponent();
        }

        Graphics g;
        Image pesawat1;
        Image pesawat2;
        Image pesawat3;
        Image judul;

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

        private void Form4_Load(object sender, EventArgs e)
        {
            pesawat1 = Image.FromFile("pesawat1.png");
            pesawat2 = Image.FromFile("pesawat2.png");
            pesawat3 = Image.FromFile("pesawat3.png");
            judul = Image.FromFile("judulform4.png");
            Label label1 = new Label();
            label1.Text = "Speed     : ";
            label1.Size = new Size(100, 20);
            label1.Location = new Point(35, 300);
            label1.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            label1.ForeColor = Color.DarkBlue;
            this.Controls.Add(label1);
            ProgressBar pgb1 = new ProgressBar();
            pgb1.Value = 75;
            pgb1.Size = new Size(120, 20);
            pgb1.Location = new Point(115, 300);
            this.Controls.Add(pgb1);
            Label label2 = new Label();
            label2.Text = "Accuracy : ";
            label2.Size = new Size(100, 20);
            label2.Location = new Point(35, 350);
            label2.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            label2.ForeColor = Color.DarkBlue;
            this.Controls.Add(label2);
            ProgressBar pgb2 = new ProgressBar();
            pgb2.Value = 27;
            pgb2.Size = new Size(120, 20);
            pgb2.Location = new Point(115, 350);
            this.Controls.Add(pgb2);
            Label label3 = new Label();
            label3.Text = "Damage  : ";
            label3.Size = new Size(100, 20);
            label3.Location = new Point(35, 400);
            label3.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            label3.ForeColor = Color.DarkBlue;
            this.Controls.Add(label3);
            ProgressBar pgb3 = new ProgressBar();
            pgb3.Value = 55;
            pgb3.Size = new Size(120, 20);
            pgb3.Location = new Point(115, 400);
            this.Controls.Add(pgb3);
            Label label4 = new Label();
            label4.Text = "Speed     : ";
            label4.Size = new Size(100, 20);
            label4.Location = new Point(295, 300);
            label4.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            label4.ForeColor = Color.DarkBlue;
            this.Controls.Add(label4);
            ProgressBar pgb4 = new ProgressBar();
            pgb4.Value = 26;
            pgb4.Size = new Size(120, 20);
            pgb4.Location = new Point(375, 300);
            this.Controls.Add(pgb4);
            Label label5 = new Label();
            label5.Text = "Accuracy : ";
            label5.Size = new Size(100, 20);
            label5.Location = new Point(295, 350);
            label5.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            label5.ForeColor = Color.DarkBlue;
            this.Controls.Add(label5);
            ProgressBar pgb5 = new ProgressBar();
            pgb5.Value = 57;
            pgb5.Size = new Size(120, 20);
            pgb5.Location = new Point(375, 350);
            this.Controls.Add(pgb5);
            Label label6 = new Label();
            label6.Text = "Damage  : ";
            label6.Size = new Size(100, 20);
            label6.Location = new Point(295, 400);
            label6.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            label6.ForeColor = Color.DarkBlue;
            this.Controls.Add(label6);
            ProgressBar pgb6 = new ProgressBar();
            pgb6.Value = 33;
            pgb6.Size = new Size(120, 20);
            pgb6.Location = new Point(375, 400);
            this.Controls.Add(pgb6); Label label7 = new Label();
            label7.Text = "Speed     : ";
            label7.Size = new Size(100, 20);
            label7.Location = new Point(555, 300);
            label7.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            label7.ForeColor = Color.DarkBlue;
            this.Controls.Add(label7);
            ProgressBar pgb7 = new ProgressBar();
            pgb7.Value = 26;
            pgb7.Size = new Size(120, 20);
            pgb7.Location = new Point(635, 300);
            this.Controls.Add(pgb7);
            Label label8 = new Label();
            label8.Text = "Accuracy : ";
            label8.Size = new Size(100, 20);
            label8.Location = new Point(555, 350);
            label8.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            label8.ForeColor = Color.DarkBlue;
            this.Controls.Add(label8);
            ProgressBar pgb8 = new ProgressBar();
            pgb8.Value = 20;
            pgb8.Size = new Size(120, 20);
            pgb8.Location = new Point(635, 350);
            this.Controls.Add(pgb8);
            Label label9 = new Label();
            label9.Text = "Damage  : ";
            label9.Size = new Size(100, 20);
            label9.Location = new Point(555, 400);
            label9.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            label9.ForeColor = Color.DarkBlue;
            this.Controls.Add(label9);
            ProgressBar pgb9 = new ProgressBar();
            pgb9.Value = 49;
            pgb9.Size = new Size(120, 20);
            pgb9.Location = new Point(635, 400);
            this.Controls.Add(pgb9);
        }

        private void Form4_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            Pen p = new Pen(Color.AntiqueWhite, 5);
            g.DrawImage(judul, (this.Width / 2) - 120, -15, 250, 140);
            g.DrawRectangle(p, 30, 100, 230, 400);
            g.DrawImage(pesawat1, 40, 120, 200, 150);
            g.DrawRectangle(p, 290, 100, 230, 400);
            g.DrawImage(pesawat2, 300, 120, 200, 150);
            g.DrawRectangle(p, 550, 100, 230, 400);
            g.DrawImage(pesawat3, 560, 120, 200, 150);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetVisibleCore(false);
            LoadingForm f = new LoadingForm();
            f.ShowDialog();
            if (f.finished == true)
            {
                BattleForm f1 = new BattleForm(0);
                f1.ShowDialog();
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetVisibleCore(false);
            LoadingForm f = new LoadingForm();
            f.ShowDialog();
            if (f.finished == true)
            {
                BattleForm f1 = new BattleForm(1);
                f1.ShowDialog();
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetVisibleCore(false);
            LoadingForm f = new LoadingForm();
            f.ShowDialog();
            if (f.finished == true)
            {
                BattleForm f1 = new BattleForm(2);
                f1.ShowDialog();
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
