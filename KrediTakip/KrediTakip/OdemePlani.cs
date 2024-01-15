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
    public partial class OdemePlani : Form
    {
        public OdemePlani()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-MMHG0TC\SQLEXPRESS;Initial Catalog=Kredi;Integrated Security=True");
        private void buttonOdmPlan_Click(object sender, EventArgs e)
        {
            if (textBoxMusteriNo.Text == "")
            {
                MessageBox.Show("Müşteri Numarasını Giriniz...");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                
                cmd.Connection = con;
                cmd.CommandText = "select MusteriNo,MusteriAd,MusteriSoyad,AylikTutar,Vade,FaizOrani,AylikMaliyetOrani,AylikMaliyet,ToplamKrediTutari from Musteri_Bilgileri where MusteriNo=" + textBoxMusteriNo.Text;

                string aylik=null;
                string vade=null;
                string faiz=null;
                string no = null;
                string ad = null;
                string soyad = null;
                string maliyetoran = null;
                string maliyet = null;
                string toplam = null;

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    no = dr.GetString(0);
                    ad = dr.GetString(1);
                    soyad = dr.GetString(2);
                    aylik = dr.GetString(3);
                    vade = dr.GetString(4);
                    faiz = dr.GetString(5);
                    maliyetoran = dr.GetString(6);
                    maliyet = dr.GetString(7);
                    toplam = dr.GetString(8);
                }
                int i = Convert.ToInt32(vade);
                int k = 0;
                k = i;
                double kalan=Convert.ToDouble( toplam) -Convert.ToDouble( aylik);
                for (int j = 1; j <= i; j++)
                {                    
                    string[] veri = { no, ad, soyad, Convert.ToString(j), aylik, faiz,maliyetoran,maliyet,Convert.ToString(Math.Round(kalan,2)) };
                    ListViewItem item = new ListViewItem(veri);
                    listView1.Items.Add(item);
                    kalan = Convert.ToDouble(kalan) - Convert.ToDouble(aylik);
                }
                if (k != 0)
                {
                    ListViewItem itemm = new ListViewItem();
                    listView1.Items.Add("TOPLAM");
                    listView1.Items.Add(itemm.SubItems[0].Text = toplam);
                }
                
                if (k==0)
                {
                    MessageBox.Show("Kayıt Bulunamadı");
                }
                
                con.Close();
            }
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

        private void buttonKapat_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Menu menu = new Menu();
            menu.Show();
        }

        private void OdemePlani_Load(object sender, EventArgs e)
        {

        }

        private void buttonTemiz_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            textBoxMusteriNo.Text = null;
            
        }

        private void textBoxMusteriNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            if (textBoxMusteriNo.TextLength == 6)
            {
                e.Handled = true;
            }
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
        }
    }
}
