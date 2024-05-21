namespace Staj_Degerlendirme
{
    partial class frmGirisSecenek
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGirisSecenek));
            this.btnAkademisyenGiris = new System.Windows.Forms.Button();
            this.btnSekreterGiris = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCikis = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAkademisyenGiris
            // 
            this.btnAkademisyenGiris.Location = new System.Drawing.Point(12, 213);
            this.btnAkademisyenGiris.Name = "btnAkademisyenGiris";
            this.btnAkademisyenGiris.Size = new System.Drawing.Size(165, 58);
            this.btnAkademisyenGiris.TabIndex = 0;
            this.btnAkademisyenGiris.Text = "Akadamisyen";
            this.btnAkademisyenGiris.UseVisualStyleBackColor = true;
            this.btnAkademisyenGiris.Click += new System.EventHandler(this.btnAkademisyenGiris_Click);
            // 
            // btnSekreterGiris
            // 
            this.btnSekreterGiris.Location = new System.Drawing.Point(183, 213);
            this.btnSekreterGiris.Name = "btnSekreterGiris";
            this.btnSekreterGiris.Size = new System.Drawing.Size(165, 58);
            this.btnSekreterGiris.TabIndex = 1;
            this.btnSekreterGiris.Text = "Sekreter";
            this.btnSekreterGiris.UseVisualStyleBackColor = true;
            this.btnSekreterGiris.Click += new System.EventHandler(this.btnSekreterGiris_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(436, 167);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnCikis
            // 
            this.btnCikis.Location = new System.Drawing.Point(355, 247);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(93, 24);
            this.btnCikis.TabIndex = 3;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 190);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(326, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "STAJ DEĞERLENDİRME GİRİŞ  SAYFASI";
            // 
            // frmGirisSecenek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 285);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSekreterGiris);
            this.Controls.Add(this.btnAkademisyenGiris);
            this.Name = "frmGirisSecenek";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ana Sayfa";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAkademisyenGiris;
        private System.Windows.Forms.Button btnSekreterGiris;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Label label1;
    }
}

