using GestionCitas.Personas.Dominio.PersonasAgrupadas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCitas.Personas.Dominio.PersonasAgrupadas.Repositorios
{
    public interface IMedicoRepository
    {
        Task<IEnumerable<Medico>> GetAllAsyncMedico();
        Task<Medico> GetMedicoIdAsync(Guid id);
        Task CrearMedico(Medico medico);
        Task ActualizarMedico(Medico medico);
        Task EliminarMedico(Medico medico);
    }
}
