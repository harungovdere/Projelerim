namespace KrediTakip
{
    partial class OdemePlani
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMusteriNo = new System.Windows.Forms.TextBox();
            this.buttonOdmPlan = new System.Windows.Forms.Button();
            this.buttonKapat = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonTemiz = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Müşteri No Giriniz :";
            // 
            // textBoxMusteriNo
            // 
            this.textBoxMusteriNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxMusteriNo.Location = new System.Drawing.Point(114, 10);
            this.textBoxMusteriNo.Name = "textBoxMusteriNo";
            this.textBoxMusteriNo.Size = new System.Drawing.Size(100, 20);
            this.textBoxMusteriNo.TabIndex = 2;
            this.textBoxMusteriNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMusteriNo_KeyPress);
            // 
            // buttonOdmPlan
            // 
            this.buttonOdmPlan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOdmPlan.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonOdmPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonOdmPlan.Location = new System.Drawing.Point(235, 10);
            this.buttonOdmPlan.Name = "buttonOdmPlan";
            this.buttonOdmPlan.Size = new System.Drawing.Size(97, 23);
            this.buttonOdmPlan.TabIndex = 3;
            this.buttonOdmPlan.Text = "Ödeme Planı";
            this.buttonOdmPlan.UseVisualStyleBackColor = false;
            this.buttonOdmPlan.Click += new System.EventHandler(this.buttonOdmPlan_Click);
            // 
            // buttonKapat
            // 
            this.buttonKapat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonKapat.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonKapat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonKapat.Location = new System.Drawing.Point(730, 4);
            this.buttonKapat.Name = "buttonKapat";
            this.buttonKapat.Size = new System.Drawing.Size(85, 72);
            this.buttonKapat.TabIndex = 8;
            this.buttonKapat.Text = "MENÜ";
            this.buttonKapat.UseVisualStyleBackColor = false;
            this.buttonKapat.Click += new System.EventHandler(this.buttonKapat_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(3, 80);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(820, 301);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Müşteri No";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ad";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Soyad";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Vade";
            this.columnHeader4.Width = 46;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Aylık Ödenek Tutar";
            this.columnHeader5.Width = 113;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Faiz Oranı";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Aylik Maliyet Oranı";
            this.columnHeader7.Width = 102;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Aylık Maliyet";
            this.columnHeader8.Width = 80;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Kalan Tutar";
            this.columnHeader9.Width = 80;
            // 
            // buttonTemiz
            // 
            this.buttonTemiz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonTemiz.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonTemiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonTemiz.Location = new System.Drawing.Point(587, 4);
            this.buttonTemiz.Name = "buttonTemiz";
            this.buttonTemiz.Size = new System.Drawing.Size(85, 72);
            this.buttonTemiz.TabIndex = 10;
            this.buttonTemiz.Text = "LİSTEYİ TEMİZLE";
            this.buttonTemiz.UseVisualStyleBackColor = false;
            this.buttonTemiz.Click += new System.EventHandler(this.buttonTemiz_Click);
            // 
            // OdemePlani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(827, 383);
            this.Controls.Add(this.buttonTemiz);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.buttonKapat);
            this.Controls.Add(this.buttonOdmPlan);
            this.Controls.Add(this.textBoxMusteriNo);
            this.Controls.Add(this.label1);
            this.Name = "OdemePlani";
            this.Text = "OdemePlani";
            this.Load += new System.EventHandler(this.OdemePlani_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMusteriNo;
        private System.Windows.Forms.Button buttonOdmPlan;
        private System.Windows.Forms.Button buttonKapat;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Button buttonTemiz;
    }
}