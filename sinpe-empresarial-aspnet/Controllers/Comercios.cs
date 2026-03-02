using Microsoft.AspNetCore.Mvc;
using sinpe_empresarial_aspnet.Business;
using sinpe_empresarial_aspnet.Models;

namespace sinpe_empresarial_aspnet.Controllers
{
    public class ComerciosController : Controller
    {
        private readonly ComerciosBusiness _comerciosBusiness;

        public ComerciosController(ComerciosBusiness comerciosBusiness)
        {
            _comerciosBusiness = comerciosBusiness;
        }

        public IActionResult Index()
        {
            return View(_comerciosBusiness.GetAllComercios());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Comercios comercio)
        {
            if (!ModelState.IsValid)
                return View(comercio);

            if (_comerciosBusiness.ExisteIdentificacion(comercio.Identificacion, 0))
            {
                ModelState.AddModelError("Identificacion", "Ya existe un comercio con esta identificación.");
                return View(comercio);
            }

            _comerciosBusiness.AddComercio(comercio);
            TempData["Mensaje"] = "Comercio registrado correctamente.";
            return RedirectToAction(nameof(Create));
        }

        public IActionResult Edit(int id)
        {
            var comercio = _comerciosBusiness.GetComercioById(id);
            if (comercio == null) return NotFound();
            return View(comercio);
        }

        [HttpPost]
        public IActionResult Edit(int IdComercio, string Nombre, int TipoDeComercio, string Telefono,
                                   string CorreoElectronico, string Direccion, string Estado)
        {
            var comercio = _comerciosBusiness.GetComercioById(IdComercio);
            if (comercio == null) return NotFound();

            comercio.Nombre = Nombre;
            comercio.TipoDeComercio = TipoDeComercio;
            comercio.Telefono = Telefono;
            comercio.CorreoElectronico = CorreoElectronico;
            comercio.Direccion = Direccion;
            comercio.Estado = Estado == "true";

            _comerciosBusiness.UpdateComercio(comercio);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var comercio = _comerciosBusiness.GetComercioById(id);
            if (comercio == null) return NotFound();
            return View(comercio);
        }
    }
}