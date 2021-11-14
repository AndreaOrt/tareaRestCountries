using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace PM2RestApiAD
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnconsume_Clicked(System.Object sender, System.EventArgs e)
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                List<Models.Persona> listapersonas = new List<Models.Persona>();

                listapersonas = await Controller.PersonasController.getpersonas();

                lstPersonas.ItemsSource = listapersonas;
            }
            else
            {
                await DisplayAlert("Error", "Verifique su conexión de Internet", "OK");
            }
        }
    }
}
