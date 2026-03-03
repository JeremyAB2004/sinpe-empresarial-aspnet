using sinpe_empresarial_aspnet.Models;

namespace sinpe_empresarial_aspnet.Repositories
{
    public interface IComerciosRepository
    {
        List<Comercios> GetAllComercios();
        Comercios GetComercioById(int id);
        bool ExisteIdentificacion(string identificacion, int idComercio);
        void AddComercio(Comercios comercio);
        void UpdateComercio(Comercios comercio);
    }
}