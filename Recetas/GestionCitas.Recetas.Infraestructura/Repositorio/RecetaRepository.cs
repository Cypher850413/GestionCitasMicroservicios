using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using GestionCitas.Recetas.Dominio.Repositorios;
using GestionCitas.Recetas.Dominio.Modelos;


namespace GestionCitas.Recetas.Infraestructura.Repositorio
{
    public class RecetaRepository : IRecetaRepository
    {
        private readonly RecetasDbContext _dbContext;

        public RecetaRepository(RecetasDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task CrearReceta(Receta receta)
        {
            _dbContext.Recetas.Add(receta);
            await _dbContext.SaveChangesAsync();
        }

        public async Task ActualizarReceta(Receta receta)
        {
            _dbContext.Entry(receta).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task EliminarReceta(Receta receta)
        {
            _dbContext.Recetas.Remove(receta);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Receta> GetRecetaIdAsync(Guid id)
        {
            return await _dbContext.Recetas.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<IEnumerable<Receta>> GetAllAsyncReceta()
        {
            return await _dbContext.Recetas.ToListAsync();
        }
    }
}
