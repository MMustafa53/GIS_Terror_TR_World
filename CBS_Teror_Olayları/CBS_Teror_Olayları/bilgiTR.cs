using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CBS_Teror_Olayları
{
    public partial class bilgiTR : Form
    {
        string il = "İl: ", tss = "Toplam Saldırı Sayısı: ", tos = "Toplam Ölen İnsan Sayısı: ", tys = "Toplam Yaralı İnsan Sayısı: ",
            bss = "Bombalı Saldırı Sayısı: ", bos = "Bombalı Saldırılarda Ölen İnsan Sayısı: ", bys = "Bombalı Saldırılarda Yaralanan İnsan Sayısı: ",
            kss = "Kundaklama Saldırı Sayısı: ", kos = "Kundaklama Saldırılarında Ölen İnsan Sayısı: ", kys = "Kundaklama Saldırılarında Yaralanan İnsan Sayısı: ",
            atess = "Ateşli Silah Saldırı Sayısı: ", aos = "Ateşli Silah Saldırılarında Ölen İnsan Sayısı: ", ays = "Ateşli Silah Saldırılarında Ölen İnsan Sayısı: ";
        double tssdb, tosdb, tysdb, bssdb, bosdb, bysdb, kssdb, kosdb, kysdb, atessdb, aosdb, aysdb;


        public bilgiTR()
        {
            InitializeComponent();
        }


        private void bilgiTR_FormClosing(object sender, FormClosingEventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();

            chart2.Series[0].Points.Clear();
            chart2.Series[1].Points.Clear();
            chart2.Series[2].Points.Clear();

            chart3.Series[0].Points.Clear();
            chart3.Series[1].Points.Clear();
            chart3.Series[2].Points.Clear();

            chart4.Series[0].Points.Clear();
            chart4.Series[1].Points.Clear();
            chart4.Series[2].Points.Clear();
        }

 
        public void fill_form()
        {
            chart1.Series.Clear();
            chart2.Series.Clear();
            chart3.Series.Clear();
            chart4.Series.Clear();


            labelIL.Text = il + turkiye.mi.Eval("iller.il_adi");
            labeltss.Text = tss + turkiye.mi.Eval("iller.saldiri");
            labeltos.Text = tos + turkiye.mi.Eval("iller.oluSayisi");
            labeltys.Text = tys + turkiye.mi.Eval("iller.yaraliSayisi");
            labelbss.Text = bss + turkiye.mi.Eval("iller.bombaliSaldiri");
            labelbos.Text = bos + turkiye.mi.Eval("iller.bombaliOlu");
            labelbys.Text = bys + turkiye.mi.Eval("iller.bombaliYarali");
            labelkss.Text = kss + turkiye.mi.Eval("iller.kundaklama");
            labelkos.Text = kos + turkiye.mi.Eval("iller.kundaklamaOlu");
            labelkys.Text = kys + turkiye.mi.Eval("iller.kundaklamaYarali");
            labelatess.Text = atess + turkiye.mi.Eval("iller.atesliSilah");
            labelaos.Text = aos + turkiye.mi.Eval("iller.atesliSilahOlu");
            labelays.Text = ays + turkiye.mi.Eval("iller.atesliSilahYarali");

            tssdb = Convert.ToDouble(turkiye.mi.Eval("iller.saldiri"));
            tosdb = Convert.ToDouble(turkiye.mi.Eval("iller.oluSayisi"));
            tysdb = Convert.ToDouble(turkiye.mi.Eval("iller.yaraliSayisi"));
            bssdb = Convert.ToDouble(turkiye.mi.Eval("iller.bombaliSaldiri"));
            bosdb = Convert.ToDouble(turkiye.mi.Eval("iller.bombaliOlu"));
            bysdb = Convert.ToDouble(turkiye.mi.Eval("iller.bombaliYarali"));
            kssdb = Convert.ToDouble(turkiye.mi.Eval("iller.kundaklama"));
            kosdb = Convert.ToDouble(turkiye.mi.Eval("iller.kundaklamaOlu"));
            kysdb = Convert.ToDouble(turkiye.mi.Eval("iller.kundaklamaYarali"));
            atessdb = Convert.ToDouble(turkiye.mi.Eval("iller.atesliSilah"));
            aosdb = Convert.ToDouble(turkiye.mi.Eval("iller.atesliSilahOlu"));
            aysdb = Convert.ToDouble(turkiye.mi.Eval("iller.atesliSilahYarali"));

            var tssV = new Series("Saldırı Sayısı");
            var tosV = new Series("Ölen İnsan Sayısı");
            var tysV = new Series("Yaralı İnsan Sayısı");
            var bssV = new Series("Saldırı Sayısı");
            var bosV = new Series("Ölen İnsan Sayısı");
            var bysV = new Series("Yaralı İnsan Sayısı");
            var kssV = new Series("Saldırı Sayısı");
            var kosV = new Series("Ölen İnsan Sayısı");
            var kysV = new Series("Yaralı İnsan Sayısı");
            var atessV = new Series("Saldırı Sayısı");
            var aosV = new Series("Ölen İnsan Sayısı");
            var aysV = new Series("Yaralı İnsan Sayısı");

            tssV.Points.Clear();
            tssV.Points.AddY(tssdb);
            tssV.Label = tssdb.ToString();
            tosV.Points.AddY(tosdb);
            tosV.Label = tosdb.ToString();
            tysV.Points.AddY(tysdb);
            tysV.Label = tysdb.ToString();
            tysV.AxisLabel = "Toplam Sonuçlar";
            chart1.Series.Add(tssV);
            chart1.Series.Add(tosV);
            chart1.Series.Add(tysV);


            bssV.Points.AddY(bssdb);
            bssV.Label = bssdb.ToString();
            bosV.Points.AddY(bosdb);
            bosV.Label = bosdb.ToString();
            bysV.Points.AddY(bysdb);
            bysV.Label = bysdb.ToString();
            bysV.AxisLabel = "Bombalı Saldırı Sonuçları";
            chart2.Series.Add(bssV);
            chart2.Series.Add(bosV);
            chart2.Series.Add(bysV);


            kssV.Points.AddY(kssdb);
            kssV.Label = kssdb.ToString();
            kosV.Points.AddY(kosdb);
            kosV.Label = kosdb.ToString();
            kysV.Points.AddY(kysdb);
            kysV.Label = kysdb.ToString();
            kysV.AxisLabel = "Kundaklama Sonuçları";
            chart3.Series.Add(kssV);
            chart3.Series.Add(kosV);
            chart3.Series.Add(kysV);


            atessV.Points.AddY(atessdb);
            atessV.Label = atessdb.ToString();
            aosV.Points.AddY(aosdb);
            aosV.Label = aosdb.ToString();
            aysV.Points.AddY(aysdb);
            aysV.Label = aysdb.ToString();
            aysV.AxisLabel = "Ateşli Silah Sonuçları";
            chart4.Series.Add(atessV);
            chart4.Series.Add(aosV);
            chart4.Series.Add(aysV);

            this.ShowDialog();
        }
    }
}
