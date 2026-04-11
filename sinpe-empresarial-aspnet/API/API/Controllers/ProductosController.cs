using API.Model;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Timers;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : Controller
    {
        private readonly ProductoSerice _productoSerice;


        public ProductosController(ProductoSerice productoSerice)
        {
            _productoSerice = productoSerice;
        }
        //El controller une la vista con la logica 
        //CRUD POST/GET/PUT/DELETE

        //GetProducto()

        [HttpGet]
        public ActionResult<IEnumerable<ProductoModel>> GetProducto()
        {
            return _productoSerice.GetProducto();
        }


        [HttpGet("{id}")]
        public ActionResult <ProductoModel> GetByIdProducto(int id)
        {
            return _productoSerice.GetByIdProducto(id);
        }

        [HttpPost]
        public ActionResult PostProducto(ProductoModel _productoModel) {

            ProductoModel newProducto = _productoSerice.PostProducto(_productoModel);


            return CreatedAtAction(
                    nameof(GetProducto),
                    new
                        {
                            id = newProducto.Precio
                        },
                        newProducto );

        }

        [HttpPut]
        public ActionResult PutProducto(ProductoModel _productoModel)
        {
            if ( !_productoSerice.PutProducto(_productoModel))
            {
                return NotFound(
                     new
                     {
                         Mensaje ="No se encontro el registro"
                     }
                    );
            }

            return NoContent();
        }


        [HttpDelete]
        public ActionResult DeleteProducto(int _id)
        {
            if (!_productoSerice.DeleteProducto(_id))
            {
                return NotFound(
                     new
                     {
                         Mensaje = "No se encontro el registro"
                     }
                    );
            }

            return NoContent();

        }


    }
}
