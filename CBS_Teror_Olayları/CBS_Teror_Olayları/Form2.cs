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

        //  ############################### -- GRAFIKLER -- ############################### //
        public void grafikCizD(String kontrol)
        {
            grafikDunya grafikD = new grafikDunya();
            grafikD.kontrolD = kontrol;
            grafikD.ShowDialog();
        }
        private void yıllaraGöreSaldırıSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafikCizD("yilSaldiriD");
        }

        private void yıllaraGöreÖlenİnsanSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafikCizD("yilOlenD");
        }

        private void yıllaraGöreYaralıİnsanSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafikCizD("yilYaraliD");
        }

        private void bölgelereGöreSaldırıSayılarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafikCizD("bolgeSaldiriD");
        }

        private void saldırıTürleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafikCizD("saldiriTuruD");
        }

        private void saldırılanHedeflerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafikCizD("saldiriHedefD");
        }

        private void saldırılırdaKullanılanSilahlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafikCizD("saldiriSilahTuruD");
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

        //  ############################### -- TEMATIKLER -- ############################### //
        public void removetematik()
        {
            for (int k = Convert.ToInt16(mi.Eval("mapperinfo(" + win_id + ",9)")); k > 0; k = k - 1)
            {
                if (Convert.ToInt16(mi.Eval("layerinfo(" + win_id + "," + Convert.ToString(k) + ",24)")) == 3)
                {
                    mi.Do("remove map layer \"" + mi.Eval("layerinfo(" + win_id + "," + Convert.ToString(k) + ",1)") + "\"");
                }
            }
        }

        private void ülkelereGöreSaldırıSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removetematik();
            mi.Do("Set Map Window " + win_id + " Layer 1 Label With Country + saldiri");
            int n = 5;
            string p = panel1.Handle.ToString();
            string thematic_column = string.Empty;
            mi.Do("select saldiri from dunya order by saldiri into sel noselect");
            thematic_column = "saldiri";
            int range = Convert.ToInt16(mi.Eval("int(tableinfo(sel,8)/" + Convert.ToString(n) + ")"));
            int c_range = Convert.ToInt16(255 / n);
            //----------part 2 -----
            mi.Do("fetch first from sel");
            string r1 = Convert.ToString(mi.Eval("sel.col1"));
            string r2 = string.Empty;
            string cmstr = string.Empty;

            for (int i = 1; i < n; i++)
            {
                mi.Do("fetch rec " + Convert.ToString(i * range) + " from sel");
                r2 = Convert.ToString(mi.Eval("sel.col1"));
                string rgb = Convert.ToString(mi.Eval("RGB(255," + Convert.ToString((n - i) * c_range) + "," + Convert.ToString((n - i) * c_range) + ")"));
                cmstr = cmstr + r1 + ":" + r2 + " brush(2," + rgb + ",16777215), ";
                r1 = r2;
            }
            mi.Do("fetch last from sel");
            r2 = Convert.ToString(mi.Eval("sel.col1"));
            cmstr = cmstr + r1 + ":" + r2 + " brush(2,16711680,16777215)";
            // ----------part 3 -----
            mi.Do("shade window " + win_id + " dunya with " + thematic_column + " ranges apply all use color Brush (2,16711680,16777215) " + cmstr);
            mi.Do("Set Next Document Parent " + p + " Style 1");
            mi.Do("set legend window " + win_id + " layer prev display  on shades on symbols off lines off count on title \"Ülkelere Göre Saldırı Sayısı\"");
            int p1 = panel2.Handle.ToInt32();
            mi.Do("Set Next Document Parent " + p1 + "Style 1");
            mi.Do("Create Cartographic Legend From Window " + win_id + " Behind Frame From Layer 1");
        }

        private void ülkelereGöreÖlenİnsanSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removetematik();
            mi.Do("Set Map Window " + win_id + " Layer 1 Label With Country + olenSayisi");
            int n = 5;
            string p = panel1.Handle.ToString();
            string thematic_column = string.Empty;
            mi.Do("select olenSayisi from dunya order by olenSayisi into sel noselect");
            thematic_column = "olenSayisi";
            int range = Convert.ToInt16(mi.Eval("int(tableinfo(sel,8)/" + Convert.ToString(n) + ")"));
            int c_range = Convert.ToInt16(255 / n);
            //----------part 2 -----
            mi.Do("fetch first from sel");
            string r1 = Convert.ToString(mi.Eval("sel.col1"));
            string r2 = string.Empty;
            string cmstr = string.Empty;

            for (int i = 1; i < n; i++)
            {
                mi.Do("fetch rec " + Convert.ToString(i * range) + " from sel");
                r2 = Convert.ToString(mi.Eval("sel.col1"));
                string rgb = Convert.ToString(mi.Eval("RGB(255," + Convert.ToString((n - i) * c_range) + "," + Convert.ToString((n - i) * c_range) + ")"));
                cmstr = cmstr + r1 + ":" + r2 + " brush(2," + rgb + ",16777215), ";
                r1 = r2;
            }
            mi.Do("fetch last from sel");
            r2 = Convert.ToString(mi.Eval("sel.col1"));
            cmstr = cmstr + r1 + ":" + r2 + " brush(2,16711680,16777215)";
            // ----------part 3 -----
            mi.Do("shade window " + win_id + " dunya with " + thematic_column + " ranges apply all use color Brush (2,16711680,16777215) " + cmstr);
            mi.Do("Set Next Document Parent " + p + " Style 1");
            mi.Do("set legend window " + win_id + " layer prev display  on shades on symbols off lines off count on title \"Ülkelere Göre Ölen İnsan Sayısı\"");
            int p1 = panel2.Handle.ToInt32();
            mi.Do("Set Next Document Parent " + p1 + "Style 1");
            mi.Do("Create Cartographic Legend From Window " + win_id + " Behind Frame From Layer 1");
        }

        private void ülkelereGöreYaralıİnsanSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removetematik();
            mi.Do("Set Map Window " + win_id + " Layer 1 Label With Country + yaraliSayisi");
            int n = 5;
            string p = panel1.Handle.ToString();
            string thematic_column = string.Empty;
            mi.Do("select yaraliSayisi from dunya order by yaraliSayisi into sel noselect");
            thematic_column = "yaraliSayisi";
            int range = Convert.ToInt16(mi.Eval("int(tableinfo(sel,8)/" + Convert.ToString(n) + ")"));
            int c_range = Convert.ToInt16(255 / n);
            //----------part 2 -----
            mi.Do("fetch first from sel");
            string r1 = Convert.ToString(mi.Eval("sel.col1"));
            string r2 = string.Empty;
            string cmstr = string.Empty;

            for (int i = 1; i < n; i++)
            {
                mi.Do("fetch rec " + Convert.ToString(i * range) + " from sel");
                r2 = Convert.ToString(mi.Eval("sel.col1"));
                string rgb = Convert.ToString(mi.Eval("RGB(255," + Convert.ToString((n - i) * c_range) + "," + Convert.ToString((n - i) * c_range) + ")"));
                cmstr = cmstr + r1 + ":" + r2 + " brush(2," + rgb + ",16777215), ";
                r1 = r2;
            }
            mi.Do("fetch last from sel");
            r2 = Convert.ToString(mi.Eval("sel.col1"));
            cmstr = cmstr + r1 + ":" + r2 + " brush(2,16711680,16777215)";
            // ----------part 3 -----
            mi.Do("shade window " + win_id + " dunya with " + thematic_column + " ranges apply all use color Brush (2,16711680,16777215) " + cmstr);
            mi.Do("Set Next Document Parent " + p + " Style 1");
            mi.Do("set legend window " + win_id + " layer prev display  on shades on symbols off lines off count on title \"Ülkelere Göre Ölen İnsan Sayısı\"");
            int p1 = panel2.Handle.ToInt32();
            mi.Do("Set Next Document Parent " + p1 + "Style 1");
            mi.Do("Create Cartographic Legend From Window " + win_id + " Behind Frame From Layer 1");
        }

        private void bombalıSaldırıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removetematik();
            mi.Do("Set Map Window " + win_id + " Layer 1 Label With Country + olenSayisi");
            int n = 5;
            string p = panel1.Handle.ToString();
            string thematic_column = string.Empty;
            mi.Do("select olenSayisi from dunya order by olenSayisi into sel noselect");
            thematic_column = "olenSayisi";
            int range = Convert.ToInt16(mi.Eval("int(tableinfo(sel,8)/" + Convert.ToString(n) + ")"));
            int c_range = Convert.ToInt16(255 / n);
            //----------part 2 -----
            mi.Do("fetch first from sel");
            string r1 = Convert.ToString(mi.Eval("sel.col1"));
            string r2 = string.Empty;
            string cmstr = string.Empty;

            for (int i = 1; i < n; i++)
            {
                mi.Do("fetch rec " + Convert.ToString(i * range) + " from sel");
                r2 = Convert.ToString(mi.Eval("sel.col1"));
                string rgb = Convert.ToString(mi.Eval("RGB(255," + Convert.ToString((n - i) * c_range) + "," + Convert.ToString((n - i) * c_range) + ")"));
                cmstr = cmstr + r1 + ":" + r2 + " brush(2," + rgb + ",16777215), ";
                r1 = r2;
            }
            mi.Do("fetch last from sel");
            r2 = Convert.ToString(mi.Eval("sel.col1"));
            cmstr = cmstr + r1 + ":" + r2 + " brush(2,16711680,16777215)";
            // ----------part 3 -----
            mi.Do("shade window " + win_id + " dunya with " + thematic_column + " ranges apply all use color Brush (2,16711680,16777215) " + cmstr);
            mi.Do("Set Next Document Parent " + p + " Style 1");
            mi.Do("set legend window " + win_id + " layer prev display  on shades on symbols off lines off count on title \"Ülkelere Göre Ölen İnsan Sayısı\"");
            int p1 = panel2.Handle.ToInt32();
            mi.Do("Set Next Document Parent " + p1 + "Style 1");
            mi.Do("Create Cartographic Legend From Window " + win_id + " Behind Frame From Layer 1");
        }

        private void kundaklamalardaÖlenİnsanSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ateşliSilahlıSaldırılardaÖlenİnsanSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bombalıSaldırılardaYaralıİnsanSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void kundaklamalardaYaralıİnsanSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ateşliSilahlıSaldırılardaYaralıİnsanSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bobalıSaldırıSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
