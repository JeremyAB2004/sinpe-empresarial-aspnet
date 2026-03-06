using System.Text.Json;
using sinpe_empresarial_aspnet.Models;
using sinpe_empresarial_aspnet.Repositories;

namespace sinpe_empresarial_aspnet.Business
{
    public class CajasBusiness
    {
        private readonly ICajasRepository _cajasRepository;
        private readonly BitacoraBusiness _bitacora;

        private const string TABLA = "CAJAS";

        public CajasBusiness(ICajasRepository cajasRepository, BitacoraBusiness bitacora)
        {
            _cajasRepository = cajasRepository;
            _bitacora = bitacora;
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
            try
            {
                caja.FechaDeRegistro = DateTime.Now;
                caja.Estado = true;
                _cajasRepository.AddCaja(caja);

                _bitacora.RegistrarEvento(
                    tablaDeEvento: TABLA,
                    tipoDeEvento: "Registrar",
                    descripcion: $"Caja registrada: {caja.Nombre}",
                    datosAnteriores: JsonSerializer.Serialize(caja)
                );
            }
            catch (Exception ex)
            {
                _bitacora.RegistrarError(TABLA, ex.Message, ex.StackTrace ?? string.Empty);
                throw;
            }
        }

        public void UpdateCaja(Cajas caja)
        {
            try
            {
                // ✅ Capturar datos anteriores ANTES de actualizar
                var anterior = _cajasRepository.GetCajaById(caja.IdCaja);
                var jsonAnterior = JsonSerializer.Serialize(anterior);

                _cajasRepository.UpdateCaja(caja);

                // ✅ Capturar datos posteriores DESPUÉS de guardar
                var posterior = _cajasRepository.GetCajaById(caja.IdCaja);
                var jsonPosterior = JsonSerializer.Serialize(posterior);

                _bitacora.RegistrarEvento(
                    tablaDeEvento: TABLA,
                    tipoDeEvento: "Editar",
                    descripcion: $"Caja editada: {caja.Nombre}",
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