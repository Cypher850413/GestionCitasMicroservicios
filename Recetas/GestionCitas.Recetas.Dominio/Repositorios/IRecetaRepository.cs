using GestionCitas.Recetas.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCitas.Recetas.Dominio.Repositorios
{
    public interface IRecetaRepository
    {
        Task<IEnumerable<Receta>> GetAllAsyncReceta();
        Task<Receta> GetRecetaIdAsync(Guid id);
        Task CrearReceta(Receta receta);
        Task ActualizarReceta(Receta receta);
        Task EliminarReceta(Receta receta);
    }
}
