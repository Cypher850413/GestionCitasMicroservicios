using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using GestionCitas.Citas.Dominio.Repositorios;
using GestionCitas.Citas.Dominio.Modelos;

namespace GestionCitas.Citas.Infraestructura.Repositorio
{
    public class CitaRepository : ICitaRepository
    {
        private readonly CitasDbContext _dbContext;

        public CitaRepository(CitasDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task CrearCita(Cita cita)
        {
            _dbContext.Citas.Add(cita);
            await _dbContext.SaveChangesAsync();
        }

        public async Task ActualizarCita(Cita cita)
        {
            _dbContext.Entry(cita).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task EliminarCita(Cita cita)
        {
            _dbContext.Citas.Remove(cita);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Cita> GetCitaIdAsync(Guid id)
        {
            return await _dbContext.Citas.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Cita>> GetAllAsyncCita()
        {
            return await _dbContext.Citas.ToListAsync();
        }
        
    }
}
