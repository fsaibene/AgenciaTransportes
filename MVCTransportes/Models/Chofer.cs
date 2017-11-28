using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCTransportes.Models
{
    public class Chofer
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        [Key]
        public string Email { get; set; }
        public string Celular { get; set; }
        public int NroRegistro { get; set; }
        public string Ciudad { get; set;}
    }
}