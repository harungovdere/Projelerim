namespace KrediTakip
{
    partial class Evrak_Ekleme
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnResmGetir = new System.Windows.Forms.Button();
            this.btnResimKaydet = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnResim = new System.Windows.Forms.Button();
            this.textMusteriNo = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnMenu = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.labelDosya = new System.Windows.Forms.Label();
            this.btnDosyaGetir = new System.Windows.Forms.Button();
            this.btnDosyaKaydet = new System.Windows.Forms.Button();
            this.btnDosyaSec = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textMusteri_Soyad = new System.Windows.Forms.TextBox();
            this.labelMusteriSoyad = new System.Windows.Forms.Label();
            this.labelMusteriAd = new System.Windows.Forms.Label();
            this.textMusteri_Ad = new System.Windows.Forms.TextBox();
            this.labelMusteri_No = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnYenile = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnResmGetir);
            this.groupBox1.Controls.Add(this.btnResimKaydet);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.btnResim);
            this.groupBox1.Location = new System.Drawing.Point(12, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(429, 184);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resim Ekleme İşlemi";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(311, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 70);
            this.button1.TabIndex = 7;
            this.button1.Text = "RESMİ SİL";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnResmGetir
            // 
            this.btnResmGetir.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnResmGetir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnResmGetir.Location = new System.Drawing.Point(311, 19);
            this.btnResmGetir.Name = "btnResmGetir";
            this.btnResmGetir.Size = new System.Drawing.Size(90, 70);
            this.btnResmGetir.TabIndex = 6;
            this.btnResmGetir.Text = "RESMİ GETİR";
            this.btnResmGetir.UseVisualStyleBackColor = false;
            this.btnResmGetir.Click += new System.EventHandler(this.btnResmGetir_Click);
            // 
            // btnResimKaydet
            // 
            this.btnResimKaydet.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnResimKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnResimKaydet.Location = new System.Drawing.Point(176, 106);
            this.btnResimKaydet.Name = "btnResimKaydet";
            this.btnResimKaydet.Size = new System.Drawing.Size(90, 70);
            this.btnResimKaydet.TabIndex = 5;
            this.btnResimKaydet.Text = "RESİM KAYDET";
            this.btnResimKaydet.UseVisualStyleBackColor = false;
            this.btnResimKaydet.Click += new System.EventHandler(this.btnResimKaydet_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightSlateGray;
            this.pictureBox1.Location = new System.Drawing.Point(6, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 152);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnResim
            // 
            this.btnResim.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnResim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnResim.Location = new System.Drawing.Point(176, 19);
            this.btnResim.Name = "btnResim";
            this.btnResim.Size = new System.Drawing.Size(90, 70);
            this.btnResim.TabIndex = 0;
            this.btnResim.Text = "RESİM SEÇ";
            this.btnResim.UseVisualStyleBackColor = false;
            this.btnResim.Click += new System.EventHandler(this.btnResim_Click);
            // 
            // textMusteriNo
            // 
            this.textMusteriNo.Location = new System.Drawing.Point(87, 25);
            this.textMusteriNo.Name = "textMusteriNo";
            this.textMusteriNo.Size = new System.Drawing.Size(114, 20);
            this.textMusteriNo.TabIndex = 3;
            this.textMusteriNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textMusteriNo_KeyPress);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMenu.Location = new System.Drawing.Point(277, 23);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(98, 66);
            this.btnMenu.TabIndex = 1;
            this.btnMenu.Text = "MENÜ";
            this.btnMenu.UseVisualStyleBackColor = false;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnYenile);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.btnMenu);
            this.groupBox2.Controls.Add(this.labelDosya);
            this.groupBox2.Controls.Add(this.btnDosyaGetir);
            this.groupBox2.Controls.Add(this.btnDosyaKaydet);
            this.groupBox2.Controls.Add(this.btnDosyaSec);
            this.groupBox2.Location = new System.Drawing.Point(447, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(386, 184);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dosya Ekleme İşlemi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Dosya Adresi :";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.Location = new System.Drawing.Point(149, 108);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 70);
            this.button2.TabIndex = 8;
            this.button2.Text = "DOSYA SİL";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // labelDosya
            // 
            this.labelDosya.AutoSize = true;
            this.labelDosya.Location = new System.Drawing.Point(93, 92);
            this.labelDosya.Name = "labelDosya";
            this.labelDosya.Size = new System.Drawing.Size(35, 13);
            this.labelDosya.TabIndex = 7;
            this.labelDosya.Text = "label3";
            // 
            // btnDosyaGetir
            // 
            this.btnDosyaGetir.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnDosyaGetir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDosyaGetir.Location = new System.Drawing.Point(149, 19);
            this.btnDosyaGetir.Name = "btnDosyaGetir";
            this.btnDosyaGetir.Size = new System.Drawing.Size(90, 70);
            this.btnDosyaGetir.TabIndex = 6;
            this.btnDosyaGetir.Text = "DOSYA GETİR";
            this.btnDosyaGetir.UseVisualStyleBackColor = false;
            // 
            // btnDosyaKaydet
            // 
            this.btnDosyaKaydet.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnDosyaKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDosyaKaydet.Location = new System.Drawing.Point(20, 108);
            this.btnDosyaKaydet.Name = "btnDosyaKaydet";
            this.btnDosyaKaydet.Size = new System.Drawing.Size(90, 70);
            this.btnDosyaKaydet.TabIndex = 5;
            this.btnDosyaKaydet.Text = "DOSYA KAYDET";
            this.btnDosyaKaydet.UseVisualStyleBackColor = false;
            this.btnDosyaKaydet.Click += new System.EventHandler(this.btnDosyaKaydet_Click);
            // 
            // btnDosyaSec
            // 
            this.btnDosyaSec.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnDosyaSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDosyaSec.Location = new System.Drawing.Point(20, 19);
            this.btnDosyaSec.Name = "btnDosyaSec";
            this.btnDosyaSec.Size = new System.Drawing.Size(90, 70);
            this.btnDosyaSec.TabIndex = 0;
            this.btnDosyaSec.Text = "DOSYA SEÇ";
            this.btnDosyaSec.UseVisualStyleBackColor = false;
            this.btnDosyaSec.Click += new System.EventHandler(this.btnDosyaSec_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textMusteri_Soyad);
            this.groupBox3.Controls.Add(this.labelMusteriSoyad);
            this.groupBox3.Controls.Add(this.labelMusteriAd);
            this.groupBox3.Controls.Add(this.textMusteri_Ad);
            this.groupBox3.Controls.Add(this.labelMusteri_No);
            this.groupBox3.Controls.Add(this.textMusteriNo);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(602, 59);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Seçilen Müşteri Bilgileri";
            // 
            // textMusteri_Soyad
            // 
            this.textMusteri_Soyad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textMusteri_Soyad.Location = new System.Drawing.Point(436, 25);
            this.textMusteri_Soyad.Name = "textMusteri_Soyad";
            this.textMusteri_Soyad.Size = new System.Drawing.Size(100, 20);
            this.textMusteri_Soyad.TabIndex = 10;
            // 
            // labelMusteriSoyad
            // 
            this.labelMusteriSoyad.AutoSize = true;
            this.labelMusteriSoyad.Location = new System.Drawing.Point(386, 28);
            this.labelMusteriSoyad.Name = "labelMusteriSoyad";
            this.labelMusteriSoyad.Size = new System.Drawing.Size(43, 13);
            this.labelMusteriSoyad.TabIndex = 9;
            this.labelMusteriSoyad.Text = "Soyad :";
            // 
            // labelMusteriAd
            // 
            this.labelMusteriAd.AutoSize = true;
            this.labelMusteriAd.Location = new System.Drawing.Point(223, 28);
            this.labelMusteriAd.Name = "labelMusteriAd";
            this.labelMusteriAd.Size = new System.Drawing.Size(26, 13);
            this.labelMusteriAd.TabIndex = 8;
            this.labelMusteriAd.Text = "Ad :";
            // 
            // textMusteri_Ad
            // 
            this.textMusteri_Ad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textMusteri_Ad.Location = new System.Drawing.Point(255, 25);
            this.textMusteri_Ad.Name = "textMusteri_Ad";
            this.textMusteri_Ad.Size = new System.Drawing.Size(100, 20);
            this.textMusteri_Ad.TabIndex = 7;
            // 
            // labelMusteri_No
            // 
            this.labelMusteri_No.AutoSize = true;
            this.labelMusteri_No.Location = new System.Drawing.Point(17, 28);
            this.labelMusteri_No.Name = "labelMusteri_No";
            this.labelMusteri_No.Size = new System.Drawing.Size(64, 13);
            this.labelMusteri_No.TabIndex = 5;
            this.labelMusteri_No.Text = "Müşteri No :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 277);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(821, 150);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnYenile
            // 
            this.btnYenile.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnYenile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYenile.Location = new System.Drawing.Point(277, 112);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(98, 66);
            this.btnYenile.TabIndex = 10;
            this.btnYenile.Text = "YENİLE";
            this.btnYenile.UseVisualStyleBackColor = false;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // Evrak_Ekleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(842, 433);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Evrak_Ekleme";
            this.Text = "Evrak_Ekleme";
            this.Load += new System.EventHandler(this.Evrak_Ekleme_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnResimKaydet;
        private System.Windows.Forms.TextBox textMusteriNo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnResim;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnResmGetir;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDosyaGetir;
        private System.Windows.Forms.Button btnDosyaKaydet;
        private System.Windows.Forms.Button btnDosyaSec;
        private System.Windows.Forms.Label labelDosya;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textMusteri_Soyad;
        private System.Windows.Forms.Label labelMusteriSoyad;
        private System.Windows.Forms.Label labelMusteriAd;
        private System.Windows.Forms.TextBox textMusteri_Ad;
        private System.Windows.Forms.Label labelMusteri_No;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnYenile;
    }
}