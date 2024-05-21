using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Staj_Degerlendirme
{
    public partial class frmSekreterGiris : Form
    {
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;DataBase=staj_degerlendirme;user=root");
        public frmSekreterGiris()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            frmSekreter frmSekreter = new frmSekreter();
            try
            {
                baglanti.Open();
                string query = "SELECT * FROM sekreter WHERE email=@email AND sifre=@sifre";
                MySqlCommand komut = new MySqlCommand(query, baglanti);
                komut.Parameters.AddWithValue("@email", txtEmail.Text);
                komut.Parameters.AddWithValue("@sifre", txtSifre.Text);
                MySqlDataReader reader = komut.ExecuteReader();
                if (reader.Read())
                {
                    MessageBox.Show("Giriş Başarılı");
                    this.Hide();
                    frmSekreter.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış");
                }
                reader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Bir Hata Oluştu..."+ex.Message);
            }
            finally { baglanti.Close(); }
            
        }
        

        private void btnAnasayfa_Click(object sender, EventArgs e)
        {
            frmGirisSecenek frmGirisSecenek = new frmGirisSecenek();
            if(MessageBox.Show("Ana Sayfaya dönmek istediğinizden emin misiniz?","Dön",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                frmGirisSecenek.ShowDialog();
                this.Close();
            }
        }
    }
}
