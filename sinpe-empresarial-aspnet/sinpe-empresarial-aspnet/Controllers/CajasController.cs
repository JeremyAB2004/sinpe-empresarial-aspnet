using Microsoft.AspNetCore.Mvc;
using sinpe_empresarial_aspnet.Business;
using sinpe_empresarial_aspnet.Models;

namespace sinpe_empresarial_aspnet.Controllers
{
    public class CajasController : Controller
    {
        private readonly CajasBusiness _cajasBusiness;

        public CajasController(CajasBusiness cajasBusiness)
        {
            _cajasBusiness = cajasBusiness;
        }

        // Ver Cajas
        public IActionResult Index(int idComercio)
        {
            ViewBag.IdComercio = idComercio;
            var cajas = _cajasBusiness.GetCajasByComercio(idComercio);
            return View(cajas);
        }

        // Registrar Cajas
        public IActionResult Create(int idComercio)
        {
            var caja = new Cajas
            {
                IdComercio = idComercio
            };
            return View(caja);
        }

        // Registrar Cajas
        [HttpPost]
        public IActionResult Create(Cajas caja)
        {
            if (!ModelState.IsValid)
                return View(caja);

            // Nombre único por comercio
            if (_cajasBusiness.ExisteNombrePorComercio(caja.IdComercio, caja.Nombre, 0))
            {
                ModelState.AddModelError("Nombre", "Ya existe una caja con este nombre para este comercio.");
                return View(caja);
            }

            // Teléfono único en cajas ACTIVAS global
            if (_cajasBusiness.ExisteTelefonoActivo(caja.TelefonoSINPE, 0))
            {
                ModelState.AddModelError("TelefonoSINPE", "Ya existe una caja ACTIVA con este teléfono SINPE.");
                return View(caja);
            }

            _cajasBusiness.AddCaja(caja);
            TempData["Mensaje"] = "Caja registrada correctamente.";
            return RedirectToAction(nameof(Index), new { idComercio = caja.IdComercio });
        }

        // Editar Caja
        public IActionResult Edit(int id)
        {
            var caja = _cajasBusiness.GetCajaById(id);
            if (caja == null) return NotFound();
            return View(caja);
        }

        // Editar Caja
        [HttpPost]
        public IActionResult Edit(Cajas caja)
        {
            if (!ModelState.IsValid)
                return View(caja);

            // Nombre único por comercio (excluyendo esta caja)
            if (_cajasBusiness.ExisteNombrePorComercio(caja.IdComercio, caja.Nombre, caja.IdCaja))
            {
                ModelState.AddModelError("Nombre", "Ya existe una caja con este nombre para este comercio.");
                return View(caja);
            }

            // Teléfono único global en activos, SOLO si la caja quedará activa
            if (caja.Estado && _cajasBusiness.ExisteTelefonoActivo(caja.TelefonoSINPE, caja.IdCaja))
            {
                ModelState.AddModelError("TelefonoSINPE", "Ya existe una caja ACTIVA con este teléfono SINPE.");
                return View(caja);
            }

            _cajasBusiness.UpdateCaja(caja);
            return RedirectToAction(nameof(Index), new { idComercio = caja.IdComercio });
        }
    }

}