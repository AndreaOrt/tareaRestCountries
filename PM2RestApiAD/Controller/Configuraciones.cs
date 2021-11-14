using System;
namespace PM2RestApiAD.Controller
{
    public class Configuraciones
    {
        public Configuraciones()
        {
        }

        public const String EndPoint = "https://restcountries.com/v3.1/region/{0}";

        public class Region
        {
            public static String getUrl(String region)
            {
                return String.Format(Configuraciones.EndPoint, region);
            }
        }
    }
}
