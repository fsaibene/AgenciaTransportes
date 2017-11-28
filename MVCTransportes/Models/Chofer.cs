using System.ComponentModel.DataAnnotations;

namespace MVCTransportes.Models
{
    public class Chofer
    {
        [Key]
        public int IdChofer { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public int NroRegistro { get; set; }
        public string Ciudad { get; set;}
    }
}