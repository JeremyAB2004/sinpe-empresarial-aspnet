using API.Data;
using API.Model;

namespace API.Services
{
    public class ComerciosService
    {
        private readonly AppDbContext _context;

        public ComerciosService(AppDbContext context)
        {
            _context = context;
        }

        // GET
        public List<ComerciosModel> GetComercios()
        {
            return _context.Comercios.ToList();
        }

        // GET por ID
        public ComerciosModel GetComercioById(int id)
        {
            return _context.Comercios.FirstOrDefault(c => c.IdComercio == id);
        }

        // POST
        public ComerciosModel PostComercio(ComerciosModel comercio)
        {
            comercio.FechaDeRegistro = DateTime.Now;
            comercio.Estado = true;
            _context.Comercios.Add(comercio);
            _context.SaveChanges();
            return comercio;
        }

        // PUT
        public bool PutComercio(ComerciosModel comercio)
        {
            var entidad = _context.Comercios.FirstOrDefault(c => c.IdComercio == comercio.IdComercio);
            if (entidad == null) return false;

            entidad.Nombre = comercio.Nombre;
            entidad.TipoDeComercio = comercio.TipoDeComercio;
            entidad.Telefono = comercio.Telefono;
            entidad.CorreoElectronico = comercio.CorreoElectronico;
            entidad.Direccion = comercio.Direccion;
            entidad.Estado = comercio.Estado;
            entidad.FechaDeModificacion = DateTime.Now;

            _context.SaveChanges();
            return true;
        }

        // DELETE
        public bool DeleteComercio(int id)
        {
            var entidad = _context.Comercios.FirstOrDefault(c => c.IdComercio == id);
            if (entidad == null) return false;

            _context.Comercios.Remove(entidad);
            _context.SaveChanges();
            return true;
        }

        // Validación de identificación duplicada
        public bool ExisteIdentificacion(string identificacion, int idComercio)
        {
            return _context.Comercios
                .Any(c => c.Identificacion == identificacion && c.IdComercio != idComercio);
        }
    }
}