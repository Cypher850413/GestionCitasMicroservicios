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
    
    public class MedicoCommandService : IMedicoCommandService
    {
        private readonly IMedicoRepository _medicoRepository;
        public MedicoCommandService(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository; 
        }
        public async Task CrearMedico(Medico medico)
        {
            await _medicoRepository.CrearMedico(medico);
        }

        public async Task ActualizarMedico(Medico medico)
        {
            var BuscarMedico = await _medicoRepository.GetMedicoIdAsync(medico.Id);

            if (BuscarMedico is null)
            {
                throw new ExcepcionNoEncontrada($"El medico con id: {medico.Id} no fue encontrado.");
            }

            await _medicoRepository.ActualizarMedico(medico);
        }

        public async Task EliminarMedico(Medico medico)
        {
            var BuscarMedico = await _medicoRepository.GetMedicoIdAsync(medico.Id);

            if (BuscarMedico is null)
            {
                throw new ExcepcionNoEncontrada($"El medico con id: {medico.Id}  no fue encontrado.");
            }

            await _medicoRepository.EliminarMedico(medico);
        }

    }
}
