using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http.Headers;
using web_avanzada_fe.Entities;

namespace web_avanzada_fe.Models
{
    public class MascotaModel
    {
        public List<Mascota>? ConsultarMascotas(IConfiguration _config, string token)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Mascota/MostrarMascotas";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<List<Mascota>>().Result;
                }

                return new List<Mascota>();
            }
        }

        public Mascota? ConsultarMascota(IConfiguration _config, string token, int id)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Mascota/MostrarUnaMascota?id_mascota=" + id;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<Mascota>().Result;
                }

                return new Mascota();
            }
        }

        public Mascota? RegistrarMascota(IConfiguration _config, string token, Mascota mascota)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(mascota);
                string rutaServicio = rutaBase + "api/Mascota/RegistrarMascota";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.PostAsync(rutaServicio, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<Mascota>().Result;
                }

                return new Mascota();
            }
        }
        public Mascota? ActualizarMascota(IConfiguration _config, string token, Mascota mascota)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(mascota);
                string rutaServicio = rutaBase + "api/Mascota/ActualizarMascota";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.PutAsync(rutaServicio, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<Mascota>().Result;
                }

                return new Mascota();
            }
        }
        public List<SelectListItem> SeleccionDueños(IConfiguration _config, string token)
        {
            DuennoModel model = new DuennoModel();
            List<SelectListItem> list = new List<SelectListItem>();

            var datos = model.ConsultarDuennos(_config, token);
            foreach (var item in datos)
            {
                list.Add(new SelectListItem { Value = item.idDueno.ToString(), Text = item.NombreD + " " + item.ApellidosD });
            }
            return list;
        }
    }
}
