using JN_Aplicacion.Models;
using System.Net.Http.Headers;
using web_avanzada_fe.Entities;

namespace web_avanzada_fe.Models
{
    public class EmpleadoModel
    {
    
        public List<Empleado>? ConsultarEmpleados(IConfiguration _config, string token)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Empleado/MostrarEmpleados";
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<List<Empleado>>().Result;
                }

                return new List<Empleado>();
            }
        }

        public Empleado? ConsultarEmpleado(IConfiguration _config, string token, string cedula)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Empleado/MostrarUnEmpleado?idEmpleado=" + cedula;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<Empleado>().Result;
                }

                return new Empleado();
            }
        }

        public Empleado? RegistrarEmpleado(IConfiguration _config, string token, Empleado empleado)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(empleado);
                string rutaServicio = rutaBase + "api/Empleado/RegistrarEmpleado";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.PostAsync(rutaServicio, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<Empleado>().Result;
                }

                return new Empleado();
            }
        }
        public Empleado? ActualizarEmpleado(IConfiguration _config, string token, Empleado empleado)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(empleado);
                string rutaServicio = rutaBase + "api/Empleado/ActualizarEmpleado";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.PutAsync(rutaServicio, body).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<Empleado>().Result;
                }

                return new Empleado();
            }
        }
        public Empleado? EliminarEmpleado(IConfiguration _config, string token, string cedula)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;

            using (var client = new HttpClient())
            {
                string rutaServicio = rutaBase + "api/Empleado/EliminarEmpleado?idEmpleado=" + cedula;
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.DeleteAsync(rutaServicio).GetAwaiter().GetResult();

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadFromJsonAsync<Empleado>().Result;
                }

                return new Empleado();
            }
        }
    }
}
