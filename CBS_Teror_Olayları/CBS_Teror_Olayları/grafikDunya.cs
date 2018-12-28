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
    public partial class grafikDunya : Form
    {
        public grafikDunya()
        {
            InitializeComponent();
            this.StartPosition = 0;
        }
        public string kontrolD { get; set; }
        private void grafikDunya_Load(object sender, EventArgs e)
        {
            if (kontrolD == "yilSaldiriD")
            {
                pictureBox1.Image = Properties.Resources.yilSaldiriD;
                kontrolD = "";
            }
            else if (kontrolD == "yilOlenD")
            {
                pictureBox1.Image = Properties.Resources.yilOlenD;
                kontrolD = "";
            }
            else if (kontrolD == "yilYaraliD")
            {
                pictureBox1.Image = Properties.Resources.yilYaraliD;
                kontrolD = "";
            }
            else if (kontrolD == "bolgeSaldiriD")
            {
                pictureBox1.Image = Properties.Resources.bolgeSaldiriD;
                kontrolD = "";
            }
            else if (kontrolD == "saldiriTuruD")
            {
                pictureBox1.Image = Properties.Resources.saldiriTuruD;
                kontrolD = "";
            }
            else if (kontrolD == "saldiriSilahTuruD")
            {
                pictureBox1.Image = Properties.Resources.saldiriSilahTuruD;
                kontrolD = "";
            }
            else if (kontrolD == "saldiriHedefD")
            {
                pictureBox1.Image = Properties.Resources.saldiriHedefD;
                kontrolD = "";
            }
        }
    }
}
