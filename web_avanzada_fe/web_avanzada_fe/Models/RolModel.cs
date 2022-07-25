using System.Net.Http.Headers;
using web_avanzada_fe.Entities;

namespace web_avanzada_fe.Models
{
    public class RolModel
    {
        public List<Rol>? ConsultarRoles(IConfiguration _config, string token)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Rol/MostrarRoles";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<List<Rol>>().Result;
                }

                return new List<Rol>();
            }
        }
    }
}
