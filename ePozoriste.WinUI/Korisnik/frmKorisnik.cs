using ePozoriste.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ePozoriste.WinUI.Korisnik
{
    public partial class frmKorisnik : Form
    {
        APIService _apiService = new APIService("korisnik");
        public frmKorisnik()
        {
            InitializeComponent();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            await Prikazi();

        }

        private async Task Prikazi()
        {
            var search = new KorisnikSearchRequest()
            {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text,
            };

            var list = await _apiService.Get<List<Model.Korisnik>>(search);
            dgvKorisnik.AutoGenerateColumns = false;
            dgvKorisnik.DataSource = list;
        }

        private void dgvKorisnici_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var korisnikId = int.Parse(dgvKorisnik.SelectedRows[0].Cells[0].Value.ToString());

            frmKorisnikDetails frm = new frmKorisnikDetails(korisnikId);
            frm.Show();
        }

        private async void btnDodaj_Click(object sender, EventArgs e)
        {
            Model.Korisnik korisnik = new Model.Korisnik();
            var username = APIService.Username;
            List<Model.Korisnik> lista = await _apiService.Get<List<Model.Korisnik>>(null);
            foreach (var k in lista)
            {
                if (k.KorisnickoIme == username)
                {
                    korisnik = k;
                    break;
                }
            }
            if (korisnik.Uloge != null && korisnik.Uloge.Contains("Administrator"))
            {
                frmKorisnikDetails frm = new frmKorisnikDetails();
                frm.ShowDialog();
                await Prikazi();
            }
            else
            {
                MessageBox.Show("Nemate pravo pristupa!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
