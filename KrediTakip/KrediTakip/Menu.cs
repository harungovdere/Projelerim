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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MMHG0TC\SQLEXPRESS;Initial Catalog=Kredi;Integrated Security=True");
        string yazi = "HERKESİN DEĞİL SİZİN BANKANIZ...  HERKESİN DEĞİL SİZİN BANKANIZ...  HERKESİN DEĞİL SİZİN BANKANIZ...  ";
        private void btnEkleme_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Kredi_Ekleme ekle = new Kredi_Ekleme();
            ekle.Show();
            
        }

        private void buttonKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_ihtiyac_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter("select MusteriNo,MusteriHesapNo,SubeKoduNo,KrediTarihi,TCNo,MusteriAd,MusteriSoyad,DogumTarihi,MedeniDurum,EsAd,EsSoyad,TCNoEs,EvTel,CepTel,Adres,CalismaDurumu,Tel_is,Adres_is,KrediTürü,AylikGelirTutari,GecmisKrediKullanimi,DevamEdenKredi,İstenilenKrediTutari,Vade,FaizOrani,AylikTutar,AylikMaliyetOrani,AylikMaliyet,ToplamKrediTutari,KrediDurumu from Musteri_Bilgileri where KrediTürü='İHTİYAÇ KREDİSİ' order by KrediTarihi desc", con);
            DataTable dt = new DataTable();

            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            for (int i = 0; i < (dataGridView1.Rows.Count - 1); i++)
            {
                DataGridViewCellStyle rowColor = new DataGridViewCellStyle();


                if (dataGridView1.Rows[i].Cells[29].Value.ToString() == "Onaylanmadı")
                {
                    rowColor.BackColor = Color.Red;
                    dataGridView1.Rows[i].DefaultCellStyle = rowColor;
                }
            }
        }

        private void btn_Konut_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter("select MusteriNo,MusteriHesapNo,SubeKoduNo,KrediTarihi,TCNo,MusteriAd,MusteriSoyad,DogumTarihi,MedeniDurum,EsAd,EsSoyad,TCNoEs,EvTel,CepTel,Adres,CalismaDurumu,Tel_is,Adres_is,KrediTürü,AylikGelirTutari,GecmisKrediKullanimi,DevamEdenKredi,İstenilenKrediTutari,Vade,FaizOrani,AylikMaliyetOrani,AylikMaliyet,AylikTutar,ToplamKrediTutari,KrediDurumu from Musteri_Bilgileri where KrediTürü='KONUT KREDİSİ' order by KrediTarihi desc", con);
            DataTable dt = new DataTable();

            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            for (int i = 0; i < (dataGridView1.Rows.Count - 1); i++)
            {
                DataGridViewCellStyle rowColor = new DataGridViewCellStyle();


                if (dataGridView1.Rows[i].Cells[29].Value.ToString() == "Onaylanmadı")
                {
                    rowColor.BackColor = Color.Red;
                    dataGridView1.Rows[i].DefaultCellStyle = rowColor;
                }
            }
        }

        private void btn_Tasıt_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter("select MusteriNo,MusteriHesapNo,SubeKoduNo,KrediTarihi,TCNo,MusteriAd,MusteriSoyad,DogumTarihi,MedeniDurum,EsAd,EsSoyad,TCNoEs,EvTel,CepTel,Adres,CalismaDurumu,Tel_is,Adres_is,KrediTürü,AylikGelirTutari,GecmisKrediKullanimi,DevamEdenKredi,İstenilenKrediTutari,Vade,FaizOrani,AylikMaliyetOrani,AylikMaliyet,AylikTutar,ToplamKrediTutari,KrediDurumu from Musteri_Bilgileri where KrediTürü='TAŞIT KREDİSİ' order by KrediTarihi desc", con);
            DataTable dt = new DataTable();

            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            for (int i = 0; i < (dataGridView1.Rows.Count - 1); i++)
            {
                DataGridViewCellStyle rowColor = new DataGridViewCellStyle();


                if (dataGridView1.Rows[i].Cells[29].Value.ToString() == "Onaylanmadı")
                {
                    rowColor.BackColor = Color.Red;
                    dataGridView1.Rows[i].DefaultCellStyle = rowColor;
                }
            }
        }

         private void Menu_Load_1(object sender, EventArgs e)
         {
             timer1.Start();
             label6.Text = yazi;
             dateTimePicker1.Enabled = false;
             dateTimePicker2.Enabled = false;
             textAraAd.Enabled = false;
             textAraSoyad.Enabled = false;
             textAraMustri.Enabled = false;
             pictureBox1.Image = Resource1.kıl2;
             dateTimePicker1.Format = DateTimePickerFormat.Custom;
             dateTimePicker1.CustomFormat = "dd MM yyyy";
             dateTimePicker2.Format = DateTimePickerFormat.Custom;
             dateTimePicker2.CustomFormat = "dd MM yyyy";
             labelTarih.Text = DateTime.Now.ToLongDateString();
         }

         private void buttonAra_Click(object sender, EventArgs e)
         {

            radioOnaylanan.Checked = false;
            radioOnaylanmayan.Checked = false;

            if (comboAra.Text=="")
             {
                 MessageBox.Show("Arama Seçiniz...");
             }
             else if(comboAra.Text=="Tarihe Göre")
             {

                 if (dateTimePicker1.Value.ToLongDateString() == DateTime.Now.ToLongDateString() && dateTimePicker2.Value.ToLongDateString() == DateTime.Now.ToLongDateString())
                 {
                     con.Open();
                     SqlCommand cmdd = new SqlCommand("select MusteriNo,MusteriHesapNo,SubeKoduNo,KrediTarihi,TCNo,MusteriAd,MusteriSoyad,DogumTarihi,MedeniDurum,EsAd,EsSoyad,TCNoEs,EvTel,CepTel,Adres,CalismaDurumu,Tel_is,Adres_is,KrediTürü,AylikGelirTutari,GecmisKrediKullanimi,DevamEdenKredi,İstenilenKrediTutari,Vade,FaizOrani,AylikMaliyetOrani,AylikMaliyet,AylikTutar,ToplamKrediTutari,KrediDurumu from Musteri_Bilgileri where KrediTarihi=@Tarih1 order by KrediTarihi asc", con);
                     
                     cmdd.Parameters.AddWithValue("@Tarih1", SqlDbType.DateTime).Value=DateTime.Now.ToString("yyyyMMdd");
                     SqlDataReader veri = cmdd.ExecuteReader();
                     DataTable dtt = new DataTable();
                     dtt.Load(veri);
                     dataGridView1.DataSource = dtt;
                     con.Close();

                     for (int i = 0; i < (dataGridView1.Rows.Count - 1); i++)
                     {
                         DataGridViewCellStyle rowColor = new DataGridViewCellStyle();


                         if (dataGridView1.Rows[i].Cells[29].Value.ToString() == "Onaylanmadı")
                         {
                             rowColor.BackColor = Color.Red;
                             dataGridView1.Rows[i].DefaultCellStyle = rowColor;
                         }
                     }
                     textAraAd.Text = null;
                     textAraSoyad.Text = null;
                     textAraMustri.Text = null;
                     dateTimePicker1.ResetText();
                     dateTimePicker2.ResetText();
                 }
                 else
                 {
                     con.Open();

                     SqlCommand cmd = new SqlCommand("select MusteriNo,MusteriHesapNo,SubeKoduNo,KrediTarihi,TCNo,MusteriAd,MusteriSoyad,DogumTarihi,MedeniDurum,EsAd,EsSoyad,TCNoEs,EvTel,CepTel,Adres,CalismaDurumu,Tel_is,Adres_is,KrediTürü,AylikGelirTutari,GecmisKrediKullanimi,DevamEdenKredi,İstenilenKrediTutari,Vade,FaizOrani,AylikMaliyetOrani,AylikMaliyet,AylikTutar,ToplamKrediTutari,KrediDurumu from Musteri_Bilgileri where KrediTarihi between @Tarih1 AND @Tarih2 order by KrediTarihi desc", con);
                     cmd.Parameters.AddWithValue("@Tarih1", SqlDbType.DateTime).Value = dateTimePicker1.Value;
                     cmd.Parameters.AddWithValue("@Tarih2", SqlDbType.DateTime).Value = dateTimePicker2.Value;
                     SqlDataReader veriyukle = cmd.ExecuteReader();

                     DataTable dt = new DataTable();
                     dt.Load(veriyukle);
                     dataGridView1.DataSource = dt;
                     con.Close();

                     for (int i = 0; i < (dataGridView1.Rows.Count - 1); i++)
                     {
                         DataGridViewCellStyle rowColor = new DataGridViewCellStyle();


                         if (dataGridView1.Rows[i].Cells[29].Value.ToString() == "Onaylanmadı")
                         {
                             rowColor.BackColor = Color.Red;
                             dataGridView1.Rows[i].DefaultCellStyle = rowColor;
                         }
                      
                     }
                     textAraAd.Text = null;
                     textAraSoyad.Text = null;
                     textAraMustri.Text = null;
                     dateTimePicker1.ResetText();
                     dateTimePicker2.ResetText();
                 }
                 
             }
             else if(comboAra.Text=="Müşteri Numarasına Göre")
             {
                 if (textAraMustri.Text=="")
                 {
                     MessageBox.Show("Müşteri Numarasını Giriniz...");
                 }
                 else
                 {
                     con.Open();
                     SqlCommand cmd = new SqlCommand();
                     cmd.CommandText = "select MusteriNo,MusteriHesapNo,SubeKoduNo,KrediTarihi,TCNo,MusteriAd,MusteriSoyad,DogumTarihi,MedeniDurum,EsAd,EsSoyad,TCNoEs,EvTel,CepTel,Adres,CalismaDurumu,Tel_is,Adres_is,KrediTürü,AylikGelirTutari,GecmisKrediKullanimi,DevamEdenKredi,İstenilenKrediTutari,Vade,FaizOrani,AylikMaliyetOrani,AylikMaliyet,AylikTutar,ToplamKrediTutari,KrediDurumu from Musteri_Bilgileri where MusteriNo=" + textAraMustri.Text;
                     cmd.Connection = con;
                     SqlDataReader veriyukle = cmd.ExecuteReader();
                     DataTable dt = new DataTable();

                     dt.Load(veriyukle);
                     dataGridView1.DataSource = dt;

                     con.Close();

                     for (int i = 0; i < (dataGridView1.Rows.Count - 1); i++)
                     {
                         DataGridViewCellStyle rowColor = new DataGridViewCellStyle();


                         if (dataGridView1.Rows[i].Cells[29].Value.ToString() == "Onaylanmadı")
                         {
                             rowColor.BackColor = Color.Red;
                             dataGridView1.Rows[i].DefaultCellStyle = rowColor;
                         }
                     }
                     textAraAd.Text = null;
                     textAraSoyad.Text = null;
                     textAraMustri.Text = null;
                     dateTimePicker1.ResetText();
                     dateTimePicker2.ResetText();
                 }
             }
             else if (comboAra.Text == "Müşteri Adına Göre")
             {
                 if (textAraAd.Text==""&&textAraSoyad.Text=="")
                 {
                     MessageBox.Show("Müşteri Adını veya Soyadını Giriniz...");
                 }
                 else
                 {
                     con.Open();
                     SqlCommand cmd = new SqlCommand();
                     cmd.CommandText = "SELECT MusteriNo,MusteriHesapNo,SubeKoduNo,KrediTarihi,TCNo,MusteriAd,MusteriSoyad,DogumTarihi,MedeniDurum,EsAd,EsSoyad,TCNoEs,EvTel,CepTel,Adres,CalismaDurumu,Tel_is,Adres_is,KrediTürü,AylikGelirTutari,GecmisKrediKullanimi,DevamEdenKredi,İstenilenKrediTutari,Vade,FaizOrani,AylikMaliyetOrani,AylikMaliyet,AylikTutar,ToplamKrediTutari,KrediDurumu FROM Musteri_Bilgileri where MusteriAd like '%" + textAraAd.Text + "%' and MusteriSoyad like '%" + textAraSoyad.Text + "%'";
                     cmd.Connection = con;
                     SqlDataReader veriyukle = cmd.ExecuteReader();
                     DataTable dt = new DataTable();

                     dt.Load(veriyukle);
                     dataGridView1.DataSource = dt;

                     con.Close();

                     for (int i = 0; i < (dataGridView1.Rows.Count - 1); i++)
                     {
                         DataGridViewCellStyle rowColor = new DataGridViewCellStyle();


                         if (dataGridView1.Rows[i].Cells[29].Value.ToString() == "Onaylanmadı")
                         {
                             rowColor.BackColor = Color.Red;
                             dataGridView1.Rows[i].DefaultCellStyle = rowColor;
                         }
                     }
                     textAraAd.Text = null;
                     textAraSoyad.Text = null;
                     textAraMustri.Text = null;
                     dateTimePicker1.ResetText();
                     dateTimePicker2.ResetText();
                 }
             }
         }

         private void comboAra_SelectedIndexChanged(object sender, EventArgs e)
         {
             if(comboAra.Text=="")
             {
                 dateTimePicker1.Enabled = false;
                 dateTimePicker2.Enabled = false;
                 textAraAd.Enabled = false;
                 textAraSoyad.Enabled = false;
                 textAraMustri.Enabled = false;
             }
             else if(comboAra.Text=="Tarihe Göre")
             {
                 dateTimePicker1.Enabled = true;
                 dateTimePicker2.Enabled = true;
                 textAraAd.Enabled = false;
                 textAraSoyad.Enabled = false;
                 textAraMustri.Enabled = false;
             }
             else if (comboAra.Text == "Müşteri Numarasına Göre")
             {
                 dateTimePicker1.Enabled = false;
                 dateTimePicker2.Enabled = false;
                 textAraAd.Enabled = false;
                 textAraSoyad.Enabled = false;
                 textAraMustri.Enabled = true; ;
             }
             else if (comboAra.Text == "Müşteri Adına Göre")
             {
                 dateTimePicker1.Enabled = false;
                 dateTimePicker2.Enabled = false;
                 textAraAd.Enabled = true ;
                 textAraSoyad.Enabled = true;
                 textAraMustri.Enabled = false;
             }
         }

         private void buttonTemizle_Click(object sender, EventArgs e)
         {
            radioOnaylanan.Checked = false;
            radioOnaylanmayan.Checked = false;
            dataGridView1.DataSource = null;
             comboAra.Text = null;

         }

         private void timer1_Tick(object sender, EventArgs e)
         {
             string ilkharf = yazi.Substring(0, 1);
             yazi = yazi.Remove(0, 1);
             yazi += ilkharf;
             label6.Text = yazi;
             labelSaat.Text = DateTime.Now.ToLongTimeString();
             labelTarih.Text = DateTime.Now.ToLongDateString();
         }

         private void btn_izleme_Click(object sender, EventArgs e)
         {
             OdemePlani odeme = new OdemePlani();
             odeme.Show();
             this.Visible = false;
         }

         private void textAraMustri_KeyPress(object sender, KeyPressEventArgs e)
         {
             if (char.IsDigit(e.KeyChar))
             {
                 e.Handled = false;
             }
             else
             {
                 e.Handled = true;
             }                       
             if (textAraMustri.TextLength == 6)
             {
                 e.Handled = true;
             }
             if (char.IsControl(e.KeyChar))
             {
                 e.Handled = false;
             }
            
         }

         private void textAraAd_KeyPress(object sender, KeyPressEventArgs e)
         {
             if (char.IsLetter(e.KeyChar))
             {
                 e.Handled = false;
             }
             else
             {
                 e.Handled = true;
             }
             if (textAraAd.TextLength == 20)
             {
                 e.Handled = true;
             }
             if (char.IsControl(e.KeyChar))
             {
                 e.Handled = false;
             }
         }

         private void textAraSoyad_KeyPress(object sender, KeyPressEventArgs e)
         {
             if (char.IsLetter(e.KeyChar))
             {
                 e.Handled = false;
             }
             else
             {
                 e.Handled = true;
             }
             if (textAraAd.TextLength == 20)
             {
                 e.Handled = true;
             }
             if (char.IsControl(e.KeyChar))
             {
                 e.Handled = false;
             }
         }

         private void button1_Click(object sender, EventArgs e)
         {
             this.Visible = false;
             Evrak_Ekleme ekle = new Evrak_Ekleme();
             ekle.Show();
         }

         private void krediEklemeToolStripMenuItem_Click(object sender, EventArgs e)
         {
             this.Visible = false;
             Kredi_Ekleme ekle = new Kredi_Ekleme();
             ekle.Show();
         }

         private void ödemePlanıToolStripMenuItem_Click(object sender, EventArgs e)
         {
             OdemePlani odeme = new OdemePlani();
             odeme.Show();
             this.Visible = false;
         }

         private void ihtiyaçKredisiToolStripMenuItem_Click(object sender, EventArgs e)
         {
             con.Open();
             SqlDataAdapter adp = new SqlDataAdapter("select MusteriNo,MusteriHesapNo,SubeKoduNo,KrediTarihi,TCNo,MusteriAd,MusteriSoyad,DogumTarihi,MedeniDurum,EsAd,EsSoyad,TCNoEs,EvTel,CepTel,Adres,CalismaDurumu,Tel_is,Adres_is,KrediTürü,AylikGelirTutari,GecmisKrediKullanimi,DevamEdenKredi,İstenilenKrediTutari,Vade,FaizOrani,AylikTutar,AylikMaliyetOrani,AylikMaliyet,ToplamKrediTutari,KrediDurumu from Musteri_Bilgileri where KrediTürü='İHTİYAÇ KREDİSİ' order by KrediTarihi desc", con);
             DataTable dt = new DataTable();

             adp.Fill(dt);
             dataGridView1.DataSource = dt;
             con.Close();

             for (int i = 0; i < (dataGridView1.Rows.Count - 1); i++)
             {
                 DataGridViewCellStyle rowColor = new DataGridViewCellStyle();


                 if (dataGridView1.Rows[i].Cells[29].Value.ToString() == "Onaylanmadı")
                 {
                     rowColor.BackColor = Color.Red;
                     dataGridView1.Rows[i].DefaultCellStyle = rowColor;
                 }
             }
         }

         private void konutKredisiToolStripMenuItem_Click(object sender, EventArgs e)
         {
             con.Open();
             SqlDataAdapter adp = new SqlDataAdapter("select MusteriNo,MusteriHesapNo,SubeKoduNo,KrediTarihi,TCNo,MusteriAd,MusteriSoyad,DogumTarihi,MedeniDurum,EsAd,EsSoyad,TCNoEs,EvTel,CepTel,Adres,CalismaDurumu,Tel_is,Adres_is,KrediTürü,AylikGelirTutari,GecmisKrediKullanimi,DevamEdenKredi,İstenilenKrediTutari,Vade,FaizOrani,AylikMaliyetOrani,AylikMaliyet,AylikTutar,ToplamKrediTutari,KrediDurumu from Musteri_Bilgileri where KrediTürü='KONUT KREDİSİ' order by KrediTarihi desc", con);
             DataTable dt = new DataTable();

             adp.Fill(dt);
             dataGridView1.DataSource = dt;
             con.Close();

             for (int i = 0; i < (dataGridView1.Rows.Count - 1); i++)
             {
                 DataGridViewCellStyle rowColor = new DataGridViewCellStyle();


                 if (dataGridView1.Rows[i].Cells[29].Value.ToString() == "Onaylanmadı")
                 {
                     rowColor.BackColor = Color.Red;
                     dataGridView1.Rows[i].DefaultCellStyle = rowColor;
                 }
             }
         }

         private void taşıtKredisiToolStripMenuItem_Click(object sender, EventArgs e)
         {
             con.Open();
             SqlDataAdapter adp = new SqlDataAdapter("select MusteriNo,MusteriHesapNo,SubeKoduNo,KrediTarihi,TCNo,MusteriAd,MusteriSoyad,DogumTarihi,MedeniDurum,EsAd,EsSoyad,TCNoEs,EvTel,CepTel,Adres,CalismaDurumu,Tel_is,Adres_is,KrediTürü,AylikGelirTutari,GecmisKrediKullanimi,DevamEdenKredi,İstenilenKrediTutari,Vade,FaizOrani,AylikMaliyetOrani,AylikMaliyet,AylikTutar,ToplamKrediTutari,KrediDurumu from Musteri_Bilgileri where KrediTürü='TAŞIT KREDİSİ' order by KrediTarihi desc", con);
             DataTable dt = new DataTable();

             adp.Fill(dt);
             dataGridView1.DataSource = dt;
             con.Close();

             for (int i = 0; i < (dataGridView1.Rows.Count - 1); i++)
             {
                 DataGridViewCellStyle rowColor = new DataGridViewCellStyle();


                 if (dataGridView1.Rows[i].Cells[29].Value.ToString() == "Onaylanmadı")
                 {
                     rowColor.BackColor = Color.Red;
                     dataGridView1.Rows[i].DefaultCellStyle = rowColor;
                 }
             }
         }

         private void btnRapor_Click(object sender, EventArgs e)
         {
             this.Visible = false;
             Rapor rpr = new Rapor();
             rpr.Show();

         }

         private void radioOnaylanan_CheckedChanged(object sender, EventArgs e)
         {
             con.Open();
             SqlDataAdapter adp = new SqlDataAdapter("select MusteriNo,MusteriHesapNo,SubeKoduNo,KrediTarihi,TCNo,MusteriAd,MusteriSoyad,DogumTarihi,MedeniDurum,EsAd,EsSoyad,TCNoEs,EvTel,CepTel,Adres,CalismaDurumu,Tel_is,Adres_is,KrediTürü,AylikGelirTutari,GecmisKrediKullanimi,DevamEdenKredi,İstenilenKrediTutari,Vade,FaizOrani,AylikMaliyetOrani,AylikMaliyet,AylikTutar,ToplamKrediTutari,KrediDurumu from Musteri_Bilgileri where KrediDurumu='Onaylandı' order by KrediTarihi desc", con);
             DataTable dt = new DataTable();

             adp.Fill(dt);
             dataGridView1.DataSource = dt;
             con.Close();

             for (int i = 0; i < (dataGridView1.Rows.Count - 1); i++)
             {
                 DataGridViewCellStyle rowColor = new DataGridViewCellStyle();


                 if (dataGridView1.Rows[i].Cells[29].Value.ToString() == "Onaylanmadı")
                 {
                     rowColor.BackColor = Color.Red;
                     dataGridView1.Rows[i].DefaultCellStyle = rowColor;
                 }
             }
         }

         private void radioOnaylanmayan_CheckedChanged(object sender, EventArgs e)
         {
             con.Open();
             SqlDataAdapter adp = new SqlDataAdapter("select MusteriNo,MusteriHesapNo,SubeKoduNo,KrediTarihi,TCNo,MusteriAd,MusteriSoyad,DogumTarihi,MedeniDurum,EsAd,EsSoyad,TCNoEs,EvTel,CepTel,Adres,CalismaDurumu,Tel_is,Adres_is,KrediTürü,AylikGelirTutari,GecmisKrediKullanimi,DevamEdenKredi,İstenilenKrediTutari,Vade,FaizOrani,AylikMaliyetOrani,AylikMaliyet,AylikTutar,ToplamKrediTutari,KrediDurumu from Musteri_Bilgileri where KrediDurumu='Onaylanmadı' order by KrediTarihi desc", con);
             DataTable dt = new DataTable();

             adp.Fill(dt);
             dataGridView1.DataSource = dt;
             con.Close();

             for (int i = 0; i < (dataGridView1.Rows.Count - 1); i++)
             {
                 DataGridViewCellStyle rowColor = new DataGridViewCellStyle();


                 if (dataGridView1.Rows[i].Cells[29].Value.ToString() == "Onaylanmadı")
                 {
                     rowColor.BackColor = Color.Red;
                     dataGridView1.Rows[i].DefaultCellStyle = rowColor;
                 }
             }
         }

         private void btnMenuExcel_Click(object sender, EventArgs e)
         {
             if (comboAra.Text != "")
             {
                 Microsoft.Office.Interop.Excel.Application uyg = new Microsoft.Office.Interop.Excel.Application();
                 uyg.Visible = true;
                 Microsoft.Office.Interop.Excel.Workbook kitap = uyg.Workbooks.Add(System.Reflection.Missing.Value);
                 Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)kitap.Sheets[1];
                 for (int i = 0; i < dataGridView1.Columns.Count; i++)
                 {
                     Microsoft.Office.Interop.Excel.Range myrange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[1, i + 1];
                     myrange.Value2 = dataGridView1.Columns[i].HeaderText;
                 }
                 for (int i = 0; i < dataGridView1.Columns.Count; i++)
                 {
                     for (int j = 0; j < dataGridView1.Rows.Count; j++)
                     {
                         Microsoft.Office.Interop.Excel.Range my = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                         my.Value2 = dataGridView1[i, j].Value;
                     }
                 }
             }
             else if (dataGridView1.Columns.Count != 0)
            {
                Microsoft.Office.Interop.Excel.Application uyg = new Microsoft.Office.Interop.Excel.Application();
                uyg.Visible = true;
                Microsoft.Office.Interop.Excel.Workbook kitap = uyg.Workbooks.Add(System.Reflection.Missing.Value);
                Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)kitap.Sheets[1];
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    Microsoft.Office.Interop.Excel.Range myrange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[1, i + 1];
                    myrange.Value2 = dataGridView1.Columns[i].HeaderText;
                }
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Rows.Count; j++)
                    {
                        Microsoft.Office.Interop.Excel.Range my = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                        my.Value2 = dataGridView1[i, j].Value;
                    }
                }
            }
            else
             {
                 DialogResult secim = new DialogResult();

                 secim=MessageBox.Show("Excele gönderilecek veri yok...","Bilgilendirme",MessageBoxButtons.OK);
                 

             }
         }

         private void btnKefil_Click(object sender, EventArgs e)
         {
             this.Visible = false;
             Kefil_Ekleme kefil = new Kefil_Ekleme();
             kefil.Show();
         }

         private void cikisToolStripMenuItem1_Click(object sender, EventArgs e)
         {
             Application.Exit();
         }
    }
}
