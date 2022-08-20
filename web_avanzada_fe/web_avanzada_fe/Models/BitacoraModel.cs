using System.Data;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Rendering;
using web_avanzada_fe.Entities;


namespace web_avanzada_fe.Models

{
    public class BitacoraModel
    {
        public List<Bitacora>? MostrarTodasBitacoras(IConfiguration _config, string token)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;
            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Bitacora/MostrarBitacora";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();
                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<List<Bitacora>>().Result;
                }
                return new List<Bitacora>();
            }
        }
        public Bitacora? RegistrarBitacora(IConfiguration _config, string token, Bitacora bitacora)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(bitacora);
                string rutaServicio = rutaBase + "api/Bitacora/RegistrarBitacora";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.PostAsync(rutaServicio, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<Bitacora>().Result;
                }

                return new Bitacora();
            }
        }
    }
}
