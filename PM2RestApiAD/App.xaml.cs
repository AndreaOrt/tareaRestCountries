using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2RestApiAD
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new CountriesPage());
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
