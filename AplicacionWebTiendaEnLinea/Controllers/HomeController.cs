using AplicacionWebTiendaEnLinea.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AplicacionWebTiendaEnLinea.Controllers
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
            return View();
        }

        [HttpGet]
        public IActionResult Productos()
        {
            TiendaOnlineContext context = new TiendaOnlineContext();
            var ListarProductos = context.Productos.ToList();

            //ViewBag.Usuario = ListarUsuarios;

            return View(ListarProductos);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}