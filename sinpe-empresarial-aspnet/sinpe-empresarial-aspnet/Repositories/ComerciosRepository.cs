
using Microsoft.EntityFrameworkCore;
using sinpe_empresarial_aspnet.Data;
using sinpe_empresarial_aspnet.Models;

namespace sinpe_empresarial_aspnet.Repositories
{
    public class ComerciosRepository : IComerciosRepository
    {
        private readonly AppDbContext _context;

        public ComerciosRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Comercios> GetAllComercios()
        {
            return _context.Comercios.ToList();
        }

        public Comercios GetComercioById(int id)
        {
            // AsNoTracking evita que EF devuelva el objeto ya modificado en memoria
            return _context.Comercios
                .AsNoTracking()
                .FirstOrDefault(c => c.IdComercio == id);
        }

        public bool ExisteIdentificacion(string identificacion, int idComercio)
        {
            return _context.Comercios
                .Any(c => c.Identificacion == identificacion && c.IdComercio != idComercio);
        }

        public void AddComercio(Comercios comercio)
        {
            _context.Comercios.Add(comercio);
            _context.SaveChanges();
        }

        public void UpdateComercio(Comercios comercio)
        {
            var existing = _context.Comercios.Find(comercio.IdComercio);
            if (existing == null) return;

            existing.Nombre = comercio.Nombre;
            existing.TipoDeComercio = comercio.TipoDeComercio;
            existing.Telefono = comercio.Telefono;
            existing.CorreoElectronico = comercio.CorreoElectronico;
            existing.Direccion = comercio.Direccion;
            existing.Estado = comercio.Estado;
            existing.FechaDeModificacion = DateTime.Now;

            _context.SaveChanges();
        }
    }
}