using Acr.UserDialogs;
using ePozoriste.Model;
using ePozoriste.Model.Requests;
using Pozoriste.Mobile.Models;
using Pozoriste.Mobile.Views;
using Prism.Commands;
using Prism.Mvvm;
using Stripe;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pozoriste.Mobile.ViewModels
{
    public class PaymentViewModel : BindableBase
    {
        private APIService _rezervacijaService = new APIService("Rezervacija");
        private APIService _korisnikService = new APIService("Korisnik");
        #region Variable

        private CreditCardModel _creditCardModel;
        private TokenService Tokenservice;
        private Token stripeToken;
        private bool _isCarcValid;
        private bool _isTransactionSuccess;
        private string _expMonth;
        private string _expYear;
        private string _title;


        #endregion Variable

        #region Public Property
        private string StripeTestApiKey = "pk_test_51KOeiNKLWdFIbIHhP9X7BsEkKLbhvPx70Dz8ipE5xAxHD45uRFROYLfSuPp9wDKczSjF3fN3ThmSZvidtqgWJ5MC00rLpeVGPO";
        private string StripeSecretApiKey = "sk_test_51KOeiNKLWdFIbIHhNr6DjSWhdHCbW6pMrI4csfEblTc53M45AJ7dcH46o41kihzfaC9K3sD4zSdy0TPYfN7QmIG000CyFuLTMS";
        public string ExpMonth
        {
            get { return _expMonth; }
            set { SetProperty(ref _expMonth, value); }
        }

        public bool IsCarcValid
        {
            get { return _isCarcValid; }
            set { SetProperty(ref _isCarcValid, value); }
        }

        public bool IsTransactionSuccess
        {
            get { return _isTransactionSuccess; }
            set { SetProperty(ref _isTransactionSuccess, value); }
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string ExpYear
        {
            get { return _expYear; }
            set { SetProperty(ref _expYear, value); }
        }
        decimal _iznos = 0;
        public decimal Iznos
        {
            get { return _iznos; }
            set { SetProperty(ref _iznos, value); }
        }

        public CreditCardModel CreditCardModel
        {
            get { return _creditCardModel; }
            set { SetProperty(ref _creditCardModel, value); }
        }

        #endregion Public Property

        #region Constructor

        public PaymentViewModel()
        {
            CreditCardModel = new CreditCardModel();
            Title = "Card Details";
        }

        #endregion Constructor

        #region Command

        public DelegateCommand SubmitCommand => new DelegateCommand(async () =>
        {
            CreditCardModel.ExpMonth = Convert.ToInt64(ExpMonth);
            CreditCardModel.ExpYear = Convert.ToInt64(ExpYear);

            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            try
            {
                UserDialogs.Instance.ShowLoading("Procesiranje uplate..");
                await Task.Run(async () =>
                {
                    var Token = await CreateToken();
                    Console.Write("Payment Gateway" + "Token :" + Token);
                    if (Token != null)
                    {
                        IsTransactionSuccess = await MakePayment(Token);
                    }
                    else
                    {
                        UserDialogs.Instance.Alert("Neispravni podaci za uplatu", null, "OK");
                    }
                });
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert(ex.Message, null, "OK");
            }

            if (IsTransactionSuccess)
            {
                var request = new RezervacijaUpsertRequest
                {
                    BrojRezervacije = Rezervacija.BrojRezervacije,
                    DatumRezervacije = Rezervacija.DatumRezervacije,
                    KupacId = Rezervacija.KupacId,
                    Odobrena = Rezervacija.Odobrena,
                    PrikazivanjeId = Rezervacija.PrikazivanjeId,
                    Placena = true
                };
                var result = await _rezervacijaService.Update<Rezervacija>(Rezervacija.RezervacijaId, request);
                if (result != null)
                {
                    UserDialogs.Instance.Alert("Uspjesno ste izvrsili uplatu rezervacije!", "Payment success", "OK");
                    UserDialogs.Instance.HideLoading();
                    App.Current.MainPage = new NavigationPage(new UlaznicaPage(this.Rezervacija, this.odabranoSjedaloObj));
                }

            }
            else
            {
                UserDialogs.Instance.HideLoading();
            }
        });

        public Rezervacija Rezervacija { get; set; }
        public Sjediste odabranoSjedaloObj { get; set; }

        #endregion Command

        #region Method

        private async Task<string> CreateToken()
        {
            try
            {
                Korisnik korisnik = null;
                var username = APIService.Username;
                List<Korisnik> lista = await _korisnikService.Get<List<Korisnik>>(null);
                foreach (var k in lista)
                {
                    if (k.KorisnickoIme == username)
                    {
                        korisnik = k;
                        break;
                    }
                }

                StripeConfiguration.SetApiKey(StripeTestApiKey);
                var service = new ChargeService();
                var Tokenoptions = new TokenCreateOptions
                {
                    Card = new TokenCardOptions
                    {
                        Number = CreditCardModel.Number,
                        ExpYear = CreditCardModel.ExpYear,
                        ExpMonth = CreditCardModel.ExpMonth,
                        Cvc = CreditCardModel.Cvc,
                        Name = korisnik != null ? korisnik.KorisnickoIme : "Unknown user",
                        AddressLine1 = "Adresa 1",
                        AddressLine2 = "Adresa 2",
                        AddressCity = "Mostar",
                        AddressZip = "88000",
                        AddressState = "HNK",
                        AddressCountry = "Bosnia and Herzegovina",
                        Currency = "BAM",
                    }
                };

                Tokenservice = new TokenService();
                stripeToken = Tokenservice.Create(Tokenoptions);
                return stripeToken.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> MakePayment(string token)
        {
            Korisnik korisnik = null;
            var username = APIService.Username;
            List<Korisnik> lista = await _korisnikService.Get<List<Korisnik>>(null);
            foreach (var k in lista)
            {
                if (k.KorisnickoIme == username)
                {
                    korisnik = k;
                    break;
                }
            }

            try
            {
                StripeConfiguration.SetApiKey(StripeSecretApiKey);
                var options = new ChargeCreateOptions
                {
                    Amount = ((long)Iznos) * 100,
                    Currency = "BAM",
                    Description = "Charge for " + (korisnik != null ? korisnik.KorisnickoIme : "Unknown user"),
                    Source = stripeToken.Id,
                    StatementDescriptor = "Opis",
                    Capture = true,
                    ReceiptEmail = "epozoriste@gmail.com",
                };
                //Make Payment
                var service = new ChargeService();
                Charge charge = service.Create(options);
                return true;
            }
            catch (Exception ex)
            {
                Console.Write("Payment Gatway (CreateCharge)" + ex.Message);
                throw ex;
            }
        }

        private bool ValidateCard()
        {
            if (CreditCardModel.Number.Length == 16 && ExpMonth.Length == 2 && ExpYear.Length == 2 && CreditCardModel.Cvc.Length == 3)
            {
                return true;
            }
            return false;
        }

        #endregion Method
    }
}