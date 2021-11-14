using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace PM2RestApiAD.Controller
{
    public static class PersonasController
    {
        public async static Task<List<Models.Persona>> getpersonas()
        {
            List<Models.Persona> listapersonas = new List<Models.Persona>();

            using (HttpClient client = new HttpClient())
            {
                var respuesta = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");

                if (respuesta.IsSuccessStatusCode)
                {
                    var contenido = respuesta.Content.ReadAsStringAsync().Result;

                    //var lista = JsonConvert.DeserializeObject<List<Models.Persona>>(contenido);
                    listapersonas = JsonConvert.DeserializeObject<List<Models.Persona>>(contenido);
                }
            }
            return listapersonas;

        }
    }
}
