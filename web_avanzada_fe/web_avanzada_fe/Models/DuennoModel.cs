using System.Net.Http.Headers;
using web_avanzada_fe.Entities;

namespace web_avanzada_fe.Models
{
    public class DuennoModel
    {
        public List<Duenno>? ConsultarDuennos(IConfiguration _config, string token)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Duenno/MostrarDuennos";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<List<Duenno>>().Result;
                }

                return new List<Duenno>();
            }
        }
        public Duenno? ConsultarDuenno(IConfiguration _config, string token, string idDuenno)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Duenno/MostrarUnDuenno?idDuenno=" + idDuenno;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<Duenno>().Result;
                }

                return new Duenno();
            }
        }
        public Duenno? RegistrarDuenno(IConfiguration _config, string token, Duenno duenno)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(duenno);
                string rutaServicio = rutaBase + "api/Duenno/RegistrarDuenno";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.PostAsync(rutaServicio, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<Duenno>().Result;
                }

                return new Duenno();
            }
        }
        public Duenno? ActualizarDuenno(IConfiguration _config, string token, Duenno duenno)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(duenno);
                string rutaServicio = rutaBase + "api/Duenno/ActualizarDuenno";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.PutAsync(rutaServicio, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<Duenno>().Result;
                }

                return new Duenno();
            }
        }
    }
}
