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
    public partial class turkiye : Form
    {
        public turkiye()
        {
            InitializeComponent();
            this.StartPosition = 0;
        }
        public static MapInfo.MapInfoApplication mi;
        public static bool ucd = false;
        [DllImport("user32.dll")]
        static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        public static string win_id;
        private void Form1_Load(object sender, EventArgs e)
        {
            mi = new MapInfo.MapInfoApplication();
            int p = panel1.Handle.ToInt32();
            mi.Do("set next document parent " + p.ToString() + "style 1");
            mi.Do("set application window " + p.ToString());
            mi.Do("run application \"" + "C:/Users/mmhus/Desktop/turkiye.wor" + "\"");
            win_id = mi.Eval("frontwindow()");
        }

        private void Form1_Resize(object sender, EventArgs e)
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

        //  ############################### -- GRAFIKLER -- ############################### //

        private void yilSaldiri_Click(object sender, EventArgs e)
        {
            
            grafikler grafik = new grafikler();
            grafik.kontrol = "yilSaldiri";
            grafik.ShowDialog();
        }

        private void bolgeSaldiri_Click(object sender, EventArgs e)
        {
            grafikler grafik = new grafikler();
            grafik.kontrol = "bolgeSaldiri";
            grafik.ShowDialog();
        }

        private void saldiriTuru_Click(object sender, EventArgs e)
        {
            grafikler grafik = new grafikler();
            grafik.kontrol = "saldiriTuru";
            grafik.ShowDialog();
        }

        private void saldiriSilahTuru_Click(object sender, EventArgs e)
        {
            grafikler grafik = new grafikler();
            grafik.kontrol = "saldiriSilahTuru";
            grafik.ShowDialog();
        }

        private void terorOrgut_Click(object sender, EventArgs e)
        {
            grafikler grafik = new grafikler();
            grafik.kontrol = "terorOrgut";
            grafik.ShowDialog();
        }

        private void saldiriHedef_Click(object sender, EventArgs e)
        {
            grafikler grafik = new grafikler();
            grafik.kontrol = "saldiriHedef";
            grafik.ShowDialog();
        }

        private void yilYarali_Click(object sender, EventArgs e)
        {
            grafikler grafik = new grafikler();
            grafik.kontrol = "yilYarali";
            grafik.ShowDialog();
        }

        private void yilOlen_Click(object sender, EventArgs e)
        {
            grafikler grafik = new grafikler();
            grafik.kontrol = "yilOlen";
            grafik.ShowDialog();
        }


        //  ############################### -- TEMATIKLER -- ############################### //


        private void ilOlen_Click(object sender, EventArgs e)
        {

        }

        private void ilYarali_Click(object sender, EventArgs e)
        {

        }


    }
}
