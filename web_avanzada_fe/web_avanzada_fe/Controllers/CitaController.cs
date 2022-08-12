using Microsoft.AspNetCore.Mvc;
using web_avanzada_fe.Entities;
using web_avanzada_fe.Models;

namespace web_avanzada_fe.Controllers
{
    [SesionUsuario]
    [ValidarVeterinario]
    public class CitaController : Controller
    {

        private readonly IConfiguration _config;
        CitaModel model = new CitaModel();

        public CitaController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public ActionResult ListaCitas()
        {
            string token = HttpContext.Session.GetString("Token");
            var datos = model.ConsultarCitas(_config, token);
            return View(datos);
        }

        [HttpGet]
        public ActionResult RegistrarCita()
        {
            string token = HttpContext.Session.GetString("Token");
            ViewBag.Mascotas = model.SeleccionMascotas(_config, token);
            ViewBag.Empleados = model.SeleccionEmpleados(_config, token);
            ViewBag.Servicios = model.SeleccionServicios(_config, token);
            return View(new Cita());
        }

        [HttpPost]
        public ActionResult RegistrarCita(Cita cita)
        {
            try
            {
                string token = HttpContext.Session.GetString("Token");
                string datos= model.RegistrarCita(_config, token, cita);
                return RedirectToAction("ListaCitas", "Cita");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult ActualizarCita(int idCita)
        {
            string token = HttpContext.Session.GetString("Token");
            ViewBag.Mascotas = model.SeleccionMascotas(_config, token);
            ViewBag.Empleados = model.SeleccionEmpleados(_config, token);
            ViewBag.Servicios = model.SeleccionServicios(_config, token);
            var datos = model.ConsultarUnaCita(_config, token, idCita);
            return View(datos);
        }

        [HttpPost]
        public ActionResult ActualizarCita(Cita cita)
        {
            try
            {
                string token = HttpContext.Session.GetString("Token");
                string datos= model.ActualizarCita(_config, token, cita);
                return RedirectToAction("ListaCitas", "Cita");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult CancelarCita(int idCita)
        {
            try
            {
                string token = HttpContext.Session.GetString("Token");
                model.CancelarCita(_config, token, idCita);
                return RedirectToAction("ListaCitas", "Cita");
            }
            catch
            {
                return View();
            }
        }
    }
}
