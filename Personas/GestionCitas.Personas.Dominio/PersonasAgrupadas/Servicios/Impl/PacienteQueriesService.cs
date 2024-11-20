using GestionCitas.Personas.Dominio.PersonasAgrupadas.Excepciones;
using GestionCitas.Personas.Dominio.PersonasAgrupadas.Modelos;
using GestionCitas.Personas.Dominio.PersonasAgrupadas.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCitas.Personas.Dominio.PersonasAgrupadas.Servicios.Impl
{
    public class PacienteQueriesService : IPacienteQueriesService
    {
        private readonly IPacienteRepository _pacienteRepository;
        public PacienteQueriesService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<IEnumerable<Paciente>> GetAllAsyncPaciente()
        {
            return await _pacienteRepository.GetAllAsyncPaciente();
        }

        public async Task<Paciente> GetPacienteIdAsync(Guid id)
        {
            var paciente = await _pacienteRepository.GetPacienteIdAsync(id);

            if (paciente is null)
            {
                throw new ExcepcionNoEncontrada($"El paciente con id: {id} no fue encontrado.");
            }

            return paciente;
        }
    }
}
