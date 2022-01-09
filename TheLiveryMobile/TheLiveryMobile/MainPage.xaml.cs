using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TheLiveryMobile
{
    public partial class MainPage : ContentPage
    {

        public string username;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        async void OnButtonClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new detalii(entry.Text));
            //test.Text = entry.Text;
        } 
    }
}
