using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCTransportes.Models
{
    public class AgenciaContext : DbContext
    {
        public AgenciaContext() : base("KeyAgenciaDB")
        {

        }
        public DbSet<Chofer> Choferes { get; set; }
        //public DbSet<Vehiculo> Clientes { get; set; }
    }
}