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
    public class MedicoQueriesService : IMedicoQueriesService
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoQueriesService(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        public async Task<IEnumerable<Medico>> GetAllAsyncMedico()
        {
            return await _medicoRepository.GetAllAsyncMedico();
        }

        public async Task<Medico> GetMedicoIdAsync(Guid id)
        {
            var medico = await _medicoRepository.GetMedicoIdAsync(id);

            if (medico is null)
            {
                throw new ExcepcionNoEncontrada($"El medico con id: {id} no fue encontrado.");
            }

            return medico;
        }
    }
}
