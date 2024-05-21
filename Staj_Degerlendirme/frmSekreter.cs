using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Staj_Degerlendirme
{
    public partial class frmSekreter : Form
    {
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;DataBase=staj_degerlendirme;user=root");
        public frmSekreter()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand();
            komut.CommandText = "INSERT INTO ogrenci (tc_kimlik,ad,soyad,ogrenci_no,email,sinif,telefon,bolum,staj_kodu," +
                "staj_yeri,staj_baslama_tarihi,staj_bitis_tarihi,evrak_teslim,basvuru_dilekcesi,kabul_yazisi,mustehaklik,kimlik_fotokopisi," +
                "staj_formu,staj_raporu,aciklama)" + "VALUES (@tc_kimlik,@ad,@soyad,@ogrenci_no,@email,@sinif,@telefon,@bolum,@staj_kodu," +
                "@staj_yeri,@staj_baslama_tarihi,@staj_bitis_tarihi,@evrak_teslim,@basvuru_dilekcesi,@kabul_yazisi,@mustehaklik,@kimlik_fotokopisi," +
                "@staj_formu,@staj_raporu,@aciklama)";
            komut.Parameters.AddWithValue("@tc_kimlik",mtbTc.Text);
            komut.Parameters.AddWithValue("@ad",txtAd.Text);
            komut.Parameters.AddWithValue("@soyad",txtSoyad.Text);
            komut.Parameters.AddWithValue("@ogrenci_no", txtOgrenciNo.Text);
            komut.Parameters.AddWithValue("@email",txtEposta.Text);
            komut.Parameters.AddWithValue("@sinif",txtSinif.Text);
            komut.Parameters.AddWithValue("@telefon",mtbTel.Text);
            komut.Parameters.AddWithValue("@bolum",txtBolumu.Text);
            komut.Parameters.AddWithValue("@staj_kodu", txtStajkodu.Text);
            komut.Parameters.AddWithValue("@staj_yeri",txtStajYeri.Text);
            komut.Parameters.AddWithValue("@staj_baslama_tarihi",DateTime.Parse(mtbBaslangicTarihi.Text));
            komut.Parameters.AddWithValue("@staj_bitis_tarihi",DateTime.Parse(mtbBitisTarihi.Text));
            komut.Parameters.AddWithValue("@evrak_teslim",cbTeslim.Checked? 1:0);
            komut.Parameters.AddWithValue("@basvuru_dilekcesi",cbDilekce.Checked ? 1:0);
            komut.Parameters.AddWithValue("@kabul_yazisi", cbKabulYazi.Checked ? 1:0);
            komut.Parameters.AddWithValue("@mustehaklik",cbMustehaklik.Checked ? 1:0);
            komut.Parameters.AddWithValue("@kimlik_fotokopisi",cbKimlikFoto.Checked ? 1:0);
            komut.Parameters.AddWithValue("@staj_formu",cbStajDegerlendirmeForm.Checked ? 1:0);
            komut.Parameters.AddWithValue("@staj_raporu",cbStajRapor.Checked ? 1:0);
            komut.Parameters.AddWithValue("@aciklama",txtAciklama.Text);
            komut.Connection = baglanti;
            komut.ExecuteNonQuery();
            MessageBox.Show("Öğrenci Başarıyla Eklendi");
            komut.Dispose();
            baglanti.Close();
        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            MySqlCommand komut = new MySqlCommand();
            komut.CommandText = "UPDATE ogrenci SET tc_kimlik=@tc_kimlik, ad=@ad, soyad=@soyad, ogrenci_no=@ogrenci_no, email=@email, " +
                                "sinif=@sinif, telefon=@telefon, bolum=@bolum, staj_kodu=@staj_kodu, staj_yeri=@staj_yeri, " +
                                "staj_baslama_tarihi=@staj_baslama_tarihi, staj_bitis_tarihi=@staj_bitis_tarihi, " +
                                "evrak_teslim=@evrak_teslim, basvuru_dilekcesi=@basvuru_dilekcesi, kabul_yazisi=@kabul_yazisi, " +
                                "mustehaklik=@mustehaklik, kimlik_fotokopisi=@kimlik_fotokopisi, staj_formu=@staj_formu, " +
                                "staj_raporu=@staj_raporu, aciklama=@aciklama WHERE tc_kimlik=@tc_kimlik";
            komut.Parameters.AddWithValue("@tc_kimlik", mtbTc.Text);
            komut.Parameters.AddWithValue("@ad", txtAd.Text);
            komut.Parameters.AddWithValue("@soyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("@ogrenci_no", txtOgrenciNo.Text);
            komut.Parameters.AddWithValue("@email", txtEposta.Text);
            komut.Parameters.AddWithValue("@sinif", txtSinif.Text);
            komut.Parameters.AddWithValue("@telefon", mtbTel.Text);
            komut.Parameters.AddWithValue("@bolum", txtBolumu.Text);
            komut.Parameters.AddWithValue("@staj_kodu", txtStajkodu.Text);
            komut.Parameters.AddWithValue("@staj_yeri", txtStajYeri.Text);
            komut.Parameters.AddWithValue("@staj_baslama_tarihi", DateTime.Parse(mtbBaslangicTarihi.Text));
            komut.Parameters.AddWithValue("@staj_bitis_tarihi", DateTime.Parse(mtbBitisTarihi.Text));
            komut.Parameters.AddWithValue("@evrak_teslim", cbTeslim.Checked ? 1 : 0);
            komut.Parameters.AddWithValue("@basvuru_dilekcesi", cbDilekce.Checked ? 1 : 0);
            komut.Parameters.AddWithValue("@kabul_yazisi", cbKabulYazi.Checked ? 1 : 0);
            komut.Parameters.AddWithValue("@mustehaklik", cbMustehaklik.Checked ? 1 : 0);
            komut.Parameters.AddWithValue("@kimlik_fotokopisi", cbKimlikFoto.Checked ? 1 : 0);
            komut.Parameters.AddWithValue("@staj_formu", cbStajDegerlendirmeForm.Checked ? 1 : 0);
            komut.Parameters.AddWithValue("@staj_raporu", cbStajRapor.Checked ? 1 : 0);
            komut.Parameters.AddWithValue("@aciklama", txtAciklama.Text);
            komut.Connection = baglanti;
            komut.ExecuteNonQuery();
            MessageBox.Show("Öğrenci Başarıyla Güncellendi");
            komut.Dispose();
            baglanti.Close();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Ogrenci_liste ogrenci_Liste = new Ogrenci_liste();
            ogrenci_Liste.Show();
        }

        private void btnYeniKayit_Click(object sender, EventArgs e)
        {
            mtbTc.Text = string.Empty;
            mtbBaslangicTarihi.Text = string.Empty;
            mtbBitisTarihi.Text = string.Empty;
            mtbTel.Text = string.Empty;
            txtAd.Text = string.Empty;
            txtSoyad.Text = string.Empty;
            txtOgrenciNo.Text = string.Empty;
            txtBolumu.Text = string.Empty;
            txtKayitNo.Text = string.Empty;
            txtStajkodu.Text = string.Empty;
            txtStajYeri.Text = string.Empty;
            txtEposta.Text = string.Empty;
            txtAciklama.Text = string.Empty;
            txtSinif.Text = string.Empty;
            cbTeslim.Checked = false;
            cbDilekce.Checked = false;
            cbKabulYazi.Checked = false;
            cbKimlikFoto.Checked = false;
            cbMustehaklik.Checked = false;
            cbStajDegerlendirmeForm.Checked = false;
            cbStajRapor.Checked = false;
            txtKayitNo.Focus();
        }

        private void txtKayitNo_TextChanged(object sender, EventArgs e)
        {
            int ogrenciID;
            if(int.TryParse(txtKayitNo.Text, out ogrenciID))
            {
                baglanti.Open();
                MySqlCommand komut = new MySqlCommand("SELECT * FROM ogrenci WHERE id=@ogrenciID",baglanti);
                komut.Parameters.AddWithValue("@ogrenciID", ogrenciID);

                MySqlDataReader okuyucu = komut.ExecuteReader();
                if (okuyucu.Read())
                {
                    // Veritabanından alınan bilgileri ilgili kontrol elemanlarına doldur
                    mtbTc.Text = okuyucu["tc_kimlik"].ToString();
                    txtAd.Text = okuyucu["ad"].ToString();
                    txtSoyad.Text = okuyucu["soyad"].ToString();
                    txtOgrenciNo.Text = okuyucu["ogrenci_no"].ToString();
                    txtEposta.Text = okuyucu["email"].ToString();
                    txtSinif.Text = okuyucu["sinif"].ToString(); 
                    mtbTel.Text = okuyucu["telefon"].ToString();
                    txtBolumu.Text = okuyucu["bolum"].ToString();
                    txtStajkodu.Text = okuyucu["staj_kodu"].ToString();
                    txtStajYeri.Text = okuyucu["staj_yeri"].ToString();
                    mtbBaslangicTarihi.Text = okuyucu["staj_baslama_tarihi"].ToString(); 
                    mtbBitisTarihi.Text = okuyucu["staj_bitis_tarihi"].ToString(); 
                    cbTeslim.Checked = Convert.ToBoolean(okuyucu["evrak_teslim"]);
                    cbDilekce.Checked = Convert.ToBoolean(okuyucu["basvuru_dilekcesi"]);
                    cbKabulYazi.Checked = Convert.ToBoolean(okuyucu["kabul_yazisi"]);
                    cbMustehaklik.Checked = Convert.ToBoolean(okuyucu["mustehaklik"]);
                    cbKimlikFoto.Checked = Convert.ToBoolean(okuyucu["kimlik_fotokopisi"]);
                    cbStajDegerlendirmeForm.Checked = Convert.ToBoolean(okuyucu["staj_formu"]);
                    cbStajRapor.Checked = Convert.ToBoolean(okuyucu["staj_raporu"]);
                    txtAciklama.Text = okuyucu["aciklama"].ToString();
                }
                else
                {
                    MessageBox.Show("Öğrenci bulunamadı.");
                }

                okuyucu.Close();
                komut.Dispose();
                baglanti.Close();
            
            }
        }

        private void btnAnaSayfa_Click(object sender, EventArgs e)
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
