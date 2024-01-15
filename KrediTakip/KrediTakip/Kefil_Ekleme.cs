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
    public partial class Kefil_Ekleme : Form
    {
        public Kefil_Ekleme()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MMHG0TC\SQLEXPRESS;Initial Catalog=Kredi;Integrated Security=True");
        string musteri_no;
        string MusNo;
        string KefilTc;
        string KefilAd;
        string KefilSoy;
        string KefilDogum;
        string KefilEv;
        string KefilCep;
        string KefilAdres;
        private void Kefil_Ekleme_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select MusteriNo,MusteriHesapNo,MusteriAd,MusteriSoyad from Musteri_Bilgileri where MusteriNo  IS NOT NULL order by KrediTarihi desc";
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string No = dr.GetString(0);
                    string HesNo = dr.GetString(1);
                    string Ad = dr.GetString(2);
                    string Soyad = dr.GetString(3);
                    string[] veri = { No, HesNo, Ad, Soyad, "", "", "", "", "", "", "" };
                    ListViewItem item = new ListViewItem(veri);
                    listView1.Items.Add(item);
                }
                con.Close();
                con.Open();
                SqlCommand cmmd = new SqlCommand();
                cmmd.Connection = con;
                cmmd.CommandText = "select KefilMusteriNo,KefilTC,KefilAdi,KefilSoyadi,KefilDogum,KefilEvTel,KefilCepTel,KefilAdres from Kefil_Bilgileri where KefilTC IS NOT NULL";

                SqlDataReader drr = cmmd.ExecuteReader();
                while (drr.Read())
                {
                    MusNo = drr.GetString(0);
                    KefilTc = drr.GetString(1);
                    KefilAd = drr.GetString(2);
                    KefilSoy = drr.GetString(3);
                    KefilDogum = Convert.ToDateTime(drr.GetDateTime(4)).ToShortDateString().ToString();
                    KefilEv = drr.GetString(5);
                    KefilCep = drr.GetString(6);
                    KefilAdres = drr.GetString(7);
                    foreach (ListViewItem item in listView1.Items)
                    {

                        if (listView1.Items[item.Index].SubItems[0].Text == MusNo)
                        {
                            ListViewItem itemm = new ListViewItem();
                            listView1.Items[item.Index].SubItems[4].Text = KefilTc;
                            listView1.Items[item.Index].SubItems[5].Text = KefilAd;
                            listView1.Items[item.Index].SubItems[6].Text = KefilSoy;
                            listView1.Items[item.Index].SubItems[7].Text = KefilDogum;
                            listView1.Items[item.Index].SubItems[8].Text = KefilEv;
                            listView1.Items[item.Index].SubItems[9].Text = KefilCep;
                            listView1.Items[item.Index].SubItems[10].Text = KefilAdres;
                        }
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            con.Close();
            int index = 0;
            ListViewItem itemms = new ListViewItem();
            foreach (ListViewItem items in listView1.Items)
            {

                if (index % 2 == 0)
                    items.BackColor = Color.MediumSlateBlue;
                else
                    items.BackColor = Color.MediumSpringGreen;

                index++;
            }
        }

        private void btnMenü_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Menu menu = new Menu();
            menu.Show();
        }

        private void btnKefil_Düzenle_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                musteri_no = listView1.SelectedItems[0].SubItems[0].Text;
                if (textTC.Text.Trim() != "" && textAD.Text.Trim() != "" && textSoyad.Text.Trim() != "" && maskedTextCepTel.Text.Trim() != "" && textAdres.Text.Trim() != "")
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "UPDATE Kefil_Bilgileri set KefilTC=@KefilTC,KefilAdi=@KefilAdi,KefilSoyadi=@KefilSoyadi,KefilDogum=@KefilDogum,KefilEvTel=@KefilEvTel,KefilCepTel=@KefilCepTel,KefilAdres=@KefilAdres where KefilMusteriNo=" + musteri_no;

                    cmd.Parameters.AddWithValue("@KefilTC", textTC.Text);
                    cmd.Parameters.AddWithValue("@KefilAdi", textAD.Text);
                    cmd.Parameters.AddWithValue("@KefilSoyadi", textSoyad.Text);
                    cmd.Parameters.AddWithValue("@KefilDogum", dateTimeDogum.Value);
                    cmd.Parameters.AddWithValue("@KefilEvTel", maskedTextTel.Text);
                    cmd.Parameters.AddWithValue("@KefilCepTel", maskedTextCepTel.Text);
                    cmd.Parameters.AddWithValue("@KefilAdres", textAdres.Text);

                    try
                    {
                        int kont = cmd.ExecuteNonQuery();                      
                        if (kont > 0)
                        {
                            MessageBox.Show("Veriler Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            foreach (ListViewItem item in listView1.Items)
                            {

                                if (listView1.Items[item.Index].SubItems[0].Text == musteri_no)
                                {
                                    ListViewItem itemm = new ListViewItem();
                                    listView1.Items[item.Index].SubItems[4].Text = textTC.Text;
                                    listView1.Items[item.Index].SubItems[5].Text = textAD.Text;
                                    listView1.Items[item.Index].SubItems[6].Text = textSoyad.Text;
                                    listView1.Items[item.Index].SubItems[7].Text = dateTimeDogum.Value.ToShortDateString();
                                    listView1.Items[item.Index].SubItems[8].Text = maskedTextTel.Text;
                                    listView1.Items[item.Index].SubItems[9].Text = maskedTextCepTel.Text;
                                    listView1.Items[item.Index].SubItems[10].Text = textAdres.Text;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Önce Kefil Bilgilerini Kaydediniz...");
                        }
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("hata" + hata.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Eksik veya Hatalı Giriş");
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Kefil Bilgileri Güncellenecek Müşteriyi Seçiniz...");
            }
        }

        private void btnKefil_Ekle_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                musteri_no = listView1.SelectedItems[0].SubItems[0].Text;

                if (textTC.Text.Trim() != "" && textAD.Text.Trim() != "" && textSoyad.Text.Trim() != "" && maskedTextCepTel.Text.Trim() != "" && textAdres.Text.Trim() != "")
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Kefil_Bilgileri (KefilMusteriNo,KefilTC,KefilAdi,KefilSoyadi,KefilDogum,KefilEvTel,KefilCepTel,KefilAdres)values(@KefilMusteriNo,@KefilTC,@KefilAdi,@KefilSoyadi,@KefilDogum,@KefilEvTel,@KefilCepTel,@KefilAdres)", con);

                    cmd.Parameters.AddWithValue("@KefilMusteriNo", musteri_no);
                    cmd.Parameters.AddWithValue("@KefilTC", textTC.Text);
                    cmd.Parameters.AddWithValue("@KefilAdi", textAD.Text);
                    cmd.Parameters.AddWithValue("@KefilSoyadi", textSoyad.Text);
                    cmd.Parameters.AddWithValue("@KefilDogum", dateTimeDogum.Value);
                    cmd.Parameters.AddWithValue("@KefilEvTel", maskedTextTel.Text);
                    cmd.Parameters.AddWithValue("@KefilCepTel", maskedTextCepTel.Text);
                    cmd.Parameters.AddWithValue("@KefilAdres", textAdres.Text);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Veriler Kaydedildi...", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        foreach (ListViewItem item in listView1.Items)
                        {

                            if (listView1.Items[item.Index].SubItems[0].Text == musteri_no)
                            {
                                ListViewItem itemm = new ListViewItem();
                                listView1.Items[item.Index].SubItems[4].Text = textTC.Text;
                                listView1.Items[item.Index].SubItems[5].Text = textAD.Text;
                                listView1.Items[item.Index].SubItems[6].Text = textSoyad.Text;
                                listView1.Items[item.Index].SubItems[7].Text = dateTimeDogum.Value.ToShortDateString();
                                listView1.Items[item.Index].SubItems[8].Text = maskedTextTel.Text;
                                listView1.Items[item.Index].SubItems[9].Text = maskedTextCepTel.Text;
                                listView1.Items[item.Index].SubItems[10].Text = textAdres.Text;
                            }
                        }
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("Kayıt Başarısız... " + hata.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Eksik veya Hatalı Giriş");
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Kefil Eklenecek Müşteriyi Seçiniz...");
            }
        }

        private void btn_Yenile_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select MusteriNo,MusteriHesapNo,MusteriAd,MusteriSoyad from Musteri_Bilgileri where MusteriNo  IS NOT NULL order by KrediTarihi desc";
            try
            {
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    string No = dr.GetString(0);
                    string HesNo = dr.GetString(1);
                    string Ad = dr.GetString(2);
                    string Soyad = dr.GetString(3);
                    string[] veri = { No, HesNo, Ad, Soyad, "", "", "", "", "", "", "" };
                    ListViewItem item = new ListViewItem(veri);
                    listView1.Items.Add(item);
                }
                con.Close();
                con.Open();
                SqlCommand cmmd = new SqlCommand();
                cmmd.Connection = con;
                cmmd.CommandText = "select KefilMusteriNo,KefilTC,KefilAdi,KefilSoyadi,KefilDogum,KefilEvTel,KefilCepTel,KefilAdres from Kefil_Bilgileri where KefilTC IS NOT NULL";

                SqlDataReader drr = cmmd.ExecuteReader();
                while (drr.Read())
                {
                    MusNo = drr.GetString(0);
                    KefilTc = drr.GetString(1);
                    KefilAd = drr.GetString(2);
                    KefilSoy = drr.GetString(3);
                    KefilDogum = Convert.ToDateTime(drr.GetDateTime(4)).ToShortDateString().ToString();
                    KefilEv = drr.GetString(5);
                    KefilCep = drr.GetString(6);
                    KefilAdres = drr.GetString(7);
                    foreach (ListViewItem item in listView1.Items)
                    {

                        if (listView1.Items[item.Index].SubItems[0].Text == MusNo)
                        {
                            ListViewItem itemm = new ListViewItem();
                            listView1.Items[item.Index].SubItems[4].Text = KefilTc;
                            listView1.Items[item.Index].SubItems[5].Text = KefilAd;
                            listView1.Items[item.Index].SubItems[6].Text = KefilSoy;
                            listView1.Items[item.Index].SubItems[7].Text = KefilDogum;
                            listView1.Items[item.Index].SubItems[8].Text = KefilEv;
                            listView1.Items[item.Index].SubItems[9].Text = KefilCep;
                            listView1.Items[item.Index].SubItems[10].Text = KefilAdres;
                        }
                    }
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            con.Close();
            int index = 0;
            ListViewItem itemms = new ListViewItem();
            foreach (ListViewItem items in listView1.Items)
            {

                if (index % 2 == 0)
                    items.BackColor = Color.MediumSlateBlue;
                else
                    items.BackColor = Color.MediumSpringGreen;

                index++;
            }
            
            //try
            //{
            //     musteri_no = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["MusteriNo"].Value.ToString());

            //    textTC.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            //    textAD.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            //    textSoyad.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            //    dateTimeDogum.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[7].Value);
            //    maskedTextTel.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            //    maskedTextCepTel.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            //    textAdres.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();

            //}
            //catch (Exception hata)
            //{
            //    MessageBox.Show(hata.Message);
            //}

        }

        private void btn_Temizle_Click(object sender, EventArgs e)
        {
            musteri_no = null;
            textMusteri_No.Text = null;
            textMusteri_Ad.Text = null;
            textMusteri_Soyad.Text = null;
            textTC.Text = null;
            textAD.Text = null;
            textSoyad.Text = null;
            maskedTextTel.Text = null;
            maskedTextCepTel.Text = null;
            textAdres.Text = null;
            dateTimeDogum.ResetText();
            listView1.Items.Clear();
                       
        }

        private void btnKefil_Sil_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                musteri_no = listView1.SelectedItems[0].SubItems[0].Text;
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "delete  from Kefil_Bilgileri where KefilMusteriNo=" + musteri_no;

                try
                {
                   int kontrol= cmd.ExecuteNonQuery();                  
                   if (kontrol > 0)
                   {
                       MessageBox.Show("Kefil Silindi...");
                       foreach (ListViewItem item in listView1.Items)
                       {

                           if (listView1.Items[item.Index].SubItems[0].Text == musteri_no)
                           {
                               ListViewItem itemm = new ListViewItem();
                               listView1.Items[item.Index].SubItems[4].Text = "";
                               listView1.Items[item.Index].SubItems[5].Text = "";
                               listView1.Items[item.Index].SubItems[6].Text = "";
                               listView1.Items[item.Index].SubItems[7].Text = "";
                               listView1.Items[item.Index].SubItems[8].Text = "";
                               listView1.Items[item.Index].SubItems[9].Text = "";
                               listView1.Items[item.Index].SubItems[10].Text = "";
                           }
                       }
                       textTC.Text = null;
                       textAD.Text = null;
                       textSoyad.Text = null;
                       maskedTextTel.Text = null;
                       maskedTextCepTel.Text = null;
                       textAdres.Text = null;
                   }
                    else
                   {
                       MessageBox.Show("Silinecek Kefil Bulunamadı...");
                   }
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Silme Başarısız... " + hata.Message);
                }
                con.Close();
                
            }
            else
            {
                MessageBox.Show("Kefili Silinecek Müşteriyi Seçiniz...");
            }
        }

        private void textTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            if (textTC.TextLength == 11)
            {
                e.Handled = true;
            }
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void textAD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            if (textAD.TextLength == 15)
            {
                e.Handled = true;
            }
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void textSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            if (textSoyad.TextLength == 15)
            {
                e.Handled = true;
            }
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void textAdres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textAdres.TextLength == 200)
            {
                e.Handled = true;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                textMusteri_No.Text = listView1.SelectedItems[0].SubItems[0].Text;
                textMusteri_Ad.Text = listView1.SelectedItems[0].SubItems[2].Text;
                textMusteri_Soyad.Text = listView1.SelectedItems[0].SubItems[3].Text;
                textTC.Text = listView1.SelectedItems[0].SubItems[4].Text;
                textAD.Text = listView1.SelectedItems[0].SubItems[5].Text;
                textSoyad.Text = listView1.SelectedItems[0].SubItems[6].Text;
                if (listView1.SelectedItems[0].SubItems[7].Text != "")
                {
                    dateTimeDogum.Value = Convert.ToDateTime(listView1.SelectedItems[0].SubItems[7].Text);
                }
                maskedTextTel.Text = listView1.SelectedItems[0].SubItems[8].Text;
                maskedTextCepTel.Text = listView1.SelectedItems[0].SubItems[9].Text;
                textAdres.Text = listView1.SelectedItems[0].SubItems[10].Text;
                musteri_no = listView1.SelectedItems[0].SubItems[0].Text;
            }
        }



    }
}
