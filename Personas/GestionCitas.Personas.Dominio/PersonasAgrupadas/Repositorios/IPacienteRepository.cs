using GestionCitas.Personas.Dominio.PersonasAgrupadas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCitas.Personas.Dominio.PersonasAgrupadas.Repositorios
{
    public interface IPacienteRepository
    {
        Task<IEnumerable<Paciente>> GetAllAsyncPaciente();
        Task<Paciente> GetPacienteIdAsync(Guid id);
        Task CrearPaciente(Paciente paciente);
        Task ModificarPaciente(Paciente paciente);
        Task EliminarPaciente(Paciente paciente);
    }
}
