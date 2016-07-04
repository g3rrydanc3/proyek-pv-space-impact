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
        List<string> name = new List<string>();
        List<string> score = new List<string>();

        private void HighScoreForm_Load(object sender, EventArgs e)
        {
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
        }
    }
}
