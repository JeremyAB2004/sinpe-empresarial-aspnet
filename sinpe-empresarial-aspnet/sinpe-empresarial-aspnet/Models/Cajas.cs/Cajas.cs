using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sinpe_empresarial_aspnet.Models
{
    [Table("CAJAS")]
    public class Cajas
    {
        [Key]
        public int IdCaja { get; set; }

        [Required]
        public int IdComercio { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(150)]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(10)]
        public string TelefonoSINPE { get; set; }

        public DateTime FechaDeRegistro { get; set; }

        public DateTime? FechaDeModificacion { get; set; }

        public bool Estado { get; set; } // true=Activo, false=Inactivo
    }
}
