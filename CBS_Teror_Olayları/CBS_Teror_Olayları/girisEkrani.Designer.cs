namespace CBS_Teror_Olayları
{
    partial class girisEkrani
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
            this.dunyaBtn = new System.Windows.Forms.Button();
            this.turkiyeBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dunyaBtn
            // 
            this.dunyaBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dunyaBtn.Location = new System.Drawing.Point(302, 79);
            this.dunyaBtn.Name = "dunyaBtn";
            this.dunyaBtn.Size = new System.Drawing.Size(162, 34);
            this.dunyaBtn.TabIndex = 2;
            this.dunyaBtn.Text = "Dunya\'da Terör";
            this.dunyaBtn.UseVisualStyleBackColor = true;
            this.dunyaBtn.Click += new System.EventHandler(this.dunyaBtn_Click);
            // 
            // turkiyeBtn
            // 
            this.turkiyeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.turkiyeBtn.Location = new System.Drawing.Point(12, 79);
            this.turkiyeBtn.Name = "turkiyeBtn";
            this.turkiyeBtn.Size = new System.Drawing.Size(162, 34);
            this.turkiyeBtn.TabIndex = 3;
            this.turkiyeBtn.Text = "Türkiye\'de Terör";
            this.turkiyeBtn.UseVisualStyleBackColor = true;
            this.turkiyeBtn.Click += new System.EventHandler(this.turkiyeBtn_Click);
            // 
            // girisEkrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 209);
            this.Controls.Add(this.turkiyeBtn);
            this.Controls.Add(this.dunyaBtn);
            this.Name = "girisEkrani";
            this.Text = "Türkiye\'de ve Dünya\'da Terör Olayları";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button dunyaBtn;
        private System.Windows.Forms.Button turkiyeBtn;
    }
}