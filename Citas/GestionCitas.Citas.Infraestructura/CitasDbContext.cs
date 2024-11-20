using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using GestionCitas.Citas.Dominio.Modelos;

namespace GestionCitas.Citas.Infraestructura
{
    public class CitasDbContext : DbContext
    {
        public CitasDbContext() : base("name=CitasDbConnection") { }

        // DbSet para las tablas
        public DbSet<Cita> Citas { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración personalizada para las tablas
            modelBuilder.Entity<Cita>().ToTable("Citas");
           
        }
    }
}
