using Microsoft.AspNetCore.Mvc;
using sinpe_empresarial_aspnet.Business;

namespace sinpe_empresarial_aspnet.Controllers
{
    public class BitacoraController : Controller
    {
        private readonly BitacoraBusiness _bitacoraBusiness;

        public BitacoraController(BitacoraBusiness bitacoraBusiness)
        {
            _bitacoraBusiness = bitacoraBusiness;
        }

        public IActionResult Index()
        {
            var eventos = _bitacoraBusiness.GetAllEventos();
            return View(eventos);
        }
    }
}