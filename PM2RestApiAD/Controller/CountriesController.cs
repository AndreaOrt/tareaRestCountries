using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;

namespace PM2RestApiAD.Controller
{
    public class CountriesController
    {
        public CountriesController()
        {
        }

        public async static Task<List<Models.Countries.CountriesRest>> getcountries(String region)
        {
            List<Models.Countries.CountriesRest> lCountries = new List<Models.Countries.CountriesRest>();

            using (HttpClient client = new HttpClient())
            {
                var respuesta = await client.GetAsync(Controller.Configuraciones.Region.getUrl(region));

                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = respuesta.Content.ReadAsStringAsync().Result;

                    lCountries = JsonConvert.DeserializeObject<List<Models.Countries.CountriesRest>>(contenido); 
                }
            }
            return lCountries;

        }
    }
}
