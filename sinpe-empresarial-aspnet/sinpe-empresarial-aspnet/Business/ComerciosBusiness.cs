using System.Text.Json;
using sinpe_empresarial_aspnet.Models;
using sinpe_empresarial_aspnet.Repositories;

namespace sinpe_empresarial_aspnet.Business
{
    public class ComerciosBusiness
    {
        private readonly IComerciosRepository _comerciosRepository;
        private readonly BitacoraBusiness _bitacora;

        private const string TABLA = "COMERCIOS";

        public ComerciosBusiness(
            IComerciosRepository comerciosRepository,
            BitacoraBusiness bitacora)
        {
            _comerciosRepository = comerciosRepository;
            _bitacora = bitacora;
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
            try
            {
                comercio.FechaDeRegistro = DateTime.Now;
                comercio.Estado = true;
                _comerciosRepository.AddComercio(comercio);

                _bitacora.RegistrarEvento(
                    tablaDeEvento: TABLA,
                    tipoDeEvento: "Registrar",
                    descripcion: $"Comercio registrado: {comercio.Nombre}",
                    datosAnteriores: JsonSerializer.Serialize(comercio)
                );
            }
            catch (Exception ex)
            {
                _bitacora.RegistrarError(TABLA, ex.Message, ex.StackTrace ?? string.Empty);
                throw;
            }
        }

        public void UpdateComercio(Comercios comercio)
        {
            try
            {
                // Capturar datos anteriores ANTES de actualizar
                var anterior = _comerciosRepository.GetComercioById(comercio.IdComercio);
                var jsonAnterior = JsonSerializer.Serialize(anterior);

                _comerciosRepository.UpdateComercio(comercio);

                // Ahora sí leer los datos nuevos (ya guardados en DB)
                var posterior = _comerciosRepository.GetComercioById(comercio.IdComercio);
                var jsonPosterior = JsonSerializer.Serialize(posterior);

                _bitacora.RegistrarEvento(
                    tablaDeEvento: TABLA,
                    tipoDeEvento: "Editar",
                    descripcion: $"Comercio editado: {comercio.Nombre}",
                    datosAnteriores: jsonAnterior,
                    datosPosteriores: jsonPosterior
                );
            }
            catch (Exception ex)
            {
                _bitacora.RegistrarError(TABLA, ex.Message, ex.StackTrace ?? string.Empty);
                throw;
            }
        }
    }
}