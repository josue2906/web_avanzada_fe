using Microsoft.AspNetCore.Mvc;
using web_avanzada_fe.Entities;
using web_avanzada_fe.Models;

namespace web_avanzada_fe.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _config;
        LoginModel modelo = new LoginModel();
        Empleado persona = new Empleado();

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public IActionResult InicioSesion()
        {
            try
            {

                persona = new Empleado();
                return View(persona);
            }
            catch (Exception)
            {
                return View("Error",new ErrorViewModel());
            }
        }

        [HttpPost]
        public IActionResult InicioSesion(Empleado empleado)
        {
            try
            {
                var respuesta = modelo.ValidarUsuario(empleado, _config);
                if (respuesta != null)
                {
                    HttpContext.Session.SetString("Token", respuesta.Token);
                    HttpContext.Session.SetString("Cedula", respuesta.idEmpleado);
                    HttpContext.Session.SetString("Rol", respuesta.idRol.ToString());
                    HttpContext.Session.SetString("Nombre", respuesta.NombreE+" "+respuesta.ApellidosE);
  
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    HttpContext.Session.Clear();
                    ViewBag.IniciarSesionError = "No se ha podido iniciar sesión, intentelo de nuevo.";
                    return View();
                }
            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel());
            }
        }

        [HttpGet]
        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("InicioSesion", "Login");
        }

    }
}

