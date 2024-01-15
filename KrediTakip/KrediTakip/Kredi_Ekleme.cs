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
    public partial class Kredi_Ekleme : Form
    {
        public Kredi_Ekleme()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MMHG0TC\SQLEXPRESS;Initial Catalog=Kredi;Integrated Security=True");
        int kredi;
        double faizorani;
        string krediDurumu = "Onaylandı";
        string EsCalismaDurum = "";
        double maliyetOrani = 1.84;
        double maliyet;
        double maliyettop;
        double ToplamMaliyet;
        private void buttonKrediMenü_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Menu menu = new Menu();
            menu.Show();
        }

        private void Kredi_Ekleme_Load(object sender, EventArgs e)
        {
            if (comboMedeni.Text == "")
            {
                textEsAd.Enabled = false;
                textEsSoyad.Enabled = false;
                textEsTC.Enabled = false;
                dateTimeEsDogum.Enabled = false;
                maskedEsCep.Enabled = false;
                maskedEsTel.Enabled = false;
                textEsAdres.Enabled = false;
                radioEvet.Enabled = false;
                radioHayır.Enabled = false;
                textEsAdresis.Enabled = false;
                maskedEsTel_is.Enabled = false;
            }
            if (comboCalisma.Text == "")
            {
                maskedTextis.Enabled = false;
                textAdres_is.Enabled = false;
            }

        }

        private void buttonHesapla_Click(object sender, EventArgs e)
        {
            if (comboKredi.Text == "")
            {
                MessageBox.Show("Kredi Türü Giriniz...");
            }
            else if (textKrediTutari.Text == "")
            {
                MessageBox.Show("Kredi Tutarı Giriniz...");
            }
            else if (comboVade.Text == "")
            {
                MessageBox.Show("Vade Giriniz...");
            }
            else
            {
                if (comboKredi.Text == "İHTİYAÇ KREDİSİ")
                {
                    faizorani = 0.95;
                }
                else if (comboKredi.Text == "KONUT KREDİSİ")
                {
                    faizorani = 1.25;
                }
                else if (comboKredi.Text == "TAŞIT KREDİSİ")
                {
                    faizorani = 1.15;
                }
                double faiz = Convert.ToDouble(textKrediTutari.Text) * (faizorani / 100);

                double ay = (Convert.ToDouble(textKrediTutari.Text) / Convert.ToDouble(comboVade.Text)) + faiz;
                maliyet = ay * (maliyetOrani / 100);
                ay += maliyet;

                double toplam = ay * Convert.ToDouble(comboVade.Text);
                textToplam.Text = Convert.ToString(Math.Round(toplam, 2));
                textOdnckTutar.Text = (Convert.ToString(Math.Round(ay, 2)));
                textFaiz.Text = faizorani.ToString();
                textVade.Text = comboVade.Text;
                maliyettop = Math.Round(maliyet, 2);
                textAylikMaliyetOran.Text = (maliyetOrani).ToString();
                textAylikMaliyet.Text = maliyettop.ToString();
                ToplamMaliyet = maliyettop * Convert.ToDouble(comboVade.Text);
                textToplamMaliyet.Text = Math.Round(ToplamMaliyet, 2).ToString();
                groupBoxHesap.Visible = true;
                buttonKaydet.Enabled = true;
            }
        }

        private void buttonKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboMedeni.Text == "EVLİ" && textEsAd.Text.Trim() == "" && textEsSoyad.Text.Trim() == "" && textEsTC.Text.Trim() == "" && textEsAdres.Text.Trim() == "")
                {
                    MessageBox.Show("Eksik veya Hatalı Giriş Yaptınız...");
                }
                else if (radioEvet.Checked && textEsAdresis.Text.Trim() == "" && maskedEsTel_is.Text.Trim() == "")
                {
                    MessageBox.Show("Eş İş Adres ve İş Tel Boş Geçilemez...");
                }
                else
                {
                    if (labelUyari.Text != "")
                    {
                        MessageBox.Show(labelUyari.Text);
                    }
                    else if (textMusteri.Text.Trim() != "" && textTC.Text.Trim() != "" && textHesap.Text.Trim() != "" && textSube.Text.Trim() != "" && textAd.Text.Trim() != "" && textSoyad.Text.Trim() != "" && maskedTextTel.Text != "" && maskedTextCep.Text != "" && textAdres.Text.Trim() != "" && textGelir.Text.Trim() != "" && comboKredi.Text != "" && comboKrediKullanımı.Text != "" && comboDvmEdnKredi.Text != "" && comboMedeni.Text != "" && textKrediTutari.Text.Trim() != "" && comboVade.Text.Trim() != "" && textFaiz.Text.Trim() != "" && textOdnckTutar.Text.Trim() != "" && textToplam.Text.Trim() != "" && textVade.Text.Trim() != "")
                    {

                        SqlCommand cmd = new SqlCommand("insert into Musteri_Bilgileri (MusteriNo,MusteriHesapNo,SubeKoduNo,KrediTarihi,TCNo,MusteriAd,MusteriSoyad,DogumTarihi,MedeniDurum,EsAd,EsSoyad,TCNoEs,EvTel,CepTel,Adres,CalismaDurumu,Tel_is,Adres_is,KrediTürü,AylikGelirTutari,GecmisKrediKullanimi,DevamEdenKredi,İstenilenKrediTutari,Vade,FaizOrani,AylikTutar,ToplamKrediTutari,KrediDurumu,AylikMaliyetOrani,AylikMaliyet,EsDogum,EsTel,EsCep,EsAdres,EsTelis,EsAdresis,EsCalismaDurum)values(@MusteriNo,@MusteriHesapNo,@SubeKoduNo,@KrediTarihi,@TCNo,@MusteriAd,@MusteriSoyad,@DogumTarihi,@MedeniDurum,@EsAd,@EsSoyad,@TCNoEs,@EvTel,@CepTel,@Adres,@CalismaDurumu,@Tel_is,@Adres_is,@KrediTürü,@AylikGelirTutari,@GecmisKrediKullanimi,@DevamEdenKredi,@İstenilenKrediTutari,@Vade,@FaizOrani,@AylikTutar,@ToplamKrediTutari,@KrediDurumu,@AylikMaliyetOrani,@AylikMaliyet,@EsDogum,@EsTel,@EsCep,@EsAdres,@EsTelis,@EsAdresis,@EsCalismaDurum)", con);

                        con.Open();
                        double gelir = Convert.ToDouble(textGelir.Text);
                        double aylikTutar = Convert.ToDouble(textOdnckTutar.Text);

                        if (gelir < 2000 || comboCalisma.Text == "HAYIR" || comboDvmEdnKredi.Text == "EVET" || aylikTutar > gelir)
                        {
                            krediDurumu = "Onaylanmadı";
                        }
                        if(radioEvet.Checked)
                        {
                            EsCalismaDurum = "EVET";
                        }
                        else if(radioHayır.Checked)
                        {
                            EsCalismaDurum = "HAYIR";
                        }
                        cmd.Parameters.AddWithValue("@MusteriNo", textMusteri.Text);
                        cmd.Parameters.AddWithValue("@MusteriHesapNo", textHesap.Text);
                        cmd.Parameters.AddWithValue("@SubeKoduNo", textSube.Text);
                        cmd.Parameters.AddWithValue("@KrediTarihi", dateTimeGün.Value);
                        cmd.Parameters.AddWithValue("@TCNo", textTC.Text);
                        cmd.Parameters.AddWithValue("@MusteriAd", textAd.Text);
                        cmd.Parameters.AddWithValue("@MusteriSoyad", textSoyad.Text);
                        cmd.Parameters.AddWithValue("@DogumTarihi", dateTimeDoğum.Value);
                        cmd.Parameters.AddWithValue("@MedeniDurum", comboMedeni.Text);
                        cmd.Parameters.AddWithValue("@EsAd", textEsAd.Text);
                        cmd.Parameters.AddWithValue("@EsSoyad", textEsSoyad.Text);
                        cmd.Parameters.AddWithValue("@TCNoEs", textEsTC.Text);
                        cmd.Parameters.AddWithValue("@EvTel", maskedTextTel.Text);
                        cmd.Parameters.AddWithValue("@CepTel", maskedTextCep.Text);
                        cmd.Parameters.AddWithValue("@Adres", textAdres.Text);
                        cmd.Parameters.AddWithValue("@CalismaDurumu", comboCalisma.Text);
                        cmd.Parameters.AddWithValue("@Tel_is", maskedTextis.Text);
                        cmd.Parameters.AddWithValue("@Adres_is", textAdres_is.Text);
                        cmd.Parameters.AddWithValue("@KrediTürü", comboKredi.Text);
                        cmd.Parameters.AddWithValue("@AylikGelirTutari", textGelir.Text);
                        cmd.Parameters.AddWithValue("@GecmisKrediKullanimi", comboKrediKullanımı.Text);
                        cmd.Parameters.AddWithValue("@DevamEdenKredi", comboDvmEdnKredi.Text);
                        cmd.Parameters.AddWithValue("@İstenilenKrediTutari", textKrediTutari.Text);
                        cmd.Parameters.AddWithValue("@Vade", comboVade.Text);
                        cmd.Parameters.AddWithValue("@FaizOrani", textFaiz.Text);
                        cmd.Parameters.AddWithValue("@AylikTutar", textOdnckTutar.Text);
                        cmd.Parameters.AddWithValue("@ToplamKrediTutari", textToplam.Text);
                        cmd.Parameters.AddWithValue("@KrediDurumu", krediDurumu);
                        cmd.Parameters.AddWithValue("@AylikMaliyetOrani", maliyetOrani);
                        cmd.Parameters.AddWithValue("@AylikMaliyet", maliyettop);
                        cmd.Parameters.AddWithValue("@EsDogum", dateTimeEsDogum.Value);
                        cmd.Parameters.AddWithValue("@EsTel", maskedEsTel.Text);
                        cmd.Parameters.AddWithValue("@EsCep", maskedEsCep.Text);
                        cmd.Parameters.AddWithValue("@EsAdres", textEsAdres.Text);
                        cmd.Parameters.AddWithValue("@EsTelis", maskedEsTel_is.Text);
                        cmd.Parameters.AddWithValue("@EsAdresis", textEsAdresis.Text);
                        cmd.Parameters.AddWithValue("@EsCalismaDurum", EsCalismaDurum);
                        
                        int ekle = cmd.ExecuteNonQuery();
                        if (ekle > 0)
                        {
                            try
                            {
                                MessageBox.Show("Veriler Kaydedildi...", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                textMusteri.Text = null;
                                textHesap.Text = null;
                                textTC.Text = null;
                                textAd.Text = null;
                                textSoyad.Text = null;
                                textSube.Text = null;
                                maskedTextTel.Text = null;
                                maskedTextis.Text = null;
                                textToplam.Text = null;
                                textVade.Text = null;
                                textOdnckTutar.Text = null;
                                textKrediTutari.Text = null;
                                textGelir.Text = null;
                                textFaiz.Text = null;
                                textEsTC.Text = null;
                                textEsSoyad.Text = null;
                                textEsAd.Text = null;
                                maskedTextCep.Text = null;
                                comboCalisma.Text = null;
                                comboDvmEdnKredi.Text = null;
                                comboKredi.Text = null;
                                comboKrediKullanımı.Text = null;
                                comboMedeni.Text = null;
                                comboVade.Text = null;
                                dateTimeDoğum.ResetText();
                                textAdres.Text = null;
                                textAdres_is.Text = null;
                                comboSube.Text = null;
                                buttonHesapla.Enabled = false;
                                buttonKaydet.Enabled = false;
                                labelUyari.Text = null;
                                maskedEsCep.Text = null;
                                maskedEsTel.Text = null;
                                textEsAdres.Text = null;
                                textEsAdresis.Text = null;
                                maskedEsTel_is.Text = null;
                                textAylikMaliyet.Text = null;
                                textAylikMaliyetOran.Text = null;
                                textToplamMaliyet.Text = null;
                                dateTimeEsDogum.ResetText();
                            }
                            catch (Exception hata)
                            {
                                MessageBox.Show("Kayıt Başarısız... " + hata.Message);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Eksik veya Hatalı Giriş Yaptınız...");
                    }
                    con.Close();
                    krediDurumu = "Onaylandı";
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void buttoniptal_Click(object sender, EventArgs e)
        {
            try
            {
                if (textMstriNo.Text.Trim() != "")
                {
                    DialogResult secim = new DialogResult();
                    secim = MessageBox.Show("Müşteri Bilgilerini Silmek İstediğinize Emin Misiniz ?", "Bilgilendirme", MessageBoxButtons.YesNo);
                    if (secim == DialogResult.Yes)
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandText = "delete  from Musteri_Bilgileri where MusteriNo=" + textMstriNo.Text;
                        int kontrol = cmd.ExecuteNonQuery();
                        if (kontrol != 0)
                        {
                            MessageBox.Show("Veri Silindi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            textMstriNo.Text = null;
                            textMusteri.Text = null;
                            textHesap.Text = null;
                            textTC.Text = null;
                            textAd.Text = null;
                            textSoyad.Text = null;
                            textSube.Text = null;
                            maskedTextTel.Text = null;
                            maskedTextis.Text = null;
                            textToplam.Text = null;
                            textVade.Text = null;
                            textOdnckTutar.Text = null;
                            textKrediTutari.Text = null;
                            textGelir.Text = null;
                            textFaiz.Text = null;
                            textEsTC.Text = null;
                            textEsSoyad.Text = null;
                            textEsAd.Text = null;
                            maskedTextCep.Text = null;
                            comboCalisma.Text = null;
                            comboDvmEdnKredi.Text = null;
                            comboKredi.Text = null;
                            comboKrediKullanımı.Text = null;
                            comboMedeni.Text = null;
                            comboVade.Text = null;
                            dateTimeDoğum.ResetText();
                            textAdres.Text = null;
                            textAdres_is.Text = null;
                            comboSube.Text = null;
                            buttonHesapla.Enabled = false;
                            buttonKaydet.Enabled = false;
                            labelUyari.Text = null;
                            maskedEsCep.Text = null;
                            maskedEsTel.Text = null;
                            textEsAdres.Text = null;
                            textEsAdresis.Text = null;
                            maskedEsTel_is.Text = null;
                            textAylikMaliyet.Text = null;
                            textAylikMaliyetOran.Text = null;
                            textToplamMaliyet.Text = null;
                            dateTimeEsDogum.ResetText();
                        }
                        else
                        {
                            MessageBox.Show("Silme Başarısız Müşteri Numarasını Yanlış Girdiniz... ");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Müşteri Numarasını Yazınız...");
                }
                con.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu..." + hata.Message);
            }
        }

        private void buttonDuzenle_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboMedeni.Text == "EVLİ" && textEsAd.Text.Trim() == "" && textEsSoyad.Text.Trim() == "" && textEsTC.Text.Trim() == "" && textEsAdres.Text.Trim() == "")
                {
                    MessageBox.Show("Eksik veya Hatalı Giriş Yaptınız...");
                }
                else if (radioEvet.Checked && textEsAdresis.Text.Trim() == "" && maskedEsTel_is.Text.Trim() == "")
                {
                    MessageBox.Show("Eş İş Adres ve İş Tel Boş Geçilemez...");
                }
                else
                {
                    if (textMusteri.Text != "" && textTC.Text != "" && textHesap.Text != "" && textSube.Text != "" && textAd.Text != "" && textSoyad.Text != "" && maskedTextTel.Text != "" && maskedTextCep.Text != "" && textAdres.Text != "" && textGelir.Text != "" && comboKredi.Text != "" && comboKrediKullanımı.Text != "" && comboDvmEdnKredi.Text != "" && comboMedeni.Text != "" && textKrediTutari.Text != "" && comboVade.Text != "" && textFaiz.Text != "" && textOdnckTutar.Text != "" && textToplam.Text != "" && textVade.Text != "")
                    {

                        if (textMstriNo.Text != "")
                        {
                            con.Open();

                            SqlCommand cmd = new SqlCommand();

                            cmd.Connection = con;
                            cmd.CommandText = "UPDATE Musteri_Bilgileri set MusteriNo=@MusteriNo,MusteriHesapNo=@MusteriHesapNo,SubeKoduNo=@SubeKoduNo,KrediTarihi=@KrediTarihi,TCNo=@TCNo,MusteriAd=@MusteriAd,MusteriSoyad=@MusteriSoyad,DogumTarihi=@DogumTarihi,MedeniDurum=@MedeniDurum,EsAd=@EsAd,EsSoyad=@EsSoyad,TCNoEs=@TCNoEs,EvTel=@EvTel,CepTel=@CepTel,Adres=@Adres,CalismaDurumu=@CalismaDurumu,Tel_is=@Tel_is,Adres_is=@Adres_is,KrediTürü=@KrediTürü,AylikGelirTutari=@AylikGelirTutari,GecmisKrediKullanimi=@GecmisKrediKullanimi,DevamEdenKredi=@DevamEdenKredi,İstenilenKrediTutari=@İstenilenKrediTutari,Vade=@Vade,FaizOrani=@FaizOrani,AylikTutar=@AylikTutar,ToplamKrediTutari=@ToplamKrediTutari,AylikMaliyetOrani=@AylikMaliyetOrani,AylikMaliyet=@AylikMaliyet,EsDogum=@EsDogum,EsTel=@EsTel,EsCep=@EsCep,EsAdres=@EsAdres,EsTelis=@EsTelis,EsAdresis=@EsAdresis where MusteriNo=" + textMstriNo.Text;

                            cmd.Parameters.AddWithValue("@MusteriNo", textMusteri.Text);
                            cmd.Parameters.AddWithValue("@MusteriHesapNo", textHesap.Text);
                            cmd.Parameters.AddWithValue("@SubeKoduNo", textSube.Text);
                            cmd.Parameters.AddWithValue("@KrediTarihi", dateTimeGün.Value);
                            cmd.Parameters.AddWithValue("@TCNo", textTC.Text);
                            cmd.Parameters.AddWithValue("@MusteriAd", textAd.Text);
                            cmd.Parameters.AddWithValue("@MusteriSoyad", textSoyad.Text);
                            cmd.Parameters.AddWithValue("@DogumTarihi", dateTimeDoğum.Value);
                            cmd.Parameters.AddWithValue("@MedeniDurum", comboMedeni.Text);
                            cmd.Parameters.AddWithValue("@EsAd", textEsAd.Text);
                            cmd.Parameters.AddWithValue("@EsSoyad", textEsSoyad.Text);
                            cmd.Parameters.AddWithValue("@TCNoEs", textEsTC.Text);
                            cmd.Parameters.AddWithValue("@EvTel", maskedTextTel.Text);
                            cmd.Parameters.AddWithValue("@CepTel", maskedTextCep.Text);
                            cmd.Parameters.AddWithValue("@Adres", textAdres.Text);
                            cmd.Parameters.AddWithValue("@CalismaDurumu", comboCalisma.Text);
                            cmd.Parameters.AddWithValue("@Tel_is", maskedTextis.Text);
                            cmd.Parameters.AddWithValue("@Adres_is", textAdres_is.Text);
                            cmd.Parameters.AddWithValue("@KrediTürü", comboKredi.Text);
                            cmd.Parameters.AddWithValue("@AylikGelirTutari", textGelir.Text);
                            cmd.Parameters.AddWithValue("@GecmisKrediKullanimi", comboKrediKullanımı.Text);
                            cmd.Parameters.AddWithValue("@DevamEdenKredi", comboDvmEdnKredi.Text);
                            cmd.Parameters.AddWithValue("@İstenilenKrediTutari", textKrediTutari.Text);
                            cmd.Parameters.AddWithValue("@Vade", comboVade.Text);
                            cmd.Parameters.AddWithValue("@FaizOrani", textFaiz.Text);
                            cmd.Parameters.AddWithValue("@AylikTutar", textOdnckTutar.Text);
                            cmd.Parameters.AddWithValue("@ToplamKrediTutari", textToplam.Text);
                            cmd.Parameters.AddWithValue("@AylikMaliyetOrani", maliyetOrani);
                            cmd.Parameters.AddWithValue("@AylikMaliyet", maliyettop);
                            cmd.Parameters.AddWithValue("@EsDogum", dateTimeEsDogum.Value);
                            cmd.Parameters.AddWithValue("@EsTel", maskedEsTel.Text);
                            cmd.Parameters.AddWithValue("@EsCep", maskedEsCep.Text);
                            cmd.Parameters.AddWithValue("@EsAdres", textEsAdres.Text);
                            cmd.Parameters.AddWithValue("@EsTelis", maskedEsTel_is.Text);
                            cmd.Parameters.AddWithValue("@EsAdresis", textEsAdresis.Text);
                            if (textMstriNo.Text == textMusteri.Text)
                            {
                                try
                                {
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Veriler Güncellendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    textMstriNo.Text = null;
                                    textMusteri.Text = null;
                                    textHesap.Text = null;
                                    textTC.Text = null;
                                    textAd.Text = null;
                                    textSoyad.Text = null;
                                    textSube.Text = null;
                                    maskedTextTel.Text = null;
                                    maskedTextis.Text = null;
                                    textToplam.Text = null;
                                    textVade.Text = null;
                                    textOdnckTutar.Text = null;
                                    textKrediTutari.Text = null;
                                    textGelir.Text = null;
                                    textFaiz.Text = null;
                                    textEsTC.Text = null;
                                    textEsSoyad.Text = null;
                                    textEsAd.Text = null;
                                    maskedTextCep.Text = null;
                                    comboCalisma.Text = null;
                                    comboDvmEdnKredi.Text = null;
                                    comboKredi.Text = null;
                                    comboKrediKullanımı.Text = null;
                                    comboMedeni.Text = null;
                                    comboVade.Text = null;
                                    dateTimeDoğum.ResetText();
                                    textAdres.Text = null;
                                    textAdres_is.Text = null;
                                    comboSube.Text = null;
                                    buttonHesapla.Enabled = false;
                                    buttonKaydet.Enabled = false;
                                    labelUyari.Text = null;
                                    textAylikMaliyet.Text = null;
                                    textAylikMaliyetOran.Text = null;
                                    textToplamMaliyet.Text = null;
                                }
                                catch (Exception hata)
                                {
                                    MessageBox.Show("Müşteri Numarasını Yanlış Girdiniz..." + hata.Message);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Müşteri Numarasını Yanlış Girdiniz...");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Güncellenecek Müşterinin Bilgilerini Getirin...");
                    }
                    con.Close();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu... " + hata.Message);
            }
        }

        private void buttonBilgiGtr_Click(object sender, EventArgs e)
        {
            try
            {
                if (textMstriNo.Text.Trim() != "")
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from Musteri_Bilgileri where MusteriNo=" + textMstriNo.Text);
                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        textMusteri.Text = dr["MusteriNo"].ToString();
                        textHesap.Text = dr["MusteriHesapNo"].ToString();
                        textSube.Text = dr["SubeKoduNo"].ToString();
                        dateTimeGün.Value = Convert.ToDateTime(dr["KrediTarihi"]);
                        textTC.Text = dr["TCNo"].ToString();
                        textAd.Text = dr["MusteriAd"].ToString();
                        textSoyad.Text = dr["MusteriSoyad"].ToString();
                        dateTimeDoğum.Value = Convert.ToDateTime(dr["DogumTarihi"]);
                        comboMedeni.Text = dr["MedeniDurum"].ToString();
                        textEsAd.Text = dr["EsAd"].ToString();
                        textEsSoyad.Text = dr["EsSoyad"].ToString();
                        textEsTC.Text = dr["TCNoEs"].ToString();
                        maskedTextTel.Text = dr["EvTel"].ToString();
                        maskedTextCep.Text = dr["CepTel"].ToString();
                        textAdres.Text = dr["Adres"].ToString();
                        comboCalisma.Text = dr["CalismaDurumu"].ToString();
                        maskedTextis.Text = dr["Tel_is"].ToString();
                        textAdres_is.Text = dr["Adres_is"].ToString();
                        comboKredi.Text = dr["KrediTürü"].ToString();
                        textGelir.Text = dr["AylikGelirTutari"].ToString();
                        comboKrediKullanımı.Text = dr["GecmisKrediKullanimi"].ToString();
                        comboDvmEdnKredi.Text = dr["DevamEdenKredi"].ToString();
                        textKrediTutari.Text = dr["İstenilenKrediTutari"].ToString();
                        comboVade.Text = dr["Vade"].ToString();
                        textVade.Text = dr["Vade"].ToString();
                        textFaiz.Text = dr["FaizOrani"].ToString();
                        textOdnckTutar.Text = dr["AylikTutar"].ToString();
                        textToplam.Text = dr["ToplamKrediTutari"].ToString();                       
                        string kontrol = dr["EsAdres"].ToString();
                        if (kontrol != "")
                        {
                            dateTimeEsDogum.Value = Convert.ToDateTime(dr["EsDogum"]);
                            maskedEsTel.Text = dr["EsTel"].ToString();
                            maskedEsCep.Text = dr["EsCep"].ToString();
                            textEsAdres.Text = dr["EsAdres"].ToString();
                            maskedEsTel_is.Text = dr["EsTelis"].ToString();
                            textEsAdresis.Text = dr["EsAdresis"].ToString();
                            EsCalismaDurum = dr["EsCalismaDurum"].ToString();
                            if (EsCalismaDurum == "EVET")
                            {
                                radioEvet.Checked = true;
                            }
                            else if (EsCalismaDurum == "HAYIR")
                            {
                                radioHayır.Checked = true;
                            }
                        }                    
                    }
                    else
                    {
                        MessageBox.Show("Müşteri Numarasını Yanlış Girdiniz...");
                    }
                }
                else
                {
                    MessageBox.Show("Müşteri Numarasını Yazınız...");
                }
                con.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Hata Oluştu... " + hata.Message);
            }
        }

        private void comboMedeni_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboMedeni.Text == "")
            {
                textEsAd.Enabled = true;
                textEsSoyad.Enabled = true;
                textEsTC.Enabled = true;
                dateTimeEsDogum.Enabled = true;
                maskedEsCep.Enabled = true;
                maskedEsTel.Enabled = true;
                textEsAdres.Enabled = true;
                radioEvet.Enabled = true;
                radioHayır.Enabled = true;
                //textEsAdresis.Enabled = true;
                //maskedEsTel_is.Enabled = true;
            }
            else if (comboMedeni.Text == "BEKAR")
            {
                textEsAd.Enabled = false;
                textEsSoyad.Enabled = false;
                textEsTC.Enabled = false;
                dateTimeEsDogum.Enabled = false;
                maskedEsCep.Enabled = false;
                maskedEsTel.Enabled = false;
                textEsAdres.Enabled = false;
                radioEvet.Enabled = false;
                radioHayır.Enabled = false;               
                textEsAdresis.Enabled = false;
                maskedEsTel_is.Enabled = false;
                textEsAd.Text = null;
                textEsSoyad.Text = null;
                textEsTC.Text = null;
                maskedEsCep.Text = null;
                maskedEsTel.Text = null;
                textEsAdres.Text = null;
                textEsAdresis.Text = null;
                maskedEsTel_is.Text = null;
                dateTimeEsDogum.ResetText();

            }
            else
            {
                textEsAd.Enabled = true;
                textEsSoyad.Enabled = true;
                textEsTC.Enabled = true;
                dateTimeEsDogum.Enabled = true;
                maskedEsCep.Enabled = true;
                maskedEsTel.Enabled = true;
                textEsAdres.Enabled = true;
                radioEvet.Enabled = true;
                radioHayır.Enabled = true;
                //textEsAdresis.Enabled = true;
                //maskedEsTel_is.Enabled = true;
            }
        }

        private void comboCalisma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboCalisma.Text == "")
            {
                maskedTextis.Enabled = false;
                textAdres_is.Enabled = false;
            }
            else if (comboCalisma.Text == "HAYIR")
            {
                maskedTextis.Enabled = false;
                textAdres_is.Enabled = false;
                maskedTextis.Text = null;
                textAdres_is.Text = null;
                buttonHesapla.Enabled = true;
            }
            else
            {
                maskedTextis.Enabled = true;
                textAdres_is.Enabled = true;
                buttonHesapla.Enabled = true;
            }
        }

        private void buttonTemizle_Click(object sender, EventArgs e)
        {
            textMstriNo.Text = null;
            textMusteri.Text = null;
            textHesap.Text = null;
            textTC.Text = null;
            textAd.Text = null;
            textSoyad.Text = null;
            textSube.Text = null;
            maskedTextTel.Text = null;
            maskedTextis.Text = null;
            textToplam.Text = null;
            textVade.Text = null;
            textOdnckTutar.Text = null;
            textKrediTutari.Text = null;
            textGelir.Text = null;
            textFaiz.Text = null;
            textEsTC.Text = null;
            textEsSoyad.Text = null;
            textEsAd.Text = null;
            maskedTextCep.Text = null;
            comboCalisma.Text = null;
            comboDvmEdnKredi.Text = null;
            comboKredi.Text = null;
            comboKrediKullanımı.Text = null;
            comboMedeni.Text = null;
            comboVade.Text = null;
            dateTimeDoğum.ResetText();
            textAdres.Text = null;
            textAdres_is.Text = null;
            comboSube.Text = null;
            buttonHesapla.Enabled = false;
            buttonKaydet.Enabled = false;
            labelUyari.Text = null;
            maskedEsCep.Text = null;
            maskedEsTel.Text = null;
            textEsAdres.Text = null;
            textEsAdresis.Text = null;
            maskedEsTel_is.Text = null;
            textAylikMaliyet.Text = null;
            textAylikMaliyetOran.Text = null;
            textToplamMaliyet.Text = null;
            dateTimeEsDogum.Enabled = false;
            maskedEsCep.Enabled = false;
            maskedEsTel.Enabled = false;
            textEsAdres.Enabled = false;
            radioEvet.Enabled = false;
            radioHayır.Enabled = false;
            radioEvet.Checked = false;
            radioHayır.Checked = false;
            textEsAdresis.Enabled = false;
            maskedEsTel_is.Enabled = false;
            dateTimeEsDogum.ResetText();
            textEsAd.Enabled = false;
            textSoyad.Enabled = false;
            textEsTC.Enabled = false;
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

        private void textMusteri_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            if (textMusteri.TextLength == 6)
            {
                e.Handled = true;
            }
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }

        }

        private void textHesap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            if (textHesap.TextLength == 8)
            {
                e.Handled = true;
            }
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void textSube_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            if (textSube.TextLength == 4)
            {
                e.Handled = true;
            }
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void textGelir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            if (textGelir.TextLength == 6)
            {
                e.Handled = true;
            }
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void textKrediTutari_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            if (textKrediTutari.TextLength == 6)
            {
                e.Handled = true;
            }
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void textAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            if (textAd.TextLength == 15)
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

        private void textEsAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            if (textEsAd.TextLength == 15)
            {
                e.Handled = true;
            }
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void textEsSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            if (textEsSoyad.TextLength == 15)
            {
                e.Handled = true;
            }
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void textEsTC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            if (textEsTC.TextLength == 11)
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

        private void textAdres_is_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textAdres_is.TextLength == 200)
            {
                e.Handled = true;
            }
        }

        private void textMstriNo_TextChanged(object sender, EventArgs e)
        {
            if (textMstriNo.Text == "")
            {
                buttonDuzenle.Enabled = false;
                buttonBilgiGtr.Enabled = false;
                buttoniptal.Enabled = false;
            }
            else
            {
                buttonDuzenle.Enabled = true;
                buttonBilgiGtr.Enabled = true;
                buttoniptal.Enabled = true;
            }
        }

        private void comboSube_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboSube.Text == "LEVENT")
            {
                textSube.Text = "001";
            }
            else if (comboSube.Text == "4.LEVENT")
            {
                textSube.Text = "002";
            }
            else if (comboSube.Text == "ORTAKÖY")
            {
                textSube.Text = "003";
            }
            else if (comboSube.Text == "BEŞİKTAŞ")
            {
                textSube.Text = "004";
            }
            else if (comboSube.Text == "KADIKÖY")
            {
                textSube.Text = "005";
            }
            else if (comboSube.Text == "ACIBADEM")
            {
                textSube.Text = "006";
            }
            else if (comboSube.Text == "SUADİYE")
            {
                textSube.Text = "007";
            }
            else if (comboSube.Text == "SAHRAYICEDİT")
            {
                textSube.Text = "008";
            }
            else if (comboSube.Text == "KOŞUYOLU")
            {
                textSube.Text = "009";
            }
            else if (comboSube.Text == "KAĞITHANE")
            {
                textSube.Text = "010";
            }
            else if (comboSube.Text == "ÇAĞLAYAN")
            {
                textSube.Text = "011";
            }
            else if (comboSube.Text == "GÜLTEPE")
            {
                textSube.Text = "012";
            }
            else if (comboSube.Text == "ÇELİKTEPE")
            {
                textSube.Text = "013";
            }
            else if (comboSube.Text == "SEYRANTEPE")
            {
                textSube.Text = "014";
            }
            else if (comboSube.Text == "SANAYİ MAHALLESİ")
            {
                textSube.Text = "015";
            }

        }

        private void textMstriNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            if (textMstriNo.TextLength == 6)
            {
                e.Handled = true;
            }
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void textKrediTutari_TextChanged(object sender, EventArgs e)
        {

            if (textKrediTutari.Text != "")
            {
                kredi = Convert.ToInt32(textKrediTutari.Text);
            }
            else
            {
                labelUyari.Text = "";
            }
            if (kredi > 20000)
            {
                if (comboKredi.Text == "İHTİYAÇ KREDİSİ")
                {
                    labelUyari.Text = "İhtiyaç Kredisi 20.000 TL'yi geçemez...";
                }
            }
            if (kredi <= 20000)
            {
                if (comboKredi.Text == "İHTİYAÇ KREDİSİ")
                {
                    labelUyari.Text = "";
                }
            }
            if (kredi > 500000)
            {
                if (comboKredi.Text == "KONUT KREDİSİ")
                {
                    labelUyari.Text = "Konut Kredisi 500.000 TL'yi geçemez...";
                }
            }
            if (kredi < 500000)
            {
                if (comboKredi.Text == "KONUT KREDİSİ")
                {
                    if (kredi <= 500000)
                    {
                        labelUyari.Text = "";
                    }
                }
            }
            if (kredi > 100000)
            {
                if (comboKredi.Text == "TAŞIT KREDİSİ")
                {
                    labelUyari.Text = "Taşıt Kredisi 100.000 TL'yi geçemez...";
                }
            }
            if (kredi < 100000)
            {
                if (comboKredi.Text == "TAŞIT KREDİSİ")
                {
                    if (kredi <= 100000)
                    {
                        labelUyari.Text = "";
                    }
                }
            }

        }

        private void comboKredi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboKredi.Text == "")
            {
                textKrediTutari.Enabled = false;
            }
            else
            {
                textKrediTutari.Enabled = true;
            }
        }

        private void textEsAdres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textEsAdres.TextLength == 200)
            {
                e.Handled = true;
            }
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void textEsAdresis_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textEsAdresis.TextLength == 200)
            {
                e.Handled = true;
            }
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }

        private void radioEvet_CheckedChanged(object sender, EventArgs e)
        {
            textEsAdresis.Enabled = true;
            maskedEsTel_is.Enabled = true;
        }

        private void radioHayır_CheckedChanged(object sender, EventArgs e)
        {
            textEsAdresis.Enabled = false;
            maskedEsTel_is.Enabled = false;
            textEsAdresis.Text = null;
            maskedEsTel_is.Text = null;
        }
    }
}
