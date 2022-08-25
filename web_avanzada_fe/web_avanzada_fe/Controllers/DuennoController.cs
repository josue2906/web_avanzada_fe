using web_avanzada_fe.Models;
using Microsoft.AspNetCore.Mvc;
using web_avanzada_fe.Entities;

namespace web_avanzada_fe.Controllers
{
    [SesionUsuario]
    [ValidarVeterinario]
    public class DuennoController : Controller
    {
        private readonly IConfiguration _config;
        DuennoModel model = new DuennoModel();

        public DuennoController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public ActionResult ListaDuennos()
        {
            string token = HttpContext.Session.GetString("Token");
            var datos = model.ConsultarDuennos(_config, token);
            return View(datos);
        }

        [HttpGet]
        public ActionResult RegistrarDuenno()
        {
            return View(new Duenno());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarDuenno(Duenno duenno)
        {
            try
            {
                string token = HttpContext.Session.GetString("Token");
                var existe = model.ConsultarDuenno(_config, token, duenno.idDueno);
                if (existe.idDueno != "")
                {
                    ViewBag.mensajeErrorDuenno = "Dueño ya existente";
                    return View();
                }
                var datos = model.RegistrarDuenno(_config, token, duenno);
                if (datos.idDueno == "")
                {
                    ViewBag.mensajeErrorDuenno = "No se ha podido crear el dueño";
                    return View();
                }

                return RedirectToAction("ListaDuennos", "Duenno");
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult ActualizarDuenno(string idDuenno)
        {
            string token = HttpContext.Session.GetString("Token");
            var datos = model.ConsultarDuenno(_config, token, idDuenno);
            return View(datos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActualizarDuenno(Duenno duenno)
        {
            try
            {
                string token = HttpContext.Session.GetString("Token");
                model.ActualizarDuenno(_config, token, duenno);
                return RedirectToAction("ListaDuennos", "Duenno");
            }
            catch
            {
                return View();
            }
        }
    }
}
