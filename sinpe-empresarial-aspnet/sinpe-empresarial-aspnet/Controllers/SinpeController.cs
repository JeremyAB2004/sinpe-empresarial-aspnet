using Microsoft.AspNetCore.Mvc;
using sinpe_empresarial_aspnet.Business;
using sinpe_empresarial_aspnet.Data;
using sinpe_empresarial_aspnet.Models;

namespace sinpe_empresarial_aspnet.Controllers
{
    public class SinpeController : Controller
    {
        private readonly SinpeBusiness _sinpeBusiness;
        private readonly AppDbContext _appDbContext;

        public SinpeController(SinpeBusiness sinpeBusiness, AppDbContext appDbContext)
        {
            _sinpeBusiness = sinpeBusiness;
            _appDbContext = appDbContext;
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(Sinpe model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Validar que exista caja activa con ese teléfono
            var caja = _appDbContext.Cajas
                .FirstOrDefault(c => c.TelefonoSINPE == model.TelefonoDestinatario);

            if (caja == null)
            {
                ModelState.AddModelError("TelefonoDestinatario", "No se encontró una caja con ese teléfono destinatario.");
                return View(model);
            }

            if (!caja.Estado)
            {
                ModelState.AddModelError("TelefonoDestinatario", "La caja asociada a ese teléfono está inactiva.");
                return View(model);
            }

            _sinpeBusiness.AddSinpe(model);
            TempData["Mensaje"] = "Pago SINPE registrado correctamente.";
            return RedirectToAction("Registrar");
        }
    }
}