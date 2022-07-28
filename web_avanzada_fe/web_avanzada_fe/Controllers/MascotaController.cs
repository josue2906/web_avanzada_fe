using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using web_avanzada_fe.Entities;
using web_avanzada_fe.Models;

namespace web_avanzada_fe.Controllers
{
    public class MascotaController : Controller
    {
        private readonly IConfiguration _config;
        MascotaModel model = new MascotaModel();
        RolModel rol = new RolModel();

        public MascotaController(IConfiguration config)
        {
            _config = config;
        }


        [HttpGet]
        public ActionResult ListaMascotas()
        {
            string token = HttpContext.Session.GetString("Token");
            var datos = model.ConsultarMascotas(_config, token);
            return View(datos);
        }



        [HttpGet]
        public ActionResult RegistrarMascota()
        {
            string token = HttpContext.Session.GetString("Token");
            return View(new Mascota());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarMascota(Mascota mascota)
        {
            try
            {
                string token = HttpContext.Session.GetString("Token");
                var datos = model.RegistrarMascota(_config, token, mascota);
                return RedirectToAction("ListaMascotas", "Mascota");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult ActualizarMascota(int idMascota)
        {
            string token = HttpContext.Session.GetString("Token");
            var datos = model.ConsultarMascota(_config, token, idMascota);
            return View(datos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActualizarMascota(Mascota mascota)
        {
            try
            {
                string token = HttpContext.Session.GetString("Token");
                model.ActualizarMascota(_config, token, mascota);
                return RedirectToAction("ListaMascotas", "Mascota");
            }
            catch
            {
                return View();
            }
        }
    }
}
