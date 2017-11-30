using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTransportes.Models
{
    public class Vehiculo
    {
        [Key]
        public int IdVehiculo { get; set; }
        public int IdChofer { get; set; }
        [Required, StringLength(30)]
        public string Marca { get; set; }
        [CheckVehiculoModelo]
        public int Modelo { get; set; }
        [ForeignKey("IdChofer")]
        public Chofer Chofer { get; set; }
        [Required, StringLength(8)]
        public string Matricula { get; set; }
        [StringLength(100)]
        public string Caracteristicas { get; set; }
    }
}