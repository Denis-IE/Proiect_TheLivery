using System;
using System.IO;
using TheLiveryMobile.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TheLiveryMobile
{
    public partial class App : Application
    {
        static ComenziDatabase database;

        // Create the database connection as a singleton.
        public static ComenziDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ComenziDatabase(Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Comenzi.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
