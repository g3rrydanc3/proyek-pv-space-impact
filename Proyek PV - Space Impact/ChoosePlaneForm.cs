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
        public int pesawat = -1;

        protected override void SetVisibleCore(bool value)
        {
            if (!this.IsHandleCreated)
            {
                this.CreateHandle();
                value = true;
            }
            base.SetVisibleCore(value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pesawat = 0;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pesawat = 1;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pesawat = 2;
            this.Close();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void _MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }
    }
}
