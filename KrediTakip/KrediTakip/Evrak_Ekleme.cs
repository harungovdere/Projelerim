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
using System.IO;
using System.Drawing.Imaging;
using System.Data.SqlTypes;

namespace KrediTakip
{
    public partial class Evrak_Ekleme : Form
    {
        public Evrak_Ekleme()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MMHG0TC\SQLEXPRESS;Initial Catalog=Kredi;Integrated Security=True");
        string resimAdresi;

        public void DialogHazirla()
        {

            openFileDialog1.Title = "Resim Seç"; /* Dosya açma iletisim kutumuzun basligini belirliyoruz. */

            openFileDialog1.Filter = "Jpeg Dosyalari(*.jpg)|*.jpg|Gif dosyalari(*.gif)|*.gif|Doc dosyalari(*.doc)|*.doc|Docx dosyalari(*.docx)|*.docx|Excel dosyalari(*.xls)|*.xls|Excell dosyalari(*.xlsx)|*.xlsx|Pdf dosyalari(*.pdf)|*.pdf|Png dosyalari(*.png)|*.png"; /* Iletisim kutumuzun, sadece jpg ve gif dosyalarini göstermesini, Filter özelligi ile ayarliyoruz.*/

        }
        private void Evrak_Ekleme_Load(object sender, EventArgs e)
        {

            DialogHazirla();
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter("select MusteriNo,MusteriHesapNo,KrediTarihi,TCNo,MusteriAd,MusteriSoyad,resim from Musteri_Bilgileri order by KrediTarihi desc", con);
            DataTable dt = new DataTable();

            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

            //  listView1.Items.Clear();
            //con.Open();
            //SqlCommand cmd = new SqlCommand();
            //cmd.Connection = con;
            //cmd.CommandText = "select MusteriNo,MusteriHesapNo,TCNo,MusteriAd,MusteriSoyad,resim,dosya from Musteri_Bilgileri where MusteriNo  IS NOT NULL order by KrediTarihi desc";

            //    SqlDataReader dr = cmd.ExecuteReader();
            //    while (dr.Read())
            //    {
            //        string No = dr.GetString(0);
            //        string HesNo = dr.GetString(1);
            //        string TC = dr.GetString(2);
            //        string Ad = dr.GetString(3);
            //        string Soyad = dr.GetString(4);
            //        string Resim = dr.GetString(5);
            //        string Dosya = dr.GetString(6);
            //        if(Resim!="")
            //        {
            //             rs = "EKLENDİ";
            //        }
            //        else
            //        {
            //            rs = "EKLENMEDİ";
            //        }
            //        if(Dosya!="")
            //        {
            //             ds = "EKLENDİ";
            //        }
            //        else
            //        {
            //            ds = "EKLENMEDİ";
            //        }
            //        string[] veri = { No, HesNo,TC, Ad, Soyad, rs, ds};
            //        ListViewItem item = new ListViewItem(veri);
            //        listView1.Items.Add(item);
            //    }
            //    con.Close();

        }

        private void btnResim_Click(object sender, EventArgs e)
        {
            /* Kullanici bu butona tikladiginda, OpenFileDialog kontrolümüz, dosya açma iletisim kutusunu açar. Kullanici bir dosya seçip OK tusunda bastiginda, Picture Box kontrolümüze seçilen resim dosyasi alinarak gösterilmesi sağlanır. Daha sonra seçilen dosyanin tam adresi label kontrolümüze alınır ve resimAdresi degiskenimize atanır. */

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                pictureBox1.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName); /* Drawing isim uzayinda yer alan Image sinifinin FromFile metodunu kullanarak belirtilen adresteki dosya PictureBox kontrolü içine çizilir. */

                //lblDosyaAdi.Text=openFileDialog1.FileName.ToString();

                resimAdresi = openFileDialog1.FileName.ToString();
            }
        }

        private void btnResimKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                /* Simdi en önemli kodlarimizi yazmaya basliyoruz. Öncelikle dosyamizi açmamiz gerekli. Çünkü resim dosyasinin içerigini byte olarak okumak istiyoruz. Bu amaçla FileStream nesnemizi olusturuyor ve gerekli parametrelerini ayarliyoruz. Ilk parametre, dosyanin tam yolunu belirtir. Ikinci parametre ise dosyamizi açmak için kullanacagimizi belirtir. Son parametre ise dosyanin okuma amaci ile açildigini belirtir. */

                FileStream fsResim = new FileStream(resimAdresi, FileMode.Open, FileAccess.Read);

                /* BinaryReader nesnemiz, byte dizimiz ile, parametre olarak aldigi FileStream nesnesi arasinda , veri akisini saglamak için olusturuluyor. Akim, FileStream nesnesinin belirttigi dosyadan, dosyadaki byte'larin aktarilacagi diziye dogru olucaktir.*/

                BinaryReader brResim = new BinaryReader(fsResim);

                /* Simdi resim adinda bir byte dizisi olusturuyoruz. brResim isimli BinaryReader nesnemizin, ReadBytes metodunu kullanarak, bu nesnenin veri akisi için baglanti kurdugu FileStream nesnesinin belirttigi dosyadaki tüm byte'lari, byte dizimize akitiyoruz. Böylece resim dosyamizin tüm byte'lari yani dosyamizin kendisi, byte dizimize aktarilmis oluyor.*/

                byte[] resim = brResim.ReadBytes((int)fsResim.Length);

                /* Son olarak, BinaryReader ve FileStream nesnelerini kapatiyoruz. */

                brResim.Close();

                fsResim.Close();

                /* Artik Sql baglantimizi olusturabilir ve sql komutumuzu çalistirabiliriz. Önce SqlConnection nesnemizi olusturuyoruz. */

                /* Simdi sql komutumuzu çalistiracak olan SqlCommand nesnemizi olusturuyoruz. Burada alanlarin degerlerini parametreler üzerinden aktardigimiza dikkat edelim. */
                if (textMusteriNo.Text.Trim() != "")
                {
                    SqlCommand cmdResimKaydet = new SqlCommand();
                    cmdResimKaydet.Connection = con;
                    cmdResimKaydet.CommandText = "UPDATE Musteri_Bilgileri set resim=@resim where MusteriNo=" + textMusteriNo.Text;

                    //cmdResimKaydet.Parameters.Add("@Yorum", SqlDbType.Char, 250).Value = txtYorum.Text; /* Bu parametremiz @Yorum isminde ve Char tipinde. 250 karakter uzunlugunda. Hemen ayni satirda Value özelligini kullanarak parametrenin degerinide belirliyoruz. */

                    cmdResimKaydet.Parameters.Add("@resim", SqlDbType.Image, resim.Length).Value = resim; /* Seçtigimiz resim dosyasinin byte'larini, tablodaki ilgili alana tasiyacak parametremizi belirtiyoruz. Deger olarak, resim isimli byte dizimizi aktariyoruz. Parametre tipinin, image olduguna dikkat edelim. */



                    /* Günveli blogumuzda, Sql baglantimizi açiyoruz. Ardindan, sql komutumuzu ExecuteNonQuery metodu ile çalistiriyoruz. Son olarakta herhangibir hata olsada, olmasada, finally blogunda sql baglantimizi kapatiyoruz.*/

                    con.Open();
                    int kontrol = cmdResimKaydet.ExecuteNonQuery();
                    if (kontrol != 0)
                    {
                        MessageBox.Show("Resim Kaydedildi.");
                    }
                    else
                    {
                        MessageBox.Show("Müşteri Numarası Yanlış...");
                    }
                    con.Close();
                    pictureBox1.Image = null;
                }
                else
                {
                    MessageBox.Show("Müşteri Numarasını Giriniz...");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Resim Seçiniz...");
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Menu menu = new Menu();
            menu.Show();
        }

        private void btnResmGetir_Click(object sender, EventArgs e)
        {
            if (textMusteriNo.Text.Trim() != "")
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select resim from Musteri_Bilgileri where MusteriNo=" + textMusteriNo.Text);
                    cmd.Connection = con;

                    Image uyeResim = null;
                    int kontrol = cmd.ExecuteNonQuery();
                    SqlDataReader oku = cmd.ExecuteReader();

                    while (oku.Read())
                    {
                        byte[] resim = (byte[])oku[0];
                        MemoryStream ms = new MemoryStream(resim, 0, resim.Length);
                        ms.Write(resim, 0, resim.Length);
                        uyeResim = Image.FromStream(ms, true);
                        pictureBox1.Image = uyeResim;
                    }
                    oku.Close();

                    if (pictureBox1.Image == null)
                    {
                        MessageBox.Show("Müşteri Numarası Yanlış...");
                    }
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Hata Oluştu... " + hata.Message);
                }
            }
            else
            {
                MessageBox.Show("Müşteri Numarasını Yazınız...");
            }
            con.Close();
        }

        private void btnDosyaKaydet_Click(object sender, EventArgs e)
        {
            if (textMusteriNo.Text.Trim() != "")
            {
                FileStream fsdosya = new FileStream(resimAdresi, FileMode.Open, FileAccess.Read);

                BinaryReader brdosya = new BinaryReader(fsdosya);

                byte[] dosya = brdosya.ReadBytes((int)fsdosya.Length);

                brdosya.Close();

                fsdosya.Close();

                SqlCommand cmddosya = new SqlCommand();
                cmddosya.Connection = con;
                cmddosya.CommandText = "UPDATE Musteri_Bilgileri set dosya=@dosya where MusteriNo=" + textMusteriNo.Text;

                cmddosya.Parameters.Add("@dosya", SqlDbType.VarBinary, dosya.Length).Value = dosya;

                try
                {
                    con.Open();
                    int kon = cmddosya.ExecuteNonQuery();
                    if (kon != 0)
                    {
                        MessageBox.Show("Dosya Kaydedildi");
                    }
                    else
                    {
                        MessageBox.Show("Müşteri Numarası Yanlış...");
                    }
                }

                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message.ToString());
                }

                finally
                {
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("Müşteri Numarasını Yazınız...");
            }
        }

        private void btnDosyaSec_Click(object sender, EventArgs e)
        {
            /* Kullanici bu butona tikladiginda, OpenFileDialog kontrolümüz, dosya açma iletisim kutusunu açar. Kullanici bir dosya seçip OK tusunda bastiginda, Picture Box kontrolümüze seçilen resim dosyasi alinarak gösterilmesi sağlanır. Daha sonra seçilen dosyanin tam adresi label kontrolümüze alınır ve resimAdresi degiskenimize atanır. */

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                // pictureBox1.Image = System.Drawing.Image.FromFile(openFileDialog1.FileName); /* Drawing isim uzayinda yer alan Image sinifinin FromFile metodunu kullanarak belirtilen adresteki dosya PictureBox kontrolü içine çizilir. */

                labelDosya.Text = openFileDialog1.FileName.ToString();

                resimAdresi = openFileDialog1.FileName.ToString();
            }
        }

        private void textMusteriNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            if (textMusteriNo.TextLength == 6)
            {
                e.Handled = true;
            }
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textMusteriNo.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textMusteri_Ad.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textMusteri_Soyad.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            string veri = dataGridView1.CurrentRow.Cells[6].Value.ToString();
           
            if(veri.Trim()!="")
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select resim from Musteri_Bilgileri where MusteriNo=" + textMusteriNo.Text);
                    cmd.Connection = con;

                    Image uyeResim = null;
                    int kontrol = cmd.ExecuteNonQuery();
                    SqlDataReader oku = cmd.ExecuteReader();

                    while (oku.Read())
                    {
                        byte[] resim = (byte[])oku[0];
                        MemoryStream ms = new MemoryStream(resim, 0, resim.Length);
                        ms.Write(resim, 0, resim.Length);
                        uyeResim = Image.FromStream(ms, true);
                        pictureBox1.Image = uyeResim;
                    }
                    oku.Close();
                    con.Close();
                }
                catch(Exception hata)
                {
                    MessageBox.Show(hata.Message);
                }
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter adp = new SqlDataAdapter("select MusteriNo,MusteriHesapNo,KrediTarihi,TCNo,MusteriAd,MusteriSoyad,resim from Musteri_Bilgileri order by KrediTarihi desc", con);
            DataTable dt = new DataTable();

            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        





    }
}
