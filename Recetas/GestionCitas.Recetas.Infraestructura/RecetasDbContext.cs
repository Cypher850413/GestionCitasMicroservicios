using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using GestionCitas.Recetas.Dominio.Modelos;

namespace GestionCitas.Recetas.Infraestructura
{
    public class RecetasDbContext : DbContext
    {
        public RecetasDbContext() : base("name=RecetasDbConnection") { }

        // DbSet para las tablas
        public DbSet<Receta> Recetas { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración personalizada para las tablas
            modelBuilder.Entity<Receta>().ToTable("Recetas");

        }
    }
}
