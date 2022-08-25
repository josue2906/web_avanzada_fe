using Microsoft.AspNetCore.Mvc;
using web_avanzada_fe.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using web_avanzada_fe.Models;

namespace web_avanzada_fe.Controllers
{
    [SesionUsuario]
    [ValidarVeterinario]
    public class CitaController : Controller
    {

        private readonly IConfiguration _config;
        CitaModel model = new CitaModel();
        MascotaModel modelMascota = new MascotaModel();
        EmpleadoModel modelEmpleado = new EmpleadoModel();


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
            ViewBag.Mascotas = new SelectList(modelMascota.ConsultarMascotas(_config, token), "IdMascota", "NombreM");
            ViewBag.Empleados = new SelectList(modelEmpleado.ConsultarEmpleados(_config, token), "idEmpleado", "NombreE");
            ViewBag.Servicios = new SelectList(model.ConsultarServicios(_config, token), "idServicio", "DescripcionServicio");
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
            ViewBag.Mascotas = new SelectList(modelMascota.ConsultarMascotas(_config, token), "IdMascota", "NombreM");
            ViewBag.Empleados = new SelectList(modelEmpleado.ConsultarEmpleados(_config, token), "idEmpleado", "NombreE");
            ViewBag.Servicios = new SelectList(model.ConsultarServicios(_config, token), "idServicio", "DescripcionServicio");
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
