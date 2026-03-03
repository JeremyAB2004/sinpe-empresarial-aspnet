using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sinpe_empresarial_aspnet.Models
{
    [Table("SINPE")]
    public class Sinpe
    {
        [Key]
        public int IdSinpe { get; set; }

        [Required]
        [StringLength(10)]
        public string TelefonoOrigen { get; set; }

        [Required]
        [StringLength(200)]
        public string NombreOrigen { get; set; }

        [Required]
        [StringLength(10)]
        public string TelefonoDestinatario { get; set; }

        [Required]
        [StringLength(200)]
        public string NombreDestinatario { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }

        [StringLength(50)]
        public string? Descripcion { get; set; }

        public DateTime FechaDeRegistro { get; set; }

        public bool Estado { get; set; }
    }
}
