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
        private void yıllaraGöreSaldırıSaysıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafikler grafik = new grafikler();
            grafik.kontrol = "yilSaldiri";
            grafik.ShowDialog();
        }

        private void yıllaraGöreÖlenİnsanSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafikler grafik = new grafikler();
            grafik.kontrol = "yilOlen";
            grafik.ShowDialog();
        }

        private void yıllaraGöreYaralıİnsanSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafikler grafik = new grafikler();
            grafik.kontrol = "yilYarali";
            grafik.ShowDialog();
        }

        private void bölgelereGöreSaldırıSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafikler grafik = new grafikler();
            grafik.kontrol = "bolgeSaldiri";
            grafik.ShowDialog();
        }

        private void saldırıTürleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafikler grafik = new grafikler();
            grafik.kontrol = "saldiriTuru";
            grafik.ShowDialog();
        }

        private void saldırılanHedeflerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafikler grafik = new grafikler();
            grafik.kontrol = "saldiriHedef";
            grafik.ShowDialog();
        }

        private void saldırılırdaKullanılanSilahlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafikler grafik = new grafikler();
            grafik.kontrol = "saldiriSilahTuru";
            grafik.ShowDialog();
        }

        private void saldırıyeGerçekleştirenÖrgütlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grafikler grafik = new grafikler();
            grafik.kontrol = "terorOrgut";
            grafik.ShowDialog();
        }

        //  ############################### -- TEMATIKLER -- ############################### //

        public void removetematik()
        {
            panel1.Focus();
            for (int k = Convert.ToInt16(mi.Eval("mapperinfo(" + win_id + ",9)")); k > 0; k = k - 1)
            {
                if (Convert.ToInt16(mi.Eval("layerinfo(" + win_id + "," + Convert.ToString(k) + ",24)")) == 3)
                {
                    mi.Do("remove map layer \"" + mi.Eval("layerinfo(" + win_id + "," + Convert.ToString(k) + ",1)") + "\"");
                }
            }
        }


        private void illereGöreÖlenİnsanSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removetematik();
            mi.Do("Set Map Window " + win_id + " Layer 1 Label With IL_ADI + oluSayisi");
            int n = 5;
            string p = panel1.Handle.ToString();
            string thematic_column = string.Empty;
            mi.Do("select oluSayisi from iller order by oluSayisi into sel noselect");
            thematic_column = "oluSayisi";
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
            mi.Do("shade window " + win_id + " iller with " + thematic_column + " ranges apply all use color Brush (2,16711680,16777215) " + cmstr);
            mi.Do("Set Next Document Parent " + p + " Style 1");
            mi.Do("set legend window " + win_id + " layer prev display  on shades on symbols off lines off count on title \"İllere Göre Ölen İnsan Sayısı\"");
            int p1 = panel2.Handle.ToInt32();
            mi.Do("Set Next Document Parent " + p1 + "Style 1");
            mi.Do("Create Cartographic Legend From Window " + win_id + " Behind Frame From Layer 1");
        }

        private void illereGöreYaralıİnsanSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removetematik();
            mi.Do("Set Map Window " +win_id+  " Layer 1 Label With IL_ADI + yaraliSayisi");
            int n = 5;
            string p = panel1.Handle.ToString();
            string thematic_column = string.Empty;
            mi.Do("select yaraliSayisi from iller order by yaraliSayisi into sel noselect");
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
            mi.Do("shade window " + win_id + " iller with " + thematic_column + " ranges apply all use color Brush (2,16711680,16777215) " + cmstr);
            mi.Do("Set Next Document Parent " + p + " Style 1");
            mi.Do("set legend window " + win_id + " layer prev display  on shades on symbols off lines off count on title \"İllere Göre Yaralı İnsan Sayısı\"");
            int p1 = panel2.Handle.ToInt32();
            mi.Do("Set Next Document Parent " + p1 + "Style 1");
            mi.Do("Create Cartographic Legend From Window " + win_id + " Behind Frame From Layer 1");
        }

        private void illereGöreSaldırıSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removetematik();
            mi.Do("Set Map Window " + win_id + " Layer 1 Label With IL_ADI + saldiri");
            int n = 5;
            string p = panel1.Handle.ToString();
            string thematic_column = string.Empty;
            mi.Do("select saldiri from iller order by saldiri into sel noselect");
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
            mi.Do("shade window " + win_id + " iller with " + thematic_column + " ranges apply all use color Brush (2,16711680,16777215) " + cmstr);
            mi.Do("Set Next Document Parent " + p + " Style 1");
            mi.Do("set legend window " + win_id + " layer prev display  on shades on symbols off lines off count on title \"İllere Göre Saldırı Sayısı\"");
            int p1 = panel2.Handle.ToInt32();
            mi.Do("Set Next Document Parent " + p1 + "Style 1");
            mi.Do("Create Cartographic Legend From Window " + win_id + " Behind Frame From Layer 1");
        }

        private void bombalıSaldırıSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removetematik();
            mi.Do("Set Map Window " + win_id + " Layer 1 Label With IL_ADI + bombaliSaldiri");
            int n = 5;
            string p = panel1.Handle.ToString();
            string thematic_column = string.Empty;
            mi.Do("select bombaliSaldiri from iller order by bombaliSaldiri into sel noselect");
            thematic_column = "bombaliSaldiri";
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
            mi.Do("shade window " + win_id + " iller with " + thematic_column + " ranges apply all use color Brush (2,16711680,16777215) " + cmstr);
            mi.Do("Set Next Document Parent " + p + " Style 1");
            mi.Do("set legend window " + win_id + " layer prev display  on shades on symbols off lines off count on title \"İllere Göre Bombalı Saldırı Sayısı\"");
            int p1 = panel2.Handle.ToInt32();
            mi.Do("Set Next Document Parent " + p1 + "Style 1");
            mi.Do("Create Cartographic Legend From Window " + win_id + " Behind Frame From Layer 1");
        }

        private void kundaklamaSaldırıSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removetematik();
            mi.Do("Set Map Window " + win_id + " Layer 1 Label With IL_ADI + kundaklama");
            int n = 5;
            string p = panel1.Handle.ToString();
            string thematic_column = string.Empty;
            mi.Do("select kundaklama from iller order by kundaklama into sel noselect");
            thematic_column = "kundaklama";
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
            mi.Do("shade window " + win_id + " iller with " + thematic_column + " ranges apply all use color Brush (2,16711680,16777215) " + cmstr);
            mi.Do("Set Next Document Parent " + p + " Style 1");
            mi.Do("set legend window " + win_id + " layer prev display  on shades on symbols off lines off count on title \"İllere Göre Kundaklama Saldırı Sayısı\"");
            int p1 = panel2.Handle.ToInt32();
            mi.Do("Set Next Document Parent " + p1 + "Style 1");
            mi.Do("Create Cartographic Legend From Window " + win_id + " Behind Frame From Layer 1");
        }

        private void ateşliSilahSaldırıSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removetematik();
            mi.Do("Set Map Window " + win_id + " Layer 1 Label With IL_ADI + atesliSilah");
            int n = 5;
            string p = panel1.Handle.ToString();
            string thematic_column = string.Empty;
            mi.Do("select atesliSilah from iller order by atesliSilah into sel noselect");
            thematic_column = "atesliSilah";
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
            mi.Do("shade window " + win_id + " iller with " + thematic_column + " ranges apply all use color Brush (2,16711680,16777215) " + cmstr);
            mi.Do("Set Next Document Parent " + p + " Style 1");
            mi.Do("set legend window " + win_id + " layer prev display  on shades on symbols off lines off count on title \"İllere Göre Ateşli Silah Saldırı Sayısı\"");
            int p1 = panel2.Handle.ToInt32();
            mi.Do("Set Next Document Parent " + p1 + "Style 1");
            mi.Do("Create Cartographic Legend From Window " + win_id + " Behind Frame From Layer 1");
        }

        private void bombalıSaldırılardaÖlenİnsanSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removetematik();
            mi.Do("Set Map Window " + win_id + " Layer 1 Label With IL_ADI + bombaliOlu");
            int n = 5;
            string p = panel1.Handle.ToString();
            string thematic_column = string.Empty;
            mi.Do("select bombaliOlu from iller order by bombaliOlu into sel noselect");
            thematic_column = "bombaliOlu";
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
            mi.Do("shade window " + win_id + " iller with " + thematic_column + " ranges apply all use color Brush (2,16711680,16777215) " + cmstr);
            mi.Do("Set Next Document Parent " + p + " Style 1");
            mi.Do("set legend window " + win_id + " layer prev display  on shades on symbols off lines off count on title \"İllere Göre Bombalı Saldırılarda Ölen İnsan Sayısı\"");
            int p1 = panel2.Handle.ToInt32();
            mi.Do("Set Next Document Parent " + p1 + "Style 1");
            mi.Do("Create Cartographic Legend From Window " + win_id + " Behind Frame From Layer 1");
        }

        private void kundaklamaSaldırılarındaÖlenİnsanSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removetematik();
            mi.Do("Set Map Window " + win_id + " Layer 1 Label With IL_ADI + kundaklamaOlu");
            int n = 5;
            string p = panel1.Handle.ToString();
            string thematic_column = string.Empty;
            mi.Do("select kundaklamaOlu from iller order by kundaklamaOlu into sel noselect");
            thematic_column = "kundaklamaOlu";
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
            mi.Do("shade window " + win_id + " iller with " + thematic_column + " ranges apply all use color Brush (2,16711680,16777215) " + cmstr);
            mi.Do("Set Next Document Parent " + p + " Style 1");
            mi.Do("set legend window " + win_id + " layer prev display  on shades on symbols off lines off count on title \"İllere Göre Kundaklamalarda Ölen İnsan Sayısı\"");
            int p1 = panel2.Handle.ToInt32();
            mi.Do("Set Next Document Parent " + p1 + "Style 1");
            mi.Do("Create Cartographic Legend From Window " + win_id + " Behind Frame From Layer 1");
        }

        private void ateşliSilahlıSaldırılardaÖlenİnsanSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removetematik();
            mi.Do("Set Map Window " + win_id + " Layer 1 Label With IL_ADI + atesliSilahOlu");
            int n = 5;
            string p = panel1.Handle.ToString();
            string thematic_column = string.Empty;
            mi.Do("select atesliSilahOlu from iller order by atesliSilahOlu into sel noselect");
            thematic_column = "atesliSilahOlu";
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
            mi.Do("shade window " + win_id + " iller with " + thematic_column + " ranges apply all use color Brush (2,16711680,16777215) " + cmstr);
            mi.Do("Set Next Document Parent " + p + " Style 1");
            mi.Do("set legend window " + win_id + " layer prev display  on shades on symbols off lines off count on title \"İllere Göre Ateşli Silah Saldırılarında Ölen İnsan Sayısı\"");
            int p1 = panel2.Handle.ToInt32();
            mi.Do("Set Next Document Parent " + p1 + "Style 1");
            mi.Do("Create Cartographic Legend From Window " + win_id + " Behind Frame From Layer 1");
        }

        private void bombalıSaldırılardaYaralıİnsanSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removetematik();
            mi.Do("Set Map Window " + win_id + " Layer 1 Label With IL_ADI + bombaliYarali");
            int n = 5;
            string p = panel1.Handle.ToString();
            string thematic_column = string.Empty;
            mi.Do("select bombaliYarali from iller order by bombaliYarali into sel noselect");
            thematic_column = "bombaliYarali";
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
            mi.Do("shade window " + win_id + " iller with " + thematic_column + " ranges apply all use color Brush (2,16711680,16777215) " + cmstr);
            mi.Do("Set Next Document Parent " + p + " Style 1");
            mi.Do("set legend window " + win_id + " layer prev display  on shades on symbols off lines off count on title \"İllere Göre Bombalı Saldırılarda Ölen İnsan Sayısı\"");
            int p1 = panel2.Handle.ToInt32();
            mi.Do("Set Next Document Parent " + p1 + "Style 1");
            mi.Do("Create Cartographic Legend From Window " + win_id + " Behind Frame From Layer 1");
        }

        private void kundaklamalardaYaralıİnsanSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removetematik();
            mi.Do("Set Map Window " + win_id + " Layer 1 Label With IL_ADI + kundaklamaYarali");
            int n = 5;
            string p = panel1.Handle.ToString();
            string thematic_column = string.Empty;
            mi.Do("select kundaklamaYarali from iller order by kundaklamaYarali into sel noselect");
            thematic_column = "kundaklamaYarali";
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
            mi.Do("shade window " + win_id + " iller with " + thematic_column + " ranges apply all use color Brush (2,16711680,16777215) " + cmstr);
            mi.Do("Set Next Document Parent " + p + " Style 1");
            mi.Do("set legend window " + win_id + " layer prev display  on shades on symbols off lines off count on title \"İllere Göre Kundaklamalarda Yaralanan İnsan Sayısı\"");
            int p1 = panel2.Handle.ToInt32();
            mi.Do("Set Next Document Parent " + p1 + "Style 1");
            mi.Do("Create Cartographic Legend From Window " + win_id + " Behind Frame From Layer 1");
        }

        private void ateşliSilahlıSaldırılardaYaralıİnsanSayısıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removetematik();
            mi.Do("Set Map Window " + win_id + " Layer 1 Label With IL_ADI + atesliSilahYarali");
            int n = 5;
            string p = panel1.Handle.ToString();
            string thematic_column = string.Empty;
            mi.Do("select atesliSilahYarali from iller order by atesliSilahYarali into sel noselect");
            thematic_column = "atesliSilahYarali";
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
            mi.Do("shade window " + win_id + " iller with " + thematic_column + " ranges apply all use color Brush (2,16711680,16777215) " + cmstr);
            mi.Do("Set Next Document Parent " + p + " Style 1");
            mi.Do("set legend window " + win_id + " layer prev display  on shades on symbols off lines off count on title \"İllere Göre Ateşli Silah Saldırılarında Yaralanan İnsan Sayısı\"");
            int p1 = panel2.Handle.ToInt32();
            mi.Do("Set Next Document Parent " + p1 + "Style 1");
            mi.Do("Create Cartographic Legend From Window " + win_id + " Behind Frame From Layer 1");
        }
    }
}
