using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using GestionCitas.Personas.Dominio.PersonasAgrupadas.Modelos;

namespace GestionCitas.Personas.Infraestrucutura
{
    public class PersonasDbContext : DbContext
    {
        public PersonasDbContext() : base("name=PersonasDbConnection") { }

        // DbSet para las tablas
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración personalizada para las tablas
            modelBuilder.Entity<Medico>().ToTable("Medicos");
            modelBuilder.Entity<Paciente>().ToTable("Pacientes");
        }
    }
}
