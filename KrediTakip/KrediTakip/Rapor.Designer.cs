namespace KrediTakip
{
    partial class Rapor
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
            this.groupBoxRapor = new System.Windows.Forms.GroupBox();
            this.btn_ihtiyacRapor = new System.Windows.Forms.Button();
            this.btn_TasitRapor = new System.Windows.Forms.Button();
            this.btn_KonutRapor = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.dataGridRapor = new System.Windows.Forms.DataGridView();
            this.buttonMenu = new System.Windows.Forms.Button();
            this.groupBoxRapor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRapor)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxRapor
            // 
            this.groupBoxRapor.Controls.Add(this.buttonMenu);
            this.groupBoxRapor.Controls.Add(this.btnExcel);
            this.groupBoxRapor.Controls.Add(this.btn_KonutRapor);
            this.groupBoxRapor.Controls.Add(this.btn_TasitRapor);
            this.groupBoxRapor.Controls.Add(this.btn_ihtiyacRapor);
            this.groupBoxRapor.Location = new System.Drawing.Point(13, 35);
            this.groupBoxRapor.Name = "groupBoxRapor";
            this.groupBoxRapor.Size = new System.Drawing.Size(720, 110);
            this.groupBoxRapor.TabIndex = 0;
            this.groupBoxRapor.TabStop = false;
            this.groupBoxRapor.Text = "İŞLEMLER";
            // 
            // btn_ihtiyacRapor
            // 
            this.btn_ihtiyacRapor.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_ihtiyacRapor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_ihtiyacRapor.Location = new System.Drawing.Point(25, 19);
            this.btn_ihtiyacRapor.Name = "btn_ihtiyacRapor";
            this.btn_ihtiyacRapor.Size = new System.Drawing.Size(111, 72);
            this.btn_ihtiyacRapor.TabIndex = 3;
            this.btn_ihtiyacRapor.Text = "İhtiyaç Kredi Listesi";
            this.btn_ihtiyacRapor.UseVisualStyleBackColor = false;
            this.btn_ihtiyacRapor.Click += new System.EventHandler(this.btn_ihtiyacRapor_Click);
            // 
            // btn_TasitRapor
            // 
            this.btn_TasitRapor.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_TasitRapor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_TasitRapor.Location = new System.Drawing.Point(168, 19);
            this.btn_TasitRapor.Name = "btn_TasitRapor";
            this.btn_TasitRapor.Size = new System.Drawing.Size(111, 72);
            this.btn_TasitRapor.TabIndex = 5;
            this.btn_TasitRapor.Text = "Taşıt Kredi Listesi";
            this.btn_TasitRapor.UseVisualStyleBackColor = false;
            this.btn_TasitRapor.Click += new System.EventHandler(this.btn_TasitRapor_Click);
            // 
            // btn_KonutRapor
            // 
            this.btn_KonutRapor.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btn_KonutRapor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_KonutRapor.Location = new System.Drawing.Point(314, 19);
            this.btn_KonutRapor.Name = "btn_KonutRapor";
            this.btn_KonutRapor.Size = new System.Drawing.Size(111, 72);
            this.btn_KonutRapor.TabIndex = 6;
            this.btn_KonutRapor.Text = "Konut Kredi Listesi";
            this.btn_KonutRapor.UseVisualStyleBackColor = false;
            this.btn_KonutRapor.Click += new System.EventHandler(this.btn_KonutRapor_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnExcel.Location = new System.Drawing.Point(462, 19);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(111, 72);
            this.btnExcel.TabIndex = 7;
            this.btnExcel.Text = "EXCEL GÖNDER";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // dataGridRapor
            // 
            this.dataGridRapor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridRapor.Location = new System.Drawing.Point(13, 161);
            this.dataGridRapor.Name = "dataGridRapor";
            this.dataGridRapor.Size = new System.Drawing.Size(720, 212);
            this.dataGridRapor.TabIndex = 1;
            // 
            // buttonMenu
            // 
            this.buttonMenu.BackColor = System.Drawing.Color.LightSteelBlue;
            this.buttonMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonMenu.Location = new System.Drawing.Point(593, 19);
            this.buttonMenu.Name = "buttonMenu";
            this.buttonMenu.Size = new System.Drawing.Size(111, 72);
            this.buttonMenu.TabIndex = 8;
            this.buttonMenu.Text = "MENÜ";
            this.buttonMenu.UseVisualStyleBackColor = false;
            this.buttonMenu.Click += new System.EventHandler(this.buttonMenu_Click);
            // 
            // Rapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSlateGray;
            this.ClientSize = new System.Drawing.Size(745, 382);
            this.Controls.Add(this.dataGridRapor);
            this.Controls.Add(this.groupBoxRapor);
            this.Name = "Rapor";
            this.Text = "Rapor";
            this.Load += new System.EventHandler(this.Rapor_Load);
            this.groupBoxRapor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridRapor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxRapor;
        private System.Windows.Forms.Button btn_ihtiyacRapor;
        private System.Windows.Forms.Button btn_TasitRapor;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btn_KonutRapor;
        private System.Windows.Forms.DataGridView dataGridRapor;
        private System.Windows.Forms.Button buttonMenu;
    }
}