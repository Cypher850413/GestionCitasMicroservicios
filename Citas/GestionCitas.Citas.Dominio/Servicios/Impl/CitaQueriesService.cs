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
    public class CitaQueriesService : ICitaQueriesService
    {
        private readonly ICitaRepository _citaRepository;

        public CitaQueriesService(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        public async Task<IEnumerable<Cita>> GetAllAsyncCita()
        {
            return await _citaRepository.GetAllAsyncCita();
        }

        public async Task<Cita> GetCitaIdAsync(Guid id)
        {
            var cita = await _citaRepository.GetCitaIdAsync(id);

            if (cita is null)
            {
                throw new ExcepcionNoEncontrada($"La cita con id: {id} no fue encontrada.");
            }

            return cita;
        }
    }
}
