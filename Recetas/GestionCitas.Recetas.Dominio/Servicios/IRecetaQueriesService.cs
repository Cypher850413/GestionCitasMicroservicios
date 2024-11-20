using GestionCitas.Recetas.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCitas.Recetas.Dominio.Servicios
{
    public interface IRecetaQueriesService
    {
        Task<IEnumerable<Receta>> GetAllAsyncReceta();
        Task<Receta> GetRecetaIdAsync(Guid id);
    }
}
