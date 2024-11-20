using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionCitas.Personas.Dominio.PersonasAgrupadas.Excepciones;
using GestionCitas.Personas.Dominio.PersonasAgrupadas.Modelos;
using GestionCitas.Personas.Dominio.PersonasAgrupadas.Repositorios;

namespace GestionCitas.Personas.Dominio.PersonasAgrupadas.Servicios.Impl
{
    public class PacienteCommandService : IPacienteCommandService
    {
        private readonly IPacienteRepository _pacienteRepository;
        public PacienteCommandService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }
        public async Task CrearPaciente(Paciente paciente)
        {
            await _pacienteRepository.CrearPaciente(paciente);
        }

        public async Task ModificarPaciente(Paciente paciente)
        {
            var BuscarPaciente = await _pacienteRepository.GetPacienteIdAsync(paciente.Id);

            if (BuscarPaciente is null)
            {
                throw new ExcepcionNoEncontrada($"El paciente con id: {paciente.Id} no fue encontrado.");
            }

            await _pacienteRepository.ModificarPaciente(paciente);
        }

        public async Task EliminarPaciente(Paciente paciente)
        {
            var BuscarPaciente = await _pacienteRepository.GetPacienteIdAsync(paciente.Id);

            if (BuscarPaciente is null)
            {
                throw new ExcepcionNoEncontrada($"El paciente con id: {paciente.Id}  no fue encontrado.");
            }

            await _pacienteRepository.EliminarPaciente(paciente);
        }
    }
}
