using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KrediTakip
{
    public partial class Rapor : Form
    {
        public Rapor()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MMHG0TC\SQLEXPRESS;Initial Catalog=Kredi;Integrated Security=True");

        private void Rapor_Load(object sender, EventArgs e)
        {

        }

        private void btn_ihtiyacRapor_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter("select MusteriNo,MusteriHesapNo,SubeKoduNo,KrediTarihi,TCNo,MusteriAd,MusteriSoyad,DogumTarihi,MedeniDurum,EsAd,EsSoyad,TCNoEs,EvTel,CepTel,Adres,CalismaDurumu,Tel_is,Adres_is,KrediTürü,AylikGelirTutari,GecmisKrediKullanimi,DevamEdenKredi,İstenilenKrediTutari,Vade,FaizOrani,AylikTutar,AylikMaliyetOrani,AylikMaliyet,ToplamKrediTutari,KrediDurumu from Musteri_Bilgileri where KrediTürü='İHTİYAÇ KREDİSİ'", con);
            DataTable dt = new DataTable();

            adp.Fill(dt);
            dataGridRapor.DataSource = dt;
            con.Close();

            for (int i = 0; i < (dataGridRapor.Rows.Count - 1); i++)
            {
                DataGridViewCellStyle rowColor = new DataGridViewCellStyle();

                if (dataGridRapor.Rows[i].Cells[29].Value.ToString() == "Onaylanmadı")
                {
                    rowColor.BackColor = Color.Red;
                    dataGridRapor.Rows[i].DefaultCellStyle = rowColor;
                }
            }
        }

        private void btn_TasitRapor_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter("select MusteriNo,MusteriHesapNo,SubeKoduNo,KrediTarihi,TCNo,MusteriAd,MusteriSoyad,DogumTarihi,MedeniDurum,EsAd,EsSoyad,TCNoEs,EvTel,CepTel,Adres,CalismaDurumu,Tel_is,Adres_is,KrediTürü,AylikGelirTutari,GecmisKrediKullanimi,DevamEdenKredi,İstenilenKrediTutari,Vade,FaizOrani,AylikMaliyetOrani,AylikMaliyet,AylikTutar,ToplamKrediTutari,KrediDurumu from Musteri_Bilgileri where KrediTürü='TAŞIT KREDİSİ'", con);

            DataTable dt = new DataTable();

            adp.Fill(dt);
            dataGridRapor.DataSource = dt;
            con.Close();

            for (int i = 0; i < (dataGridRapor.Rows.Count - 1); i++)
            {
                DataGridViewCellStyle rowColor = new DataGridViewCellStyle();

                if (dataGridRapor.Rows[i].Cells[29].Value.ToString() == "Onaylanmadı")
                {
                    rowColor.BackColor = Color.Red;
                    dataGridRapor.Rows[i].DefaultCellStyle = rowColor;
                }
            }
        }

        private void btn_KonutRapor_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter("select MusteriNo,MusteriHesapNo,SubeKoduNo,KrediTarihi,TCNo,MusteriAd,MusteriSoyad,DogumTarihi,MedeniDurum,EsAd,EsSoyad,TCNoEs,EvTel,CepTel,Adres,CalismaDurumu,Tel_is,Adres_is,KrediTürü,AylikGelirTutari,GecmisKrediKullanimi,DevamEdenKredi,İstenilenKrediTutari,Vade,FaizOrani,AylikMaliyetOrani,AylikMaliyet,AylikTutar,ToplamKrediTutari,KrediDurumu from Musteri_Bilgileri where KrediTürü='KONUT KREDİSİ'", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridRapor.DataSource = dt;
            con.Close();

            for (int i = 0; i < (dataGridRapor.Rows.Count - 1); i++)
            {
                DataGridViewCellStyle rowColor = new DataGridViewCellStyle();

                if (dataGridRapor.Rows[i].Cells[29].Value.ToString() == "Onaylanmadı")
                {
                    rowColor.BackColor = Color.Red;
                    dataGridRapor.Rows[i].DefaultCellStyle = rowColor;
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application uyg = new Microsoft.Office.Interop.Excel.Application();
            uyg.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook kitap = uyg.Workbooks.Add(System.Reflection.Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)kitap.Sheets[1];
            for (int i = 0; i < dataGridRapor.Columns.Count; i++)
            {
                Microsoft.Office.Interop.Excel.Range myrange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[1, i + 1];
                myrange.Value2 = dataGridRapor.Columns[i].HeaderText;
            }
            for (int i = 0; i < dataGridRapor.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridRapor.Rows.Count; j++)
                {
                    Microsoft.Office.Interop.Excel.Range my = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                    my.Value2 = dataGridRapor[i, j].Value;
                }
            }
        }

        private void buttonMenu_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Menu menu = new Menu();
            menu.Show();
        }



    }
}
