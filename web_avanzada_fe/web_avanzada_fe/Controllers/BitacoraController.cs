using Microsoft.AspNetCore.Mvc;
using web_avanzada_fe.Entities;
using web_avanzada_fe.Models;

namespace web_avanzada_fe.Controllers
{

    public class BitacoraController : Controller
    {
        private readonly IConfiguration _config;
        BitacoraModel bm = new BitacoraModel();
        public ActionResult ListaBitacoras()
        {
            try
            {
                string token = HttpContext.Session.GetString("Token");
                var bitacoras = bm.MostrarTodasBitacoras(_config, "");
                return View(bitacoras);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}