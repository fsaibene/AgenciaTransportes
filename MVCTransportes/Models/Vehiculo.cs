using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTransportes.Models
{
    public class Vehiculo
    {
        [Key]
        public int IdVehiculo { get; set; }
        public int IdChofer { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        [ForeignKey("IdChofer")]
        public Chofer Chofer { get; set; }
        public string Matricula { get; set; }
        public string Caracteristicas { get; set; }
    }
}