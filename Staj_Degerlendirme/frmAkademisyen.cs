using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staj_Degerlendirme
{
    public partial class frmAkademisyen : Form
    {
        private int logInAkademisyenId,akademisyenID;
        private int toplam = 0;
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;DataBase=staj_degerlendirme;user=root");
        public frmAkademisyen(int logInAkademisyenId)
        {
            InitializeComponent();
            this.logInAkademisyenId = logInAkademisyenId;//giriş yapan akademisyen değerini tutar
            logInAkademisyenId = akademisyenID;
        }
        private void Listele()
        {
            MySqlDataAdapter adaptor = new MySqlDataAdapter("SELECT * FROM ogrenci", baglanti);
            MySqlDataAdapter adaptor1 = new MySqlDataAdapter("SELECT * FROM ogrenci_not", baglanti);
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            dt1.Clear();
            dt.Clear();
            adaptor.Fill(dt);
            adaptor1.Fill(dt1);
            dgvData.DataSource = dt;
            dgvNot.DataSource = dt1;
            adaptor.Dispose();
            adaptor1.Dispose();
            baglanti.Close();
        }
        private void frmAkademisyen_Load(object sender, EventArgs e)
        {
            Listele();
            btnGuncelle.Enabled = false;
            btnKaydet.Enabled = false;
            txtAkademisyenId.Visible = false;
        }
        
        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvData.Rows[e.RowIndex];
                txtAd.Text = row.Cells["ad"].Value.ToString();
                txtSoyad.Text = row.Cells["soyad"].Value.ToString();
                txtTc.Text = row.Cells["tc_kimlik"].Value.ToString();
                txtStajKodu.Text = row.Cells["staj_kodu"].Value.ToString();
            }
        }
        
        private void NotToplam()
        {
            ComboBox[] comboboxlar = { cbİsyeriDeg, cbSekilBicimYazimDili, cbSoru1, cbSoru2, cbSoru3, cbSoru4, cbSoru5, cbSoru6, cbSoru7, cbSoru8, cbSoru9, cbSoru10, cbSoru11, cbSoru12, cbSoru13, cbSoru14, cbSoru15, cbSoru16, cbSoru17, cbSoru18, cbSoru19 };
            foreach(ComboBox cb in comboboxlar)
            {
                toplam += cb.SelectedItem != null ? Convert.ToInt32(cb.SelectedItem):0 ;
            }
            if(toplam < 50)
            {
                MessageBox.Show("Öğrenci Puanı " + toplam + " Öğrenci durumunu 'Başarısız' olarak seçin");
            }
            else
            {
                MessageBox.Show("Öğrenci Puanı " + toplam + " Öğrenci durumunu 'Başarılı' olarak seçin");
            }
            txtToplam.Text = toplam.ToString();
        }

        private void cbBasariDurumu_SelectedIndexChanged(object sender, EventArgs e)
        {
            NotToplam();
        }
        private bool GerekliAlanlarDoluMu()
        {
            if (string.IsNullOrEmpty(txtTc.Text) || cbİsyeriDeg.SelectedItem == null || cbSekilBicimYazimDili.SelectedItem == null ||
                cbSoru1.SelectedItem == null || cbSoru2.SelectedItem == null || cbSoru3.SelectedItem == null || cbSoru4.SelectedItem == null ||
                cbSoru5.SelectedItem == null || cbSoru6.SelectedItem == null || cbSoru7.SelectedItem == null || cbSoru8.SelectedItem == null ||
                cbSoru9.SelectedItem == null || cbSoru10.SelectedItem == null || cbSoru11.SelectedItem == null || cbSoru12.SelectedItem == null ||
                cbSoru13.SelectedItem == null || cbSoru14.SelectedItem == null || cbSoru15.SelectedItem == null || cbSoru16.SelectedItem == null ||
                cbSoru17.SelectedItem == null || cbSoru18.SelectedItem == null || cbSoru19.SelectedItem == null || string.IsNullOrEmpty(cbBasariDurumu.Text) ||
                string.IsNullOrEmpty(txtToplam.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!GerekliAlanlarDoluMu())
            {
                return;
            }
            else
            {
                baglanti.Open();
                int ogrenciID = ogrenciIdSorgusu();
                akademisyenID = logInAkademisyenId;//giriş yapan akademisyen ıd değeri

                MySqlCommand OgrenciNotEkleme = new MySqlCommand();
                OgrenciNotEkleme.CommandText = "INSERT INTO ogrenci_not (ogrenci_id, akademisyen_id, isyeri_degerlendirmesi, sekil_bicim_yazimdili, soru1, soru2, soru3, soru4, soru5, soru6, soru7, soru8, soru9, soru10, soru11, soru12, soru13, soru14, soru15, soru16, soru17, soru18, soru19, basari_durumu, toplam_not) " +
                    "VALUES (@ogrenci_id, @akademisyen_id, @isyeri_degerlendirmesi, @sekil_bicim_yazimdili, @soru1, @soru2, @soru3, @soru4, @soru5, @soru6, @soru7, @soru8, @soru9, @soru10, @soru11, @soru12, @soru13, @soru14, @soru15, @soru16, @soru17, @soru18, @soru19, @basari_durumu, @toplam_not)";
                OgrenciNotEkleme.Parameters.AddWithValue("@ogrenci_id", ogrenciID);
                OgrenciNotEkleme.Parameters.AddWithValue("@akademisyen_id", akademisyenID);
                OgrenciNotEkleme.Parameters.AddWithValue("@isyeri_degerlendirmesi", cbİsyeriDeg.SelectedItem);
                OgrenciNotEkleme.Parameters.AddWithValue("@sekil_bicim_yazimdili", cbSekilBicimYazimDili.SelectedItem);
                OgrenciNotEkleme.Parameters.AddWithValue("@soru1", cbSoru1.SelectedItem);
                OgrenciNotEkleme.Parameters.AddWithValue("@soru2", cbSoru2.SelectedItem);
                OgrenciNotEkleme.Parameters.AddWithValue("@soru3", cbSoru3.SelectedItem);
                OgrenciNotEkleme.Parameters.AddWithValue("@soru4", cbSoru4.SelectedItem);
                OgrenciNotEkleme.Parameters.AddWithValue("@soru5", cbSoru5.SelectedItem);
                OgrenciNotEkleme.Parameters.AddWithValue("@soru6", cbSoru6.SelectedItem);
                OgrenciNotEkleme.Parameters.AddWithValue("@soru7", cbSoru7.SelectedItem);
                OgrenciNotEkleme.Parameters.AddWithValue("@soru8", cbSoru8.SelectedItem);
                OgrenciNotEkleme.Parameters.AddWithValue("@soru9", cbSoru9.SelectedItem);
                OgrenciNotEkleme.Parameters.AddWithValue("@soru10", cbSoru10.SelectedItem);
                OgrenciNotEkleme.Parameters.AddWithValue("@soru11", cbSoru11.SelectedItem);
                OgrenciNotEkleme.Parameters.AddWithValue("@soru12", cbSoru12.SelectedItem);
                OgrenciNotEkleme.Parameters.AddWithValue("@soru13", cbSoru13.SelectedItem);
                OgrenciNotEkleme.Parameters.AddWithValue("@soru14", cbSoru14.SelectedItem);
                OgrenciNotEkleme.Parameters.AddWithValue("@soru15", cbSoru15.SelectedItem);
                OgrenciNotEkleme.Parameters.AddWithValue("@soru16", cbSoru16.SelectedItem);
                OgrenciNotEkleme.Parameters.AddWithValue("@soru17", cbSoru17.SelectedItem);
                OgrenciNotEkleme.Parameters.AddWithValue("@soru18", cbSoru18.SelectedItem);
                OgrenciNotEkleme.Parameters.AddWithValue("@soru19", cbSoru19.SelectedItem);
                OgrenciNotEkleme.Parameters.AddWithValue("@basari_durumu", cbBasariDurumu.Text);
                OgrenciNotEkleme.Parameters.AddWithValue("@toplam_not", txtToplam.Text);
                OgrenciNotEkleme.Connection = baglanti;
                OgrenciNotEkleme.ExecuteNonQuery();
                MessageBox.Show("Öğrenci Başarıyla Notlandırıldı");
                OgrenciNotEkleme.Dispose();
                baglanti.Close();
            }
           
        }
        private int ogrenciIdSorgusu()
        {
            string ogrenciIdSorgusu = "SELECT id FROM ogrenci WHERE tc_kimlik = @tc_kimlik";
            MySqlCommand komut = new MySqlCommand(ogrenciIdSorgusu, baglanti);
            komut.Parameters.AddWithValue("@tc_kimlik", txtTc.Text);
            int ogrenciID = -1;
            using (MySqlDataReader okuyucu = komut.ExecuteReader())
            {
                if (okuyucu.Read())
                {
                    ogrenciID = okuyucu.GetInt32(0);
                }
            }
            return ogrenciID;
        }

        private void btnDegerlendirme_Click(object sender, EventArgs e)
        {
            btnKaydet.Enabled = true;
            btnGuncelle.Enabled = false;
        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (!GerekliAlanlarDoluMu())
                {
                    return;
                }
                else
                {
                    baglanti.Open();

                    string ogrenciIdSorgusu = "SELECT id FROM ogrenci WHERE tc_kimlik = @tc_kimlik";
                    MySqlCommand komut = new MySqlCommand(ogrenciIdSorgusu, baglanti);
                    komut.Parameters.AddWithValue("@tc_kimlik", txtTc.Text);
                    int ogrenciID = -1;
                    int seciliAkademisyenId = -1;

                    using (MySqlDataReader okuyucu = komut.ExecuteReader())
                    {
                        if (okuyucu.Read())
                        {
                            ogrenciID = okuyucu.GetInt32(0);
                        }
                    }

                    if (dgvNot.SelectedCells.Count > 0)
                    {
                        int selectedRowIndex = dgvNot.SelectedCells[0].RowIndex;
                        DataGridViewRow selectedRow = dgvNot.Rows[selectedRowIndex];
                        seciliAkademisyenId = Convert.ToInt32(selectedRow.Cells["akademisyen_id"].Value);

                        if (seciliAkademisyenId != logInAkademisyenId)
                        {
                            MessageBox.Show("Bu öğrencinin yetkisi size ait değildir");
                        }
                        else
                        {
                            MySqlCommand OgrenciNotGuncelleme = new MySqlCommand();
                            OgrenciNotGuncelleme.CommandText = "UPDATE ogrenci_not SET isyeri_degerlendirmesi=@isyeri_degerlendirmesi, sekil_bicim_yazimdili=@sekil_bicim_yazimdili, soru1=@soru1, soru2=@soru2, soru3=@soru3, soru4=@soru4, soru5=@soru5, soru6=@soru6, soru7=@soru7, soru8=@soru8, soru9=@soru9, soru10=@soru10, soru11=@soru11, soru12=@soru12, soru13=@soru13, soru14=@soru14, soru15=@soru15, soru16=@soru16, soru17=@soru17, soru18=@soru18, soru19=@soru19, basari_durumu=@basari_durumu, toplam_not=@toplam_not WHERE ogrenci_id=@ogrenci_id AND akademisyen_id=@akademisyen_id";
                            OgrenciNotGuncelleme.Parameters.AddWithValue("@ogrenci_id", ogrenciID);
                            OgrenciNotGuncelleme.Parameters.AddWithValue("@akademisyen_id", akademisyenID);
                            OgrenciNotGuncelleme.Parameters.AddWithValue("@isyeri_degerlendirmesi", cbİsyeriDeg.SelectedItem);
                            OgrenciNotGuncelleme.Parameters.AddWithValue("@sekil_bicim_yazimdili", cbSekilBicimYazimDili.SelectedItem);
                            OgrenciNotGuncelleme.Parameters.AddWithValue("@soru1", cbSoru1.SelectedItem);
                            OgrenciNotGuncelleme.Parameters.AddWithValue("@soru2", cbSoru2.SelectedItem);
                            OgrenciNotGuncelleme.Parameters.AddWithValue("@soru3", cbSoru3.SelectedItem);
                            OgrenciNotGuncelleme.Parameters.AddWithValue("@soru4", cbSoru4.SelectedItem);
                            OgrenciNotGuncelleme.Parameters.AddWithValue("@soru5", cbSoru5.SelectedItem);
                            OgrenciNotGuncelleme.Parameters.AddWithValue("@soru6", cbSoru6.SelectedItem);
                            OgrenciNotGuncelleme.Parameters.AddWithValue("@soru7", cbSoru7.SelectedItem);
                            OgrenciNotGuncelleme.Parameters.AddWithValue("@soru8", cbSoru8.SelectedItem);
                            OgrenciNotGuncelleme.Parameters.AddWithValue("@soru9", cbSoru9.SelectedItem);
                            OgrenciNotGuncelleme.Parameters.AddWithValue("@soru10", cbSoru10.SelectedItem);
                            OgrenciNotGuncelleme.Parameters.AddWithValue("@soru11", cbSoru11.SelectedItem);
                            OgrenciNotGuncelleme.Parameters.AddWithValue("@soru12", cbSoru12.SelectedItem);
                            OgrenciNotGuncelleme.Parameters.AddWithValue("@soru13", cbSoru13.SelectedItem);
                            OgrenciNotGuncelleme.Parameters.AddWithValue("@soru14", cbSoru14.SelectedItem);
                            OgrenciNotGuncelleme.Parameters.AddWithValue("@soru15", cbSoru15.SelectedItem);
                            OgrenciNotGuncelleme.Parameters.AddWithValue("@soru16", cbSoru16.SelectedItem);
                            OgrenciNotGuncelleme.Parameters.AddWithValue("@soru17", cbSoru17.SelectedItem);
                            OgrenciNotGuncelleme.Parameters.AddWithValue("@soru18", cbSoru18.SelectedItem);
                            OgrenciNotGuncelleme.Parameters.AddWithValue("@soru19", cbSoru19.SelectedItem);
                            OgrenciNotGuncelleme.Parameters.AddWithValue("@basari_durumu", cbBasariDurumu.Text);
                            OgrenciNotGuncelleme.Parameters.AddWithValue("@toplam_not", txtToplam.Text);
                            OgrenciNotGuncelleme.Connection = baglanti;
                            OgrenciNotGuncelleme.ExecuteNonQuery();
                            MessageBox.Show("Öğrenci Notları Başarıyla Güncellendi");
                            OgrenciNotGuncelleme.Dispose();
                            baglanti.Close();
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }

        }

        private void dgvNot_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNot.Rows[e.RowIndex];
                cbİsyeriDeg.Text = row.Cells["isyeri_degerlendirmesi"].Value.ToString();
                cbSekilBicimYazimDili.Text = row.Cells["sekil_bicim_yazimdili"].Value.ToString();
                cbSoru1.Text = row.Cells["Soru1"].Value.ToString();
                cbSoru2.Text = row.Cells["Soru2"].Value.ToString();
                cbSoru3.Text = row.Cells["Soru3"].Value.ToString();
                cbSoru4.Text = row.Cells["Soru4"].Value.ToString();
                cbSoru5.Text = row.Cells["Soru5"].Value.ToString();
                cbSoru6.Text = row.Cells["Soru6"].Value.ToString();
                cbSoru7.Text = row.Cells["Soru7"].Value.ToString();
                cbSoru8.Text = row.Cells["Soru8"].Value.ToString();
                cbSoru9.Text = row.Cells["Soru9"].Value.ToString();
                cbSoru10.Text = row.Cells["Soru10"].Value.ToString();
                cbSoru11.Text = row.Cells["Soru11"].Value.ToString();
                cbSoru12.Text = row.Cells["Soru12"].Value.ToString();
                cbSoru13.Text = row.Cells["Soru13"].Value.ToString();
                cbSoru14.Text = row.Cells["Soru14"].Value.ToString();
                cbSoru15.Text = row.Cells["Soru15"].Value.ToString();
                cbSoru16.Text = row.Cells["Soru16"].Value.ToString();
                cbSoru17.Text = row.Cells["Soru17"].Value.ToString();
                cbSoru18.Text = row.Cells["Soru18"].Value.ToString();
                cbSoru19.Text = row.Cells["Soru19"].Value.ToString();
            }
        }

        private void btnTabloGuncelle_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string silmeSorgusu = "DELETE FROM ogrenci_not WHERE ogrenci_id = @ogrenci_id";
            MySqlCommand silmeKomut = new MySqlCommand(silmeSorgusu, baglanti);
            int ogrenciID = ogrenciIdSorgusu();
            silmeKomut.Parameters.AddWithValue("@ogrenci_id",ogrenciID);
            silmeKomut.ExecuteNonQuery();
            silmeKomut.Dispose();
            baglanti.Close();
            MessageBox.Show("Öğrenci Başarıyla silindi");
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

        private void txtAraAd_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dgvData.DataSource;
            bs.Filter = "ad LIKE '%" + txtAraAd.Text + "%'";
            dgvData.DataSource = bs;
        }

        private void txtAraSoyad_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dgvData.DataSource;
            bs.Filter = "soyad LIKE '%" + txtAraSoyad.Text + "%'";
            dgvData.DataSource = bs;
        }

        private void txtAraİD_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvData.DataSource;
            dt.DefaultView.RowFilter = string.Format("Convert(id, 'System.String') LIKE '%{0}%'", txtAraİD.Text);

        }

        private void txtAraNotİd_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dgvNot.DataSource;
            dt.DefaultView.RowFilter = string.Format("Convert(ogrenci_id, 'System.String') LIKE '%{0}%'", txtAraNotİd.Text);
        }

        private void btnDuzeltme_Click(object sender, EventArgs e)
        {
            btnKaydet.Enabled = false;
            btnGuncelle.Enabled = true;
        }
    }
}
