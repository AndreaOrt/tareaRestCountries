using System;
using System.Collections.Generic;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

using Xamarin.Forms;

namespace PM2RestApiAD
{
    public partial class CountryMapPage : ContentPage
    {
        public CountryMapPage(Double lat, Double ln, int poblacion, String pais, String lanCountry)
        {
            InitializeComponent();
            Position position = new Position(lat, ln);
            MapSpan mapSpan = new MapSpan(position, 40, 40);

            var pin = new Pin()
            {
                Position = position,
                Label = pais,
                Address = $"Población: {poblacion} | Lenguajes: {lanCountry}",
                Type = PinType.Place
            };

            Map map = new Map(mapSpan);

            map.Pins.Add(pin);

            Content = map;
        }
    }
}
