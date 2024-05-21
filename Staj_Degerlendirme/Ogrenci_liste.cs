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
    public partial class Ogrenci_liste : Form
    {
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;DataBase=staj_degerlendirme;user=root");

        public Ogrenci_liste()
        {
            InitializeComponent();
        }
        private void Listele()
        {
            MySqlDataAdapter adaptor = new MySqlDataAdapter("SELECT * FROM ogrenci", baglanti);
            DataTable dt = new DataTable();
            dt.Clear();
            adaptor.Fill(dt);
            dgvData.DataSource = dt;
            adaptor.Dispose();
            baglanti.Close();
        }
        private void Ogrenci_liste_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
