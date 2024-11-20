using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionCitas.Recetas.Dominio.Excepciones;
using GestionCitas.Recetas.Dominio.Modelos;
using GestionCitas.Recetas.Dominio.Repositorios;

namespace GestionCitas.Recetas.Dominio.Servicios.Impl
{
    public class RecetaQueriesService : IRecetaQueriesService
    {
        private readonly IRecetaRepository _recetaRepository;

        public RecetaQueriesService(IRecetaRepository recetaRepository)
        {
            _recetaRepository = recetaRepository;
        }

        public async Task<IEnumerable<Receta>> GetAllAsyncReceta()
        {
            return await _recetaRepository.GetAllAsyncReceta();
        }

        public async Task<Receta> GetRecetaIdAsync(Guid id)
        {
            var receta = await _recetaRepository.GetRecetaIdAsync(id);

            if (receta is null)
            {
                throw new ExcepcionNoEncontrada($"La receta con id: {id} no fue encontrada.");
            }

            return receta;
        }
    }
}
