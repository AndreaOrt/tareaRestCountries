using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PM2RestApiAD
{
    public partial class CountriesPage : ContentPage
    {
        public CountriesPage()
        {
            InitializeComponent();
        }

        /*private async void btnGetCountries_Clicked(System.Object sender, System.EventArgs e)
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                List<Models.Countries.CountriesRest> listapersonas = new List<Models.Countries.CountriesRest>();

                listapersonas = await Controller.CountriesController.getcountries();
            }
            else
            {
                await DisplayAlert("Error", "Verifique su conexión de Internet", "OK");
            }
        }*/

        private async void CmboRegion_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                List<Models.Countries.CountriesRest> listaCountries = new List<Models.Countries.CountriesRest>();

                var region = CmboRegion.Items[CmboRegion.SelectedIndex];

                listaCountries = await Controller.CountriesController.getcountries(region);
                
                ListCountries.ItemsSource = listaCountries;
            }
            else
            {
                await DisplayAlert("Error", "Verifique su conexión de Internet", "OK");
            }
        }

        private async void ListCountries_ItemTapped(System.Object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            Models.Countries.CountriesRest country = (Models.Countries.CountriesRest)e.Item;

            string lenguajes = LanguagesCountry(country.languages);

            await Navigation.PushAsync(new CountryMapPage(country.latlng[0], country.latlng[1], country.population, country.name.common, lenguajes));
        }

        private static String LanguagesCountry(Models.Countries.Languages languagesObj)
        {
            Models.Countries.Languages _lang = languagesObj;

            PropertyInfo[] properties = typeof(Models.Countries.Languages).GetProperties();

            String languagesCountry = "";

            int c = 0;

            foreach (PropertyInfo p in properties)
            {
                if (!System.String.IsNullOrWhiteSpace(Convert.ToString(p.GetValue(_lang))))
                {
                    if (c >= 1)
                    {
                        languagesCountry = $"{languagesCountry}, " + p.GetValue(_lang);
                    }
                    else
                    {
                        languagesCountry += p.GetValue(_lang);
                    }

                    c += 1;
                }
            }

            return languagesCountry;
        }
    }
}
