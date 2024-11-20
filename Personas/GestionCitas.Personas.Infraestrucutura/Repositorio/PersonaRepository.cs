using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using GestionCitas.Personas.Dominio.PersonasAgrupadas.Modelos;
using GestionCitas.Personas.Dominio.PersonasAgrupadas.Repositorios;

namespace GestionCitas.Personas.Infraestrucutura.Repositorio
{
    public class PersonaRepository : IMedicoRepository
    {
        private readonly PersonasDbContext _dbContext;

        public PersonaRepository(PersonasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Métodos para Medico
        public async Task CrearMedico(Medico medico)
        {
            _dbContext.Medicos.Add(medico);
            await _dbContext.SaveChangesAsync();
        }

        public async Task ActualizarMedico(Medico medico)
        {
            _dbContext.Entry(medico).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task EliminarMedico(Medico medico)
        {
            _dbContext.Medicos.Remove(medico);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Medico> GetMedicoIdAsync(Guid id)
        {
            return await _dbContext.Medicos.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Medico>> GetAllAsyncMedico()
        {
            return await _dbContext.Medicos.ToListAsync();
        }

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
            return await _dbContext.Pacientes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Paciente>> GetAllAsyncPaciente()
        {
            return await _dbContext.Pacientes.ToListAsync();
        }
    }
}
