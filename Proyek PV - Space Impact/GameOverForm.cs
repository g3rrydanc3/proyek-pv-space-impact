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
        int scorePlayer;
        List<string> name = new List<string>();
        List<string> score = new List<string>();
        public GameOverForm(int scoreTemp)
        {
            InitializeComponent();
            scorePlayer = scoreTemp;
        }

        private void GameOverForm_Load(object sender, EventArgs e)
        {
            label2.Text = "Your score is " + scorePlayer + " type your name here : ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            name.Add(textBox1.Text);
            score.Add(scorePlayer.ToString());
            if (File.Exists(Application.StartupPath + "/highScore.xml"))
            {
                XmlTextReader reader = new XmlTextReader(Application.StartupPath + "/highScore.xml");
                reader.ReadStartElement();
                while (reader.IsStartElement("highScore"))
                {
                    reader.ReadStartElement();
                    name.Add(reader.ReadElementString("name"));
                    score.Add(reader.ReadElementString("score"));
                    reader.ReadEndElement();
                }
                reader.ReadEndElement();
                reader.Close();
            }

            XmlWriterSettings xmlSetting = new XmlWriterSettings();
            xmlSetting.Indent = true;
            XmlWriter writer = XmlWriter.Create(Application.StartupPath + "/highScore.xml", xmlSetting);

            writer.WriteStartElement("spaceImpact");
            for (int i = 0; i < score.Count(); i++)
            {
                writer.WriteStartElement("highScore");
                writer.WriteElementString("name", name[i]);
                writer.WriteElementString("score", score[i]);
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            writer.Close();
            this.Close();
        }
    }
}
