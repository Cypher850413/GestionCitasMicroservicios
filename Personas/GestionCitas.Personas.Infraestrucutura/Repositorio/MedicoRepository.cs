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
    public class MedicoRepository : IMedicoRepository
    {
        private readonly PersonasDbContext _dbContext;

        public MedicoRepository(PersonasDbContext dbContext)
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



    }
}
