using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Reflection;
using NAudio;
using NAudio.Wave;

namespace Proyek_PV___Space_Impact
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string resourceName = new AssemblyName(args.Name).Name + ".dll";
                string resource = Array.Find(this.GetType().Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };
            InitializeComponent();
        }

        IWavePlayer waveOutDevice;
        AudioFileReader audioFileReader;

        protected override void SetVisibleCore(bool value)
        {
            if (!this.IsHandleCreated)
            {
                this.CreateHandle();
                value = true;
            }
            base.SetVisibleCore(value);
        }

        private void CloseWaveOut()
        {
            if (waveOutDevice != null)
            {
                waveOutDevice.Stop();
            }
            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
                audioFileReader = null;
            }
            if (waveOutDevice != null)
            {
                waveOutDevice.Dispose();
                waveOutDevice = null;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            waveOutDevice = new WaveOut();
            audioFileReader = new AudioFileReader(Application.StartupPath + "/sfx/menu_bgm.mp3");
            waveOutDevice.Init(audioFileReader);
            waveOutDevice.Play();
        }

        private void MenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseWaveOut();
            if (e.CloseReason == CloseReason.UserClosing)
            {
                System.Environment.Exit(1);
            }
        }

        private void _MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void _MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetVisibleCore(false);
            ChoosePlaneForm fPlane = new ChoosePlaneForm();
            fPlane.ShowDialog();
            if (fPlane.pesawat != -1)
            {
                waveOutDevice.Stop();
                LoadingForm fLoading = new LoadingForm();
                fLoading.ShowDialog();
                if (fLoading.finished == true)
                {
                    BattleForm fBattle = new BattleForm(fPlane.pesawat);
                    fBattle.ShowDialog();
                }
                audioFileReader.Position = 0;
                waveOutDevice.Play();
            }
            SetVisibleCore(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetVisibleCore(false);
            HighScoreForm f = new HighScoreForm();
            f.ShowDialog();
            SetVisibleCore(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            CloseWaveOut();
            System.Environment.Exit(1);
        }
    }
}
