using JN_Aplicacion.Models;
using web_avanzada_fe.Entities;

namespace web_avanzada_fe.Models
{
    public class LoginModel
    {
        UtilitarioModel util = new UtilitarioModel();
        public Empleado? ValidarUsuario(Empleado empleado, IConfiguration _config)
        {
            string rutaBase = _config.GetSection("AppSettings:UrlServicio").Value;
            empleado.Contrasenna = util.Encrypt(_config, empleado.Contrasenna);

            using (var client = new HttpClient())
            {
                JsonContent body = JsonContent.Create(empleado);
                string rutaServicio = rutaBase + "api/Empleado/Autenticar";
                HttpResponseMessage respuesta = client.PostAsync(rutaServicio, body).GetAwaiter().GetResult();


                return (respuesta.IsSuccessStatusCode ? respuesta.Content.ReadFromJsonAsync<Empleado>().Result : null);
            }
        }
    }
}
