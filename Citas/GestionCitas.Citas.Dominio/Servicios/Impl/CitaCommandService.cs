using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionCitas.Citas.Dominio.Excepciones;
using GestionCitas.Citas.Dominio.Modelos;
using GestionCitas.Citas.Dominio.Repositorios;

namespace GestionCitas.Citas.Dominio.Servicios.Impl
{
    public class CitaCommandService : ICitaCommandService
    {
        private readonly ICitaRepository _citaRepository;
        public CitaCommandService(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }
        public async Task CrearCita(Cita cita)
        {
            await _citaRepository.CrearCita(cita);
        }

        public async Task ActualizarCita(Cita cita)
        {
            var BuscarCita = await _citaRepository.GetCitaIdAsync(cita.Id);

            if (BuscarCita is null)
            {
                throw new ExcepcionNoEncontrada($"La cita con id: {cita.Id} no fue encontrada.");
            }

            await _citaRepository.ActualizarCita(cita);
        }

        public async Task EliminarCita(Cita cita)
        {
            var BuscarCita = await _citaRepository.GetCitaIdAsync(cita.Id);

            if (BuscarCita is null)
            {
                throw new ExcepcionNoEncontrada($"La cita con id: {cita.Id}  no fue encontrada.");
            }

            await _citaRepository.EliminarCita(cita);
        }
    }
}
