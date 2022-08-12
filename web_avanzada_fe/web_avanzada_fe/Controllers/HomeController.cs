using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using web_avanzada_fe.Models;

namespace web_avanzada_fe.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Cedula= HttpContext.Session.GetString("Cedula");
            ViewBag.Rol = HttpContext.Session.GetString("Rol");
            ViewBag.Nombre = HttpContext.Session.GetString("Nombre");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }

        public IActionResult ErrorRol()
        {
            return View();
        }
    }
}