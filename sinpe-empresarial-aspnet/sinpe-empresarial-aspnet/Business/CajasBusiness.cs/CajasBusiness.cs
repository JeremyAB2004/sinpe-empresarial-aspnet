using sinpe_empresarial_aspnet.Models;
using sinpe_empresarial_aspnet.Repositories;

namespace sinpe_empresarial_aspnet.Business
{
    public class CajasBusiness
    {
        private readonly ICajasRepository _cajasRepository;

        public CajasBusiness(ICajasRepository cajasRepository)
        {
            _cajasRepository = cajasRepository;
        }

        public List<Cajas> GetCajasByComercio(int idComercio)
        {
            return _cajasRepository.GetCajasByComercio(idComercio);
        }

        public Cajas GetCajaById(int idCaja)
        {
            return _cajasRepository.GetCajaById(idCaja);
        }

        public bool ExisteNombrePorComercio(int idComercio, string nombre, int idCaja)
        {
            return _cajasRepository.ExisteNombrePorComercio(idComercio, nombre, idCaja);
        }

        public bool ExisteTelefonoActivo(string telefonoSINPE, int idCaja)
        {
            return _cajasRepository.ExisteTelefonoActivo(telefonoSINPE, idCaja);
        }

        public void AddCaja(Cajas caja)
        {
            caja.FechaDeRegistro = DateTime.Now;
            caja.Estado = true;
            _cajasRepository.AddCaja(caja);
        }

        public void UpdateCaja(Cajas caja)
        {
            _cajasRepository.UpdateCaja(caja);
        }
    }
}
