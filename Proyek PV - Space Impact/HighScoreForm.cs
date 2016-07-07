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
                    name.Add(reader.ReadElementString("name"));
                    score.Add(reader.ReadElementString("score"));
                    reader.ReadEndElement();
                }
                reader.ReadEndElement();
                reader.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
