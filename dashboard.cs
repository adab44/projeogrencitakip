using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeogrencitakip
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            string dosyaIcerik = IcerikOlustur();
            string dosyaYolu = DosyaAdi();
            File.WriteAllText(Path.Combine("ogrenciler", dosyaYolu), dosyaIcerik);
            MessageBox.Show("Kaydedildi");

            listBox1.Items.Add(txt_ad.Text + " " + txt_soyad.Text);
        }

        private string DosyaAdi()
        {
            string[] dosyalar = Directory.GetFiles("ogrenciler");
            if (dosyalar.Length == 0)
            {
                return "1.txt";
            }
            else
            {
                return (KacTaneKaldi(dosyalar) + 1) + ".txt";
            }
        }

        private int KacTaneKaldi(string[] dosyalar)
        {
            int biggestNumber = 0;
            foreach (var item in dosyalar)
            {
                string sonuncu = SonuncuyuAl(item);
                int sonSayi = Convert.ToInt32(sonuncu.Replace(".txt", ""));
                if (sonSayi > biggestNumber)
                {
                    biggestNumber = sonSayi;
                }
            }
            return biggestNumber;
        }

        private string SonuncuyuAl(string yol)
        {
            string[] parcalar = yol.Split('\\');
            return parcalar[parcalar.Length - 1];
        }

        private string IcerikOlustur()
        {
            if (string.IsNullOrWhiteSpace(txt_ad.Text) ||
                string.IsNullOrWhiteSpace(txt_soyad.Text) ||
                string.IsNullOrWhiteSpace(cmb_sinif.Text))
            {
                return "Lütfen tüm bilgileri doldurun."; // Uygun bir hata mesajı
            }
            string dosyacontent = txt_ad.Text;
            dosyacontent += Environment.NewLine;
            dosyacontent += txt_soyad.Text;
            dosyacontent += Environment.NewLine;
            dosyacontent += cmb_sinif.Text;
            dosyacontent += Environment.NewLine;
            dosyacontent += DateTime.Today.ToShortDateString();

            return dosyacontent;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Visible= true;
            label2.Visible= true;
            label3.Visible= true;
            string secilenAdSoyad = (string)listBox1.SelectedItem;
            string[] tumOgrenciDosyaları = Directory.GetFiles("ogrenciler");
            foreach (var item in tumOgrenciDosyaları)
            {
                string[] satirlar = File.ReadAllLines(item);
                string adSoyad = satirlar[0] + " " + satirlar[1];
                if (adSoyad == secilenAdSoyad)
                {
                    lbl_ad.Text = satirlar[0];
                    lbl_soyad.Text = satirlar[1];
                    lbl_sınıf.Text = satirlar[2];
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Öğrenci seçilmedi.");
            }
            else
            {
                string secilenAdSoyad = (string)listBox1.SelectedItem;
                string[] tumOgrenciDosyaları = Directory.GetFiles("ogrenciler");
                foreach (var item in tumOgrenciDosyaları)
                {
                    string[] satirlar = File.ReadAllLines(item);
                    string adSoyad = satirlar[0] + " " + satirlar[1];
                    if (adSoyad == secilenAdSoyad)
                    {
                        listBox1.Items.Remove(secilenAdSoyad);
                        File.Delete(item);
                        lbl_ad.Text = "";
                        lbl_soyad.Text = "";
                        lbl_sınıf.Text = "";
                        break;
                    }
                }
            }
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            lbl_ad.Text = "";
            lbl_soyad.Text = "";
            lbl_sınıf.Text = "";

            string[] tumOgrenciler = Directory.GetFiles("ogrenciler");
            foreach (var item in tumOgrenciler)
            {
                string[] satirlar = File.ReadAllLines(item);
                string ad = satirlar[0];
                string soyad = satirlar[1];
                listBox1.Items.Add(ad + " " + soyad);
            }
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            txt_ad.Clear();
            txt_soyad.Clear();
            cmb_sinif.Text="";
        }
    }
}
