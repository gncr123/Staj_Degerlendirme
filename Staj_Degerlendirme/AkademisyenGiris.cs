using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staj_Degerlendirme
{
    public partial class AkademisyenGiris : Form
    {
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;DataBase=staj_degerlendirme;user=root");

        public AkademisyenGiris()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            int logInAkademisyenId = -1;
            try
            {
                baglanti.Open();
                string query = "SELECT id FROM akademisyen WHERE email=@email AND sifre=@sifre";
                MySqlCommand komut = new MySqlCommand(query, baglanti);
                komut.Parameters.AddWithValue("@email", txtEmail.Text);
                komut.Parameters.AddWithValue("@sifre", txtSifre.Text);
                object result = komut.ExecuteScalar();
                if (result != null)
                {
                    logInAkademisyenId = Convert.ToInt32(result);
                    MessageBox.Show("Giriş Başarılı");
                    this.Hide();
                    frmAkademisyen frmAkademisyen = new frmAkademisyen(logInAkademisyenId);
                    frmAkademisyen.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir Hata Oluştu..." + ex.Message);
            }
            finally { baglanti.Close(); }

        }

        private void btnAnasayfa_Click(object sender, EventArgs e)
        {
            frmGirisSecenek frmGirisSecenek = new frmGirisSecenek();
            if (MessageBox.Show("Ana Sayfaya dönmek istediğinizden emin misiniz?", "Dön", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                frmGirisSecenek.ShowDialog();
                this.Close();
            }
        }
    }
}
