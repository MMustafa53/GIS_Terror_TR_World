namespace CBS_Teror_Olayları
{
    partial class turkiye
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.yilOlen = new System.Windows.Forms.Button();
            this.bolgeSaldiri = new System.Windows.Forms.Button();
            this.saldiriSilahTuru = new System.Windows.Forms.Button();
            this.saldiriTuru = new System.Windows.Forms.Button();
            this.yilYarali = new System.Windows.Forms.Button();
            this.yilSaldiri = new System.Windows.Forms.Button();
            this.gbGrafik = new System.Windows.Forms.GroupBox();
            this.terorOrgut = new System.Windows.Forms.Button();
            this.saldiriHedef = new System.Windows.Forms.Button();
            this.gbTematik = new System.Windows.Forms.GroupBox();
            this.ilYarali = new System.Windows.Forms.Button();
            this.ilOlen = new System.Windows.Forms.Button();
            this.gbGrafik.SuspendLayout();
            this.gbTematik.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(12, 87);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1021, 460);
            this.panel1.TabIndex = 0;
            // 
            // yilOlen
            // 
            this.yilOlen.Location = new System.Drawing.Point(6, 48);
            this.yilOlen.Name = "yilOlen";
            this.yilOlen.Size = new System.Drawing.Size(162, 23);
            this.yilOlen.TabIndex = 1;
            this.yilOlen.Text = "Yıllara Göre Ölen İnsan Sayısı";
            this.yilOlen.UseVisualStyleBackColor = true;
            this.yilOlen.Click += new System.EventHandler(this.yilOlen_Click);
            // 
            // bolgeSaldiri
            // 
            this.bolgeSaldiri.Location = new System.Drawing.Point(174, 19);
            this.bolgeSaldiri.Name = "bolgeSaldiri";
            this.bolgeSaldiri.Size = new System.Drawing.Size(150, 23);
            this.bolgeSaldiri.TabIndex = 3;
            this.bolgeSaldiri.Text = "Bölgelere Göre Saldırı Sayısı";
            this.bolgeSaldiri.UseVisualStyleBackColor = true;
            this.bolgeSaldiri.Click += new System.EventHandler(this.bolgeSaldiri_Click);
            // 
            // saldiriSilahTuru
            // 
            this.saldiriSilahTuru.Location = new System.Drawing.Point(412, 19);
            this.saldiriSilahTuru.Name = "saldiriSilahTuru";
            this.saldiriSilahTuru.Size = new System.Drawing.Size(162, 23);
            this.saldiriSilahTuru.TabIndex = 4;
            this.saldiriSilahTuru.Text = "Saldırılarda Kullanılan Silahlar";
            this.saldiriSilahTuru.UseVisualStyleBackColor = true;
            this.saldiriSilahTuru.Click += new System.EventHandler(this.saldiriSilahTuru_Click);
            // 
            // saldiriTuru
            // 
            this.saldiriTuru.Location = new System.Drawing.Point(330, 19);
            this.saldiriTuru.Name = "saldiriTuru";
            this.saldiriTuru.Size = new System.Drawing.Size(76, 23);
            this.saldiriTuru.TabIndex = 5;
            this.saldiriTuru.Text = "Saldırı Türleri";
            this.saldiriTuru.UseVisualStyleBackColor = true;
            this.saldiriTuru.Click += new System.EventHandler(this.saldiriTuru_Click);
            // 
            // yilYarali
            // 
            this.yilYarali.Location = new System.Drawing.Point(174, 48);
            this.yilYarali.Name = "yilYarali";
            this.yilYarali.Size = new System.Drawing.Size(162, 23);
            this.yilYarali.TabIndex = 6;
            this.yilYarali.Text = "Yıllara Göre Yaralı İnsan Sayısı";
            this.yilYarali.UseVisualStyleBackColor = true;
            this.yilYarali.Click += new System.EventHandler(this.yilYarali_Click);
            // 
            // yilSaldiri
            // 
            this.yilSaldiri.Location = new System.Drawing.Point(6, 19);
            this.yilSaldiri.Name = "yilSaldiri";
            this.yilSaldiri.Size = new System.Drawing.Size(162, 23);
            this.yilSaldiri.TabIndex = 7;
            this.yilSaldiri.Text = "Yıllara Göre Saldırı Sayısı";
            this.yilSaldiri.UseVisualStyleBackColor = true;
            this.yilSaldiri.Click += new System.EventHandler(this.yilSaldiri_Click);
            // 
            // gbGrafik
            // 
            this.gbGrafik.Controls.Add(this.terorOrgut);
            this.gbGrafik.Controls.Add(this.saldiriHedef);
            this.gbGrafik.Controls.Add(this.yilSaldiri);
            this.gbGrafik.Controls.Add(this.saldiriSilahTuru);
            this.gbGrafik.Controls.Add(this.saldiriTuru);
            this.gbGrafik.Controls.Add(this.yilYarali);
            this.gbGrafik.Controls.Add(this.yilOlen);
            this.gbGrafik.Controls.Add(this.bolgeSaldiri);
            this.gbGrafik.Location = new System.Drawing.Point(12, 4);
            this.gbGrafik.Name = "gbGrafik";
            this.gbGrafik.Size = new System.Drawing.Size(579, 77);
            this.gbGrafik.TabIndex = 8;
            this.gbGrafik.TabStop = false;
            this.gbGrafik.Text = "Grafikler";
            // 
            // terorOrgut
            // 
            this.terorOrgut.Location = new System.Drawing.Point(450, 48);
            this.terorOrgut.Name = "terorOrgut";
            this.terorOrgut.Size = new System.Drawing.Size(82, 23);
            this.terorOrgut.TabIndex = 9;
            this.terorOrgut.Text = "Terör Örgütleri";
            this.terorOrgut.UseVisualStyleBackColor = true;
            this.terorOrgut.Click += new System.EventHandler(this.terorOrgut_Click);
            // 
            // saldiriHedef
            // 
            this.saldiriHedef.Location = new System.Drawing.Point(342, 48);
            this.saldiriHedef.Name = "saldiriHedef";
            this.saldiriHedef.Size = new System.Drawing.Size(102, 23);
            this.saldiriHedef.TabIndex = 8;
            this.saldiriHedef.Text = "Saldırılan Hedefler";
            this.saldiriHedef.UseVisualStyleBackColor = true;
            this.saldiriHedef.Click += new System.EventHandler(this.saldiriHedef_Click);
            // 
            // gbTematik
            // 
            this.gbTematik.Controls.Add(this.ilYarali);
            this.gbTematik.Controls.Add(this.ilOlen);
            this.gbTematik.Location = new System.Drawing.Point(639, 4);
            this.gbTematik.Name = "gbTematik";
            this.gbTematik.Size = new System.Drawing.Size(176, 77);
            this.gbTematik.TabIndex = 9;
            this.gbTematik.TabStop = false;
            this.gbTematik.Text = "Tematikler";
            // 
            // ilYarali
            // 
            this.ilYarali.Location = new System.Drawing.Point(6, 48);
            this.ilYarali.Name = "ilYarali";
            this.ilYarali.Size = new System.Drawing.Size(162, 23);
            this.ilYarali.TabIndex = 2;
            this.ilYarali.Text = "İllere Göre Yaralı İnsan Sayısı";
            this.ilYarali.UseVisualStyleBackColor = true;
            this.ilYarali.Click += new System.EventHandler(this.ilYarali_Click);
            // 
            // ilOlen
            // 
            this.ilOlen.Location = new System.Drawing.Point(6, 19);
            this.ilOlen.Name = "ilOlen";
            this.ilOlen.Size = new System.Drawing.Size(162, 23);
            this.ilOlen.TabIndex = 3;
            this.ilOlen.Text = "İllere Göre Ölen İnsan Sayısı";
            this.ilOlen.UseVisualStyleBackColor = true;
            this.ilOlen.Click += new System.EventHandler(this.ilOlen_Click);
            // 
            // turkiye
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 559);
            this.Controls.Add(this.gbTematik);
            this.Controls.Add(this.gbGrafik);
            this.Controls.Add(this.panel1);
            this.Name = "turkiye";
            this.Text = "Türkiye\'de Terör Olayları";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.gbGrafik.ResumeLayout(false);
            this.gbTematik.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button yilOlen;
        private System.Windows.Forms.Button bolgeSaldiri;
        private System.Windows.Forms.Button saldiriSilahTuru;
        private System.Windows.Forms.Button saldiriTuru;
        private System.Windows.Forms.Button yilYarali;
        private System.Windows.Forms.Button yilSaldiri;
        private System.Windows.Forms.GroupBox gbGrafik;
        private System.Windows.Forms.Button terorOrgut;
        private System.Windows.Forms.Button saldiriHedef;
        private System.Windows.Forms.GroupBox gbTematik;
        private System.Windows.Forms.Button ilYarali;
        private System.Windows.Forms.Button ilOlen;
    }
}

