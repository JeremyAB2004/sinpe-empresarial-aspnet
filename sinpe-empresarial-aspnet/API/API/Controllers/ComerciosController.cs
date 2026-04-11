using API.Model;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComerciosController : ControllerBase
    {
        private readonly ComerciosService _comerciosService;

        public ComerciosController(ComerciosService comerciosService)
        {
            _comerciosService = comerciosService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ComerciosModel>> GetComercios()
        {
            return _comerciosService.GetComercios();
        }

        [HttpGet("{id}")]
        public ActionResult<ComerciosModel> GetComercioById(int id)
        {
            var comercio = _comerciosService.GetComercioById(id);
            if (comercio == null)
                return NotFound(new { Mensaje = "Comercio no encontrado" });

            return comercio;
        }

        [HttpPost]
        public ActionResult PostComercio(ComerciosModel comercio)
        {
            if (_comerciosService.ExisteIdentificacion(comercio.Identificacion, 0))
                return BadRequest(new { Mensaje = "Ya existe un comercio con esta identificación." });

            var nuevo = _comerciosService.PostComercio(comercio);
            return CreatedAtAction(nameof(GetComercioById), new { id = nuevo.IdComercio }, nuevo);
        }

        [HttpPut]
        public ActionResult PutComercio(ComerciosModel comercio)
        {
            if (!_comerciosService.PutComercio(comercio))
                return NotFound(new { Mensaje = "No se encontró el registro" });

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteComercio(int id)
        {
            if (!_comerciosService.DeleteComercio(id))
                return NotFound(new { Mensaje = "No se encontró el registro" });

            return NoContent();
        }
    }
}