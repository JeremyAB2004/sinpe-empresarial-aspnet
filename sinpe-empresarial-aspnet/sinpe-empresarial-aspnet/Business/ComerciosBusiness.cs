
using sinpe_empresarial_aspnet.Models;
using sinpe_empresarial_aspnet.Repositories;

namespace sinpe_empresarial_aspnet.Business
{
    public class ComerciosBusiness
    {
        private readonly IComerciosRepository _comerciosRepository;

        public ComerciosBusiness(IComerciosRepository comerciosRepository)
        {
            _comerciosRepository = comerciosRepository;
        }

        public List<Comercios> GetAllComercios()
        {
            return _comerciosRepository.GetAllComercios();
        }

        public Comercios GetComercioById(int id)
        {
            return _comerciosRepository.GetComercioById(id);
        }

        public bool ExisteIdentificacion(string identificacion, int idComercio)
        {
            return _comerciosRepository.ExisteIdentificacion(identificacion, idComercio);
        }

        public void AddComercio(Comercios comercio)
        {
            comercio.FechaDeRegistro = DateTime.Now;
            comercio.Estado = true;
            _comerciosRepository.AddComercio(comercio);
        }

        public void UpdateComercio(Comercios comercio)
        {
            _comerciosRepository.UpdateComercio(comercio);
        }
    }
}