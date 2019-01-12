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
    public partial class bilgiD : Form
    {
        public bilgiD()
        {
            InitializeComponent();
        }
        string ulke = "Ülke: ", baskent = "Başkent: ", tss = "Toplam Saldırı Sayısı: ", tos = "Toplam Ölen İnsan Sayısı: ", tys = "Toplam Yaralı İnsan Sayısı: ",
            bss = "Bombalı Saldırı Sayısı: ", bos = "Bombalı Saldırılarda Ölen İnsan Sayısı: ", bys = "Bombalı Saldırılarda Yaralanan İnsan Sayısı: ",
            kss = "Kundaklama Saldırı Sayısı: ", kos = "Kundaklama Saldırılarında Ölen İnsan Sayısı: ", kys = "Kundaklama Saldırılarında Yaralanan İnsan Sayısı: ",
            atess = "Ateşli Silah Saldırı Sayısı: ", aos = "Ateşli Silah Saldırılarında Ölen İnsan Sayısı: ", ays = "Ateşli Silah Saldırılarında Ölen İnsan Sayısı: ";

        double tssdb, tosdb, tysdb, bssdb, bosdb, bysdb, kssdb, kosdb, kysdb, atessdb, aosdb, aysdb;


        private void bilgiD_Load(object sender, EventArgs e)
        {

        }


        private void bilgiD_FormClosing(object sender, FormClosingEventArgs e)
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

            
            labelUlke.Text = ulke + Form2.mi.Eval("dunya.country");
            labelBaskent.Text = baskent + Form2.mi.Eval("dunya.capital");
            labeltss.Text = tss + Form2.mi.Eval("dunya.saldiri");
            labeltos.Text = tos + Form2.mi.Eval("dunya.olenSayisi");
            labeltys.Text = tys + Form2.mi.Eval("dunya.yaraliSayisi");
            labelbss.Text = bss + Form2.mi.Eval("dunya.bombaliSaldiri");
            labelbos.Text = bos + Form2.mi.Eval("dunya.bombaliOlu");
            labelbys.Text = bys + Form2.mi.Eval("dunya.bombaliYarali");
            labelkss.Text = kss + Form2.mi.Eval("dunya.kundaklamaSaldiri");
            labelkos.Text = kos + Form2.mi.Eval("dunya.kundaklamaOlu");
            labelkys.Text = kys + Form2.mi.Eval("dunya.kundaklamaYarali");
            labelatess.Text = atess + Form2.mi.Eval("dunya.atesliSilahSaldiri");
            labelaos.Text = aos + Form2.mi.Eval("dunya.atesliSilahOlu");
            labelays.Text = ays + Form2.mi.Eval("dunya.atesliSilahYarali");

            tssdb = Convert.ToDouble(Form2.mi.Eval("dunya.saldiri"));
            tosdb = Convert.ToDouble(Form2.mi.Eval("dunya.olenSayisi"));
            tysdb = Convert.ToDouble(Form2.mi.Eval("dunya.yaraliSayisi"));
            bssdb = Convert.ToDouble(Form2.mi.Eval("dunya.bombaliSaldiri"));
            bosdb = Convert.ToDouble(Form2.mi.Eval("dunya.bombaliOlu"));
            bysdb = Convert.ToDouble(Form2.mi.Eval("dunya.bombaliYarali"));
            kssdb = Convert.ToDouble(Form2.mi.Eval("dunya.kundaklamaSaldiri"));
            kosdb = Convert.ToDouble(Form2.mi.Eval("dunya.kundaklamaOlu"));
            kysdb = Convert.ToDouble(Form2.mi.Eval("dunya.kundaklamaYarali"));
            atessdb = Convert.ToDouble(Form2.mi.Eval("dunya.atesliSilahSaldiri"));
            aosdb = Convert.ToDouble(Form2.mi.Eval("dunya.atesliSilahOlu"));
            aysdb = Convert.ToDouble(Form2.mi.Eval("dunya.atesliSilahYarali"));

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
