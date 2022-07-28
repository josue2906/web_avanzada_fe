using JN_Aplicacion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using web_avanzada_fe.Entities;
using web_avanzada_fe.Models;

namespace web_avanzada_fe.Controllers
{
  [SesionUsuario]
    public class EmpleadoController : Controller
    {
        
        private readonly IConfiguration _config;
        EmpleadoModel model = new EmpleadoModel();
        RolModel rol = new RolModel();

        public EmpleadoController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public ActionResult ListaEmpleados()
        {
            string token = HttpContext.Session.GetString("Token");
            var datos = model.ConsultarEmpleados(_config, token);
            return View(datos);
        }



        [HttpGet]
        public ActionResult RegistrarEmpleado()
        {
            string token = HttpContext.Session.GetString("Token");
            ViewBag.listaRoles = new SelectList(rol.ConsultarRoles(_config, token),"idRol", "DescripcionRol");
            return View( new Empleado());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarEmpleado(Empleado empleado)
        {
            try
            {
                string token = HttpContext.Session.GetString("Token");
                var datos = model.RegistrarEmpleado(_config, token, empleado);
                return RedirectToAction("ListaEmpleados", "Empleado");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]// GET: PersonaController/Edit/5
        public ActionResult ActualizarEmpleado(string idEmpleado)
        {
            string token = HttpContext.Session.GetString("Token");
            ViewBag.listaRoles = new SelectList(rol.ConsultarRoles(_config, token), "idRol", "DescripcionRol");
            var datos = model.ConsultarEmpleado(_config, token, idEmpleado);
            return View(datos);
        }

        // POST: PersonaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActualizarEmpleado(Empleado empleado)
        {
            try
            {
                string token = HttpContext.Session.GetString("Token");
               model.ActualizarEmpleado(_config, token, empleado);
                return RedirectToAction("ListaEmpleados", "Empleado");
            }
            catch
            {
                return View();
            }
        }


        // POST: PersonaController/Delete/5
        [HttpGet]
        public ActionResult EliminarEmpleado(string idEmpleado)
        {
            try
            {
                string token = HttpContext.Session.GetString("Token");
                model.EliminarEmpleado(_config, token, idEmpleado);
                return RedirectToAction("ListaEmpleados", "Empleado");
            }
            catch
            {
                return View();
            }
        }
    }
}
