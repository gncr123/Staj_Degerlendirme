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
    public partial class frmGirisSecenek : Form
    {
        public frmGirisSecenek()
        {
            InitializeComponent();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Çıkış Yapmak İstediğinizden Emin misiniz?","Çıkış Yap",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void btnSekreterGiris_Click(object sender, EventArgs e)
        {
            frmSekreterGiris frmSekreterGiris = new frmSekreterGiris();
            this.Hide();
            frmSekreterGiris.ShowDialog();
            this.Close();
            
        }

        private void btnAkademisyenGiris_Click(object sender, EventArgs e)
        {
            AkademisyenGiris akademisyenGiris = new AkademisyenGiris();
            this.Hide();
            akademisyenGiris.ShowDialog();
            this.Close();
        }
    }
}
