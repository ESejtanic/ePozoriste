
using ePozoriste.Model.Requests;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ePozoriste.WinUI
{
    public partial class frmLogin : Form
    {
        APIService _service = new APIService("korisnik");
        APIService _servicelogin = new APIService("kupac");

        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            APIService.Username = txtKorisnickoIme.Text;
            APIService.Password = txtLozinka.Text;
            string username = txtKorisnickoIme.Text;
            try
            {
                var listaKorisnika = await _service.Get<List<Model.Korisnik>>(null);
                if(listaKorisnika != null)
                {
                    List<Model.Kupac> lista = await _servicelogin.Get<List<Model.Kupac>>(new KupacSearchRequest { KorisnickoIme = username });
                    if (lista != null && lista.Count > 0)
                    {
                        MessageBox.Show("Nije moguće prijaviti se kao kupac!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Restart();
                    }
                    else
                    {
                        DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show(ex.Message, "Authentikacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
