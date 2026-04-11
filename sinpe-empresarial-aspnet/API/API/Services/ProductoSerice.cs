using API.Data;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Services
{
    public class ProductoSerice
    {
        private readonly AppDbContext _context;
        

        //El iniciador???
        public ProductoSerice(AppDbContext context)
        {
            _context = context;
        }

        //Funcion de obtener datos
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Producto.ToListAsync());
        //}
        //GET
        public List<ProductoModel> GetProducto()
        {
            return _context.Producto.ToList();
        }


        //GET/ID
        public ProductoModel GetByIdProducto(int _id)
        {
            return _context.Producto.FirstOrDefault(p => p.Id == _id);
        }


        //POST
        public ProductoModel PostProducto(ProductoModel _productoModel)
        {
            //                 _context.Add(_producto);
            //await _context.SaveChangesAsync();
            _context.Producto.Add(_productoModel);
            _context.SaveChanges();

            return _productoModel;

        }

        //PUT
        public bool PutProducto(ProductoModel _productoModel)
        {

            var entidad = _context.Producto.FirstOrDefault(p => p.Id == _productoModel.Id);

            if (entidad == null)
            {
                return false;
            }


            entidad.Nombre = _productoModel.Nombre;
            entidad.Precio = _productoModel.Precio;
            entidad.Cantidad = _productoModel.Cantidad;
            entidad.Descripcion = _productoModel.Descripcion;

            _context.SaveChanges();

            return true;
        }


        //DELETE
        public bool DeleteProducto(int _id)
        {

            var entidad = _context.Producto.FirstOrDefault(p => p.Id == _id);

            if (entidad == null)
            {
                return false;
            }

            _context.Producto.Remove(entidad);
            _context.SaveChanges();

            return true;
        }
    }
}
