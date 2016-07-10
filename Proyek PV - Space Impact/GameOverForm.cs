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
    public partial class GameOverForm : Form
    {
        public GameOverForm(int scoreTemp)
        {
            InitializeComponent();
            scorePlayer = scoreTemp;
        }

        class CHighScore
        {
            public string name { get; set; }
            public int score { get; set; }
        }
        List<CHighScore> highScore = new List<CHighScore>();

        int scorePlayer;
        int batas;

        private void GameOverForm_Load(object sender, EventArgs e)
        {
            label2.Text = "Your score is " + scorePlayer + " type your name here : ";

            CHighScore data1 = new CHighScore();
            data1.name = "InsertRandomCharacterHere :(";
            data1.score = scorePlayer;
            highScore.Add(data1);
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
            }

            var orderedResult = highScore.OrderByDescending(f => f.score).ToList();
            
            if (highScore.Count() < 5)
            {
                batas = highScore.Count();
            }
            else
            {
                batas = 5;
            }
            bool masukHighScore = false;
            for (int i = 0; i < batas; i++)
            {
                if (data1.name == orderedResult[i].name && data1.score == orderedResult[i].score)
                {
                    masukHighScore = true;
                }
            }
            if (masukHighScore == false)
            {
                this.DialogResult = DialogResult.No;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            highScore.Clear();
            CHighScore data1 = new CHighScore();
            data1.name = textBox1.Text;
            data1.score = scorePlayer;
            highScore.Add(data1);
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
            }
            var orderedResult = highScore.OrderByDescending(f => f.score).ToList();
            XmlWriterSettings xmlSetting = new XmlWriterSettings();
            xmlSetting.Indent = true;
            XmlWriter writer = XmlWriter.Create(Application.StartupPath + "/highScore.xml", xmlSetting);

            writer.WriteStartElement("spaceImpact");
            for (int i = 0; i < batas; i++)
            {
                writer.WriteStartElement("highScore");
                writer.WriteElementString("name", orderedResult[i].name);
                writer.WriteElementString("score", orderedResult[i].score.ToString());
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.Close();
            //this.Close();
        }
    }
}
