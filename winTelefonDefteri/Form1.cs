using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winTelefonDefteri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Kisi[] Kisiler = new Kisi[0];

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // Ekrandaki kontrollerden veriler okunur ve değişkenlere aktarılır.
            string ad = txtAd.Text;
            string soyad = txtSoyad.Text;
            string telefon = txtTelefon.Text;

            // Girilen ifadelerdeki boşlukları Trim ile yok ederiz
            // ve karakter kalıyormu diye kontrol ederiz. Koşul sağlanırsa;
            // Mesaj gösterilir ve kod akışı kesilir.
            if(string.IsNullOrEmpty(ad.Trim()) == true)
            {
                MessageBox.Show("Ad boş geçilemez.");
                return;
            }

            if (string.IsNullOrEmpty(soyad.Trim()))
            {
                MessageBox.Show("Soyad boş geçilemez.");
                return;
            }

            Ekle(ad, soyad, telefon);

            Listele();
            Sifirla();
        }

        private void Ekle(string ad, string soyad, string telefon)
        {
            // Kisi tipinde kisi1 isimli bir değişken oluşturulur. 
            // New anahtar kelimesi ile nesneye dönüştürülür. RAM'de oluşması sağlanır.
            Kisi kisi1 = new Kisi();
            kisi1.Ad = ad;  // kisi1 isimli nesnemizin özelliklerine değerler atanır.
            kisi1.Soyad = soyad;
            kisi1.Telefon = telefon;

            //MessageBox.Show(ad + " " + soyad + " " + telefon);
            //MessageBox.Show(kisi1.Ad + " " + kisi1.Soyad + " " + kisi1.Telefon);

            // Dizinin boyutu 1 arttırılır.
            Array.Resize(ref Kisiler, Kisiler.Length + 1);
            // Dizinin en son elemanına kisi1 nesnesi eklenir.
            Kisiler[Kisiler.Length - 1] = kisi1;
        }

        private void Listele()
        {
            // Temiz bir sayfa açılır.(Lstbox temizlenir)
            lstKayitlar.Items.Clear();

            // Dizideki her eleman için dönülür.
            for (int i = 0; i < Kisiler.Length; i++)
            {
                // listbox'a eklenecek string ifade oluşturulur..
                string kayit =
                    Kisiler[i].Ad + " " + Kisiler[i].Soyad + " " + Kisiler[i].Telefon;

                // Listbox'a eklenir..
                lstKayitlar.Items.Add(kayit);
            }
        }

        private void Sifirla()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            txtTelefon.Clear();

            txtAd.Focus();
        }

        private void lstKayitlar_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Listbox'dan seçilen kayıdın index(sıra no) elde edilir.
            int index = lstKayitlar.SelectedIndex;

            // Dizimizde de aynı sıra söz konusu olduğundan;
            // listbox'dan seçilen index numarasına göre diziden Kisi nesnesi bir değişkene
            // atılır.
            Kisi kisi = Kisiler[index];

            txtAd.Text = kisi.Ad;
            txtSoyad.Text = kisi.Soyad;
            txtTelefon.Text = kisi.Telefon;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int index = lstKayitlar.SelectedIndex;

            if(index == -1)
            {
                MessageBox.Show("Lütfen güncellemek için bir kişi seç ulennn");
                return;
            }

            // Girilen ifadelerde boşluk karakter var mı kontrol ederiz.
            // Koşul sağlanırsa; Mesaj gösterilir ve kod akışı kesilir.
            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrEmpty(txtAd.Text) == true)
            {
                MessageBox.Show("Ad boş geçilemez.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSoyad.Text) || string.IsNullOrEmpty(txtSoyad.Text))
            {
                MessageBox.Show("Soyad boş geçilemez.");
                return;
            }

            Kisi kisi = Kisiler[index];

            kisi.Ad = txtAd.Text;
            kisi.Soyad = txtSoyad.Text;
            kisi.Telefon = txtTelefon.Text;

            Listele();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Ekle("Hasan1", "Kahraman1", "5555555555");
            Ekle("Hasan2", "Kahraman2", "4444444444");
            Ekle("Hasan3", "Kahraman3", "2222222222");

            Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int index = lstKayitlar.SelectedIndex;

            if(index == -1)
            {
                MessageBox.Show("Lütfen silmek için bir kişi seçiniz.");
                return;
            }

            Kisi[] kisiDizisi = new Kisi[Kisiler.Length - 1];
            int sayac = 0;

            for (int i = 0; i < Kisiler.Length; i++)
            {
                if(i != index)
                {
                    kisiDizisi[sayac] = Kisiler[i];
                    sayac++;
                }
            }

            Kisiler = kisiDizisi;

            Listele();
            Sifirla();
        }
    }
}
