using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GestionCitas.Personas.Api.Models;
using GestionCitas.Personas.Dominio.PersonasAgrupadas.Servicios;
using GestionCitas.Personas.Dominio.PersonasAgrupadas.Modelos;
using GestionCitas.Personas.Dominio.PersonasAgrupadas.Excepciones;
using System.Threading.Tasks;

namespace GestionCitas.Personas.Api.Controllers
{
    [RoutePrefix("api/medicos")]
    public class MedicoController : ApiController
    {
        private readonly IMedicoCommandService _medicoCommandService;
        private readonly IMedicoQueriesService _medicoQueriesService;

        public MedicoController(IMedicoCommandService medicoCommandService, IMedicoQueriesService medicoQueriesService)
        {
            _medicoCommandService = medicoCommandService;
            _medicoQueriesService = medicoQueriesService;
        }

        [HttpGet]
        [Route("ObtenerMedicos")]
        public async Task<IHttpActionResult> ObtenerMedicos()
        {
            var medicos = await _medicoQueriesService.GetAllAsyncMedico();
            var response = medicos.Select(m => new MedicoResponseDto
            {
                Id = m.Id,
                Nombre = m.Nombre,
                Apellido = m.Apellido,
                TipoDocumento = m.TipoDocumento,
                Documento = m.Documento,
                Correo = m.Correo,
                NumeroContacto = m.NumeroContacto,
                Especialidad = m.especialidad
            });

            return Ok(response);
        }

        [HttpGet]
        [Route("ObtenerMedicosPorId/{id:guid}")]
        public async Task<IHttpActionResult> ObtenerMedicosPorId(Guid id)
        {
            try
            {
                var medico = await _medicoQueriesService.GetMedicoIdAsync(id);
                var response = new MedicoResponseDto
                {
                    Id = medico.Id,
                    Nombre = medico.Nombre,
                    Apellido = medico.Apellido,
                    TipoDocumento = medico.TipoDocumento,
                    Documento = medico.Documento,
                    Correo = medico.Correo,
                    NumeroContacto = medico.NumeroContacto,
                    Especialidad = medico.especialidad
                };

                return Ok(response);
            }
            catch (ExcepcionNoEncontrada ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("CrearMedico")]
        public async Task<IHttpActionResult> CrearMedico([FromBody] MedicoDto medicoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var medico = new Medico
            {
                Id = Guid.NewGuid(),
                Nombre = medicoDto.Nombre,
                Apellido = medicoDto.Apellido,
                TipoDocumento = medicoDto.TipoDocumento,
                Documento = medicoDto.Documento,
                Correo = medicoDto.Correo,
                NumeroContacto = medicoDto.NumeroContacto,
                especialidad = medicoDto.Especialidad
            };

            await _medicoCommandService.CrearMedico(medico);
            return Created($"api/medicos/{medico.Id}", medico.Id);
        }

        [HttpPut]
        [Route("ActualizarMedicosPorId/{id:guid}")]
        public async Task<IHttpActionResult> ActualizarMedicosPorId(Guid id, [FromBody] MedicoDto medicoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var medico = new Medico
                {
                    Id = id,
                    Nombre = medicoDto.Nombre,
                    Apellido = medicoDto.Apellido,
                    TipoDocumento = medicoDto.TipoDocumento,
                    Documento = medicoDto.Documento,
                    Correo = medicoDto.Correo,
                    NumeroContacto = medicoDto.NumeroContacto,
                    especialidad = medicoDto.Especialidad
                };

                await _medicoCommandService.ActualizarMedico(medico);
                return Ok();
            }
            catch (ExcepcionNoEncontrada ex)
            {
                return NotFound();
            }
        }

        // DELETE: api/medicos/{id}
        [HttpDelete]
        [Route("EliminarMedicosPorId/{id:guid}")]
        public async Task<IHttpActionResult> EliminarMedicosPorId(Guid id)
        {
            try
            {
                var medico = await _medicoQueriesService.GetMedicoIdAsync(id);
                await _medicoCommandService.EliminarMedico(medico);
                return Ok();
            }
            catch (ExcepcionNoEncontrada ex)
            {
                return NotFound();
            }
        }
    }
}
