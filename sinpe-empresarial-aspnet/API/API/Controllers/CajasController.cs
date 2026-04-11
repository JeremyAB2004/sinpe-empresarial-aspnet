using API.Model;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CajasController : ControllerBase
    {
        private readonly CajasService _cajasService;

        public CajasController(CajasService cajasService)
        {
            _cajasService = cajasService;
        }

        [HttpGet("{idComercio}")]
        public ActionResult<IEnumerable<CajasModel>> GetCajasByComercio(int idComercio)
        {
            return _cajasService.GetCajasByComercio(idComercio);
        }

        [HttpGet("detalle/{id}")]
        public ActionResult<CajasModel> GetCajaById(int id)
        {
            var caja = _cajasService.GetCajaById(id);
            if (caja == null)
                return NotFound(new { Mensaje = "Caja no encontrada" });

            return caja;
        }

        [HttpPost]
        public ActionResult PostCaja(CajasModel caja)
        {
            if (_cajasService.ExisteNombrePorComercio(caja.IdComercio, caja.Nombre, 0))
                return BadRequest(new { Mensaje = "Ya existe una caja con ese nombre en este comercio." });

            if (_cajasService.ExisteTelefonoActivo(caja.TelefonoSINPE, 0))
                return BadRequest(new { Mensaje = "El teléfono SINPE ya está en uso por otra caja activa." });

            var nueva = _cajasService.PostCaja(caja);
            return CreatedAtAction(nameof(GetCajaById), new { id = nueva.IdCaja }, nueva);
        }

        [HttpPut]
        public ActionResult PutCaja(CajasModel caja)
        {
            if (_cajasService.ExisteNombrePorComercio(caja.IdComercio, caja.Nombre, caja.IdCaja))
                return BadRequest(new { Mensaje = "Ya existe una caja con ese nombre en este comercio." });

            if (_cajasService.ExisteTelefonoActivo(caja.TelefonoSINPE, caja.IdCaja))
                return BadRequest(new { Mensaje = "El teléfono SINPE ya está en uso por otra caja activa." });

            if (!_cajasService.PutCaja(caja))
                return NotFound(new { Mensaje = "No se encontró el registro" });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCaja(int id)
        {
            if (!_cajasService.DeleteCaja(id))
                return NotFound(new { Mensaje = "No se encontró el registro" });

            return NoContent();
        }
    }
}