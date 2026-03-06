using Microsoft.EntityFrameworkCore;
using sinpe_empresarial_aspnet.Data;
using sinpe_empresarial_aspnet.Models;

namespace sinpe_empresarial_aspnet.Repositories
{
    public class CajasRepository : ICajasRepository
    {
        private readonly AppDbContext _context;

        public CajasRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Cajas> GetCajasByComercio(int idComercio)
        {
            return _context.Cajas.Where(c => c.IdComercio == idComercio).ToList();
        }

        public Cajas GetCajaById(int idCaja)
        {
            return _context.Cajas.AsNoTracking().FirstOrDefault(c => c.IdCaja == idCaja);
        }

        public bool ExisteNombrePorComercio(int idComercio, string nombre, int idCaja)
        {
            return _context.Cajas.Any(c =>
                c.IdComercio == idComercio &&
                c.Nombre == nombre &&
                c.IdCaja != idCaja
            );
        }

        public bool ExisteTelefonoActivo(string telefonoSINPE, int idCaja)
        {
            return _context.Cajas.Any(c =>
                c.TelefonoSINPE == telefonoSINPE &&
                c.Estado == true &&
                c.IdCaja != idCaja
            );
        }

        public void AddCaja(Cajas caja)
        {
            _context.Cajas.Add(caja);
            _context.SaveChanges();
        }

        public void UpdateCaja(Cajas caja)
        {
            var existing = _context.Cajas.Find(caja.IdCaja);
            if (existing == null) return;

            existing.Nombre = caja.Nombre;
            existing.Descripcion = caja.Descripcion;
            existing.TelefonoSINPE = caja.TelefonoSINPE;
            existing.Estado = caja.Estado;
            existing.FechaDeModificacion = DateTime.Now;

            _context.SaveChanges();
        }
    }
}