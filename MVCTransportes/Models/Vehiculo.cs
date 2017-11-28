using System.ComponentModel.DataAnnotations;

namespace MVCTransportes.Models
{
    public class Vehiculo
    {
        [Key]
        public int IdVehiculo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public Chofer Chofer { get; set; }
        public string Matricula { get; set; }
        public string Caracteristicas { get; set; }
    }
}