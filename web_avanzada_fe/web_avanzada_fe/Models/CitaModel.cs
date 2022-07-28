using web_avanzada_fe.Entities;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace web_avanzada_fe.Models
{
    public class CitaModel
    {     
        public List<Cita>? ConsultarCitas(IConfiguration _config, string token)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Cita/MostrarTodasCitas";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<List<Cita>>().Result;
                }
                return new List<Cita>();
            }
        }

        public Cita? ConsultarUnaCita(IConfiguration _config, string token, int idCita)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Cita/MostrarUnaCita?idCita=" + idCita;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<Cita>().Result;
                }
                return new Cita();
            }
        }
        
        public string? RegistrarCita(IConfiguration _config, string token, Cita cita)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;
            string resultado = string.Empty;

            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(cita);
                string rutaServicio = rutaBase + "api/Cita/RegistrarCita";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.PostAsync(rutaServicio, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    resultado = respuesta.Content.ReadAsStringAsync().Result;
                    return resultado;
                }
                return resultado;
            }
        }
        
        public string? ActualizarCita(IConfiguration _config, string token, Cita cita)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;
            string resultado = string.Empty;

            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(cita);
                string rutaServicio = rutaBase + "api/Cita/ActualizarCita";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.PutAsync(rutaServicio, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    resultado = respuesta.Content.ReadAsStringAsync().Result;
                    return resultado;
                }
                return resultado;
            }
        }
        
        public string? CancelarCita(IConfiguration _config, string token, int idCita)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;
            string resultado = string.Empty;

            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(idCita);
                string rutaServicio = rutaBase + "api/Cita/CancelarCita?idCita=" + idCita;

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.PutAsync(rutaServicio, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    resultado = respuesta.Content.ReadAsStringAsync().Result;
                    return resultado;
                }
                return resultado;
            }
        }
        
        public List<Servicio>? ConsultarServicios(IConfiguration _config, string token)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Servicio/MostrarServicios";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<List<Servicio>>().Result;
                }
                return new List<Servicio>();
            }
        }

        public List<SelectListItem> SeleccionServicios(IConfiguration _config, string token)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            var datos = ConsultarServicios(_config, token);
            foreach (var item in datos)
            {
                list.Add(new SelectListItem { Value = item.idServicio.ToString(), Text = item.DescripcionServicio});
            }
            return list;
        }

        public List<SelectListItem> SeleccionMascotas(IConfiguration _config, string token)
        {
            MascotaModel model = new MascotaModel();
            List<SelectListItem> list = new List<SelectListItem>();

            var datos = model.ConsultarMascotas(_config, token);
            foreach (var item in datos)
            {
                list.Add(new SelectListItem { Value = item.IdMascota.ToString(), Text = item.NombreM });
            }
            return list;
        }
        public List<SelectListItem> SeleccionEmpleados(IConfiguration _config, string token)
        {
            EmpleadoModel model = new EmpleadoModel();
            List<SelectListItem> list = new List<SelectListItem>();

            var datos = model.ConsultarEmpleados(_config, token);
            foreach (var item in datos)
            {
                list.Add(new SelectListItem { Value = item.idEmpleado.ToString(), Text = item.NombreE +" "+ item.ApellidosE });
            }
            return list;
        }
    }
}
