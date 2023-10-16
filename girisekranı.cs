using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projeogrencitakip
{
    public partial class girisekranı : Form
    {
        public girisekranı()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

                if (txt_kullaniciadi.Text == "admin" && txt_sifre.Text == "123")
                {
                    new dashboard().Show();
                }
                else
                {
                    MessageBox.Show("Hatalı bilgi, bilgilerinizi kontrol ediniz", "Hatalı giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            
        }
    }
}
