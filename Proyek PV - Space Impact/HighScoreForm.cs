using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Proyek_PV___Space_Impact
{
    public partial class HighScoreForm : Form
    {
        public HighScoreForm()
        {
            InitializeComponent();
        }

        class CHighScore
        {
            public string name { get; set; }
            public int score { get; set; }
        }
        List<CHighScore> highScore = new List<CHighScore>();

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

        private void HighScoreForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "/highScore.xml"))
            {
                XmlTextReader reader = new XmlTextReader(Application.StartupPath + "/highScore.xml");
                reader.ReadStartElement();
                while (reader.IsStartElement("highScore"))
                {
                    reader.ReadStartElement();
                    CHighScore data = new CHighScore();
                    data.name = reader.ReadElementString("name");
                    data.score = Convert.ToInt32(reader.ReadElementString("score"));
                    highScore.Add(data);
                    reader.ReadEndElement();
                }
                reader.ReadEndElement();
                reader.Close();
                var orderedResult = highScore.OrderByDescending(f => f.score).ToList();

                Label[] lName = new Label[highScore.Count()];
                Label[] lScore = new Label[highScore.Count()];
                for (int i = 0; i < highScore.Count(); i++)
                {
                    lName[i] = new Label();
                    lName[i].Text = orderedResult[i].name;
                    lName[i].ForeColor = Color.White;
                    lName[i].TextAlign = ContentAlignment.TopCenter;
                    lName[i].AutoSize = true;
                    lName[i].Location = new Point(170, i * 50);
                    panel1.Controls.Add(lName[i]);

                    lScore[i] = new Label();
                    lScore[i].Text = orderedResult[i].score.ToString();
                    lScore[i].ForeColor = Color.White;
                    lScore[i].TextAlign = ContentAlignment.TopCenter;
                    lScore[i].AutoSize = true;
                    lScore[i].Location = new Point(560, i * 50);
                    panel1.Controls.Add(lScore[i]);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
