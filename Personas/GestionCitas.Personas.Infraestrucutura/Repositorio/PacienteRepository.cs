using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionCitas.Personas.Dominio.PersonasAgrupadas.Modelos;
using GestionCitas.Personas.Dominio.PersonasAgrupadas.Repositorios;

namespace GestionCitas.Personas.Infraestrucutura.Repositorio
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly PersonasDbContext _dbContext;

        public PacienteRepository(PersonasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Métodos para Paciente
        public async Task CrearPaciente(Paciente paciente)
        {
            _dbContext.Pacientes.Add(paciente);
            await _dbContext.SaveChangesAsync();
        }

        public async Task ModificarPaciente(Paciente paciente)
        {
            _dbContext.Entry(paciente).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task EliminarPaciente(Paciente paciente)
        {
            _dbContext.Pacientes.Remove(paciente);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Paciente> GetPacienteIdAsync(Guid id)
        {
            return await _dbContext.Pacientes.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Paciente>> GetAllAsyncPaciente()
        {
            return await _dbContext.Pacientes.ToListAsync();
        }
    }
}
