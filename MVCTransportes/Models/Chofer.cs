using System.ComponentModel.DataAnnotations;

namespace MVCTransportes.Models
{
    public class Chofer
    {
        [Key]
        public int IdChofer { get; set; }
        [Required, StringLength(100)]
        public string Nombre { get; set; }
        [Required, StringLength(100)]
        public string Apellido { get; set; }
        [Required, StringLength(8)]
        public string DNI { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        [Required]
        public int NroRegistro { get; set; }
        public string Ciudad { get; set;}
    }
}