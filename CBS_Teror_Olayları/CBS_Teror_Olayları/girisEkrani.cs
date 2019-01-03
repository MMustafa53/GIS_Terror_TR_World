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
    public partial class girisEkrani : Form
    {
        public girisEkrani()
        {
            InitializeComponent();
        }

        private void turkiyeBtn_Click(object sender, EventArgs e)
        {
            turkiye tr = new turkiye();
            tr.ShowDialog();
        }

        private void dunyaBtn_Click(object sender, EventArgs e)
        {
            Form2 dunya = new Form2();
            dunya.ShowDialog();
        }
    }
}
