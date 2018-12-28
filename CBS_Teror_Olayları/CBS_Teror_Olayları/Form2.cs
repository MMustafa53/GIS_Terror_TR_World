using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapInfo;
using System.Runtime.InteropServices;
namespace CBS_Teror_Olayları
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public static MapInfo.MapInfoApplication mi;
        public static bool ucd = false;
        [DllImport("user32.dll")]
        static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        public static string win_id;
        private void Form2_Load(object sender, EventArgs e)
        {
            mi = new MapInfo.MapInfoApplication();
            int p = panel1.Handle.ToInt32();
            mi.Do("set next document parent " + p.ToString() + "style 1");
            mi.Do("set application window " + p.ToString());
            mi.Do("run application \"" + "C:/Users/mmhus/Desktop/dunya.wor" + "\"");
            win_id = mi.Eval("frontwindow()");
        }

        private void yilSaldiri_Click(object sender, EventArgs e)
        {
            grafikDunya grafikD = new grafikDunya();
            grafikD.kontrolD = "yilSaldiriD";
            grafikD.ShowDialog();
        }

        private void yilOlen_Click(object sender, EventArgs e)
        {
            grafikDunya grafikD = new grafikDunya();
            grafikD.kontrolD = "yilOlenD";
            grafikD.ShowDialog();
        }

        private void bolgeSaldiri_Click(object sender, EventArgs e)
        {
            grafikDunya grafikD = new grafikDunya();
            grafikD.kontrolD = "bolgeSaldiriD";
            grafikD.ShowDialog();
        }

        private void yilYarali_Click(object sender, EventArgs e)
        {
            grafikDunya grafikD = new grafikDunya();
            grafikD.kontrolD = "yilYaraliD";
            grafikD.ShowDialog();
        }

        private void saldiriTuru_Click(object sender, EventArgs e)
        {
            grafikDunya grafikD = new grafikDunya();
            grafikD.kontrolD = "saldiriTuruD";
            grafikD.ShowDialog();
        }

        private void saldiriHedef_Click(object sender, EventArgs e)
        {
            grafikDunya grafikD = new grafikDunya();
            grafikD.kontrolD = "saldiriHedefD";
            grafikD.ShowDialog();
        }

        private void saldiriSilahTuru_Click(object sender, EventArgs e)
        {
            grafikDunya grafikD = new grafikDunya();
            grafikD.kontrolD = "saldiriSilahTuruD";
            grafikD.ShowDialog();
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            if (mi != null)
            {
                turkiye f1 = new turkiye();
                Size x = f1.Size;
                // The form has been resized. 
                if (mi.Eval("WindowID(0)") != "")
                {
                    // Update the map to match the current size of the panel. 
                    MoveWindow((System.IntPtr)long.Parse(mi.Eval("WindowInfo(FrontWindow(),12)")), 0, 0, this.panel1.Width, this.panel1.Height, false);
                }

            }
        }
    }
}
