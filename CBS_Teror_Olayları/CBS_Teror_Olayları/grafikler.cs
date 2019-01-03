using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBS_Teror_Olayları
{
    public partial class grafikler : Form
    {
        public grafikler()
        {
            InitializeComponent();
            this.StartPosition = 0;
        }
        public string kontrol { get; set; }
        private void grafikler_Load(object sender, EventArgs e)
        {
            

            if(kontrol == "yilSaldiri") {
                pictureBox1.Image = Properties.Resources.yilSaldiri;
                kontrol = "";
            }
            else if(kontrol == "yilOlen")
            {
                pictureBox1.Image = Properties.Resources.yilOlen;
                kontrol = "";
            }
            else if (kontrol == "yilYarali")
            {
                pictureBox1.Image = Properties.Resources.yilYarali;
                kontrol = "";
            }
            else if (kontrol == "bolgeSaldiri")
            {
                pictureBox1.Image = Properties.Resources.bolgeSaldiri;
                kontrol = "";
            }
            else if (kontrol == "saldiriTuru")
            {
                pictureBox1.Image = Properties.Resources.saldiriTuru;
                kontrol = "";
            }
            else if (kontrol == "saldiriSilahTuru")
            {
                pictureBox1.Image = Properties.Resources.saldiriSilahTuru;
                kontrol = "";
            }
            else if (kontrol == "terorOrgut")
            {
                pictureBox1.Image = Properties.Resources.terorOrgut;
                kontrol = "";
            }
            else if (kontrol == "saldiriHedef")
            {
                pictureBox1.Image = Properties.Resources.saldiriHedef;
                kontrol = "";
            }

        }
    }
}
