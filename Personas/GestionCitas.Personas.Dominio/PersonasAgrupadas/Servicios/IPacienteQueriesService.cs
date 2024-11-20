using GestionCitas.Personas.Dominio.PersonasAgrupadas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCitas.Personas.Dominio.PersonasAgrupadas.Servicios
{
    public interface IPacienteQueriesService
    {
        Task<IEnumerable<Paciente>> GetAllAsyncPaciente();
        Task<Paciente> GetPacienteIdAsync(Guid id);
    }
}
