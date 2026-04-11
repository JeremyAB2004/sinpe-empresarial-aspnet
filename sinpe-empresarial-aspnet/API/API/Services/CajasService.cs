using API.Data;
using API.Model;

namespace API.Services
{
    public class CajasService
    {
        private readonly AppDbContext _context;

        public CajasService(AppDbContext context)
        {
            _context = context;
        }

        public List<CajasModel> GetCajasByComercio(int idComercio)
        {
            return _context.Cajas.Where(c => c.IdComercio == idComercio).ToList();
        }

        public CajasModel GetCajaById(int idCaja)
        {
            return _context.Cajas.FirstOrDefault(c => c.IdCaja == idCaja);
        }

        public bool ExisteNombrePorComercio(int idComercio, string nombre, int idCaja)
        {
            return _context.Cajas.Any(c =>
                c.IdComercio == idComercio &&
                c.Nombre == nombre &&
                c.IdCaja != idCaja);
        }

        public bool ExisteTelefonoActivo(string telefonoSINPE, int idCaja)
        {
            return _context.Cajas.Any(c =>
                c.TelefonoSINPE == telefonoSINPE &&
                c.Estado == true &&
                c.IdCaja != idCaja);
        }

        public CajasModel PostCaja(CajasModel caja)
        {
            caja.FechaDeRegistro = DateTime.Now;
            caja.Estado = true;
            _context.Cajas.Add(caja);
            _context.SaveChanges();
            return caja;
        }

        public bool PutCaja(CajasModel caja)
        {
            var entidad = _context.Cajas.FirstOrDefault(c => c.IdCaja == caja.IdCaja);
            if (entidad == null) return false;

            entidad.Nombre = caja.Nombre;
            entidad.Descripcion = caja.Descripcion;
            entidad.TelefonoSINPE = caja.TelefonoSINPE;
            entidad.Estado = caja.Estado;
            entidad.FechaDeModificacion = DateTime.Now;

            _context.SaveChanges();
            return true;
        }

        public bool DeleteCaja(int id)
        {
            var entidad = _context.Cajas.FirstOrDefault(c => c.IdCaja == id);
            if (entidad == null) return false;

            _context.Cajas.Remove(entidad);
            _context.SaveChanges();
            return true;
        }
    }
}