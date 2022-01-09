using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLiveryMobile.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheLiveryMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class detalii : ContentPage
    {
        string _awb="nuba";

        public detalii(string awb)
        {

            InitializeComponent();
            //OnAppearing();
            //BindingContext = this;
            _awb = awb;
            
        }

        private string myCurier;
        public string MyCurier
        {
            get { return myCurier; }
            set
            {
                myCurier = value;
                //OnPropertyChanged(nameof(MyStringProperty)); // Notify that there was a change on this property
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var comenzi = await App.Database.GetComenziAsync();
            var comandaCeruta = comenzi.Where(x => x.AWB.Equals(_awb));
            if (!comandaCeruta.Any())
            {
                error.Text = "Comanda cu AWB-ul introdus nu exista!";
                return;
            }
            //myCurier = comandaCeruta.FirstOrDefault().Curier.Nume_complet;
            //idcurier.Text = comandaCeruta.First().Curier.Nume_complet;
            listView.ItemsSource = comandaCeruta;
        }

        async void inchidePaginaClick(object sender,EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}