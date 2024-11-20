﻿using GestionCitas.Personas.Api.Controllers.Dtos;
using GestionCitas.Personas.Dominio.PersonasAgrupadas.Servicios;
using GestionCitas.Personas.Dominio.PersonasAgrupadas.Modelos;
using GestionCitas.Personas.Dominio.PersonasAgrupadas.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GestionCitas.Personas.Api.Controllers
{
    [RoutePrefix("api/pacientes")]
    public class PacienteController : ApiController
    {
        private readonly IPacienteCommandService _pacienteCommandService;
        private readonly IPacienteQueriesService _pacienteQueriesService;

        public PacienteController(IPacienteCommandService pacienteCommandService, IPacienteQueriesService pacienteQueriesService)
        {
            _pacienteCommandService = pacienteCommandService;
            _pacienteQueriesService = pacienteQueriesService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> GetAll()
        {
            var pacientes = await _pacienteQueriesService.GetAllAsyncPaciente();
            var response = pacientes.Select(m => new PacienteResponseDto
            {
                Id = m.Id,
                Nombre = m.Nombre,
                Apellido = m.Apellido,
                TipoDocumento = m.TipoDocumento,
                Documento = m.Documento,
                Correo = m.Correo,
                NumeroContacto = m.NumeroContacto,
                Eps = m.Eps
            });

            return Ok(response);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IHttpActionResult> GetById(Guid id)
        {
            try
            {
                var paciente = await _pacienteQueriesService.GetPacienteIdAsync(id);
                var response = new PacienteResponseDto
                {
                    Id = paciente.Id,
                    Nombre = paciente.Nombre,
                    Apellido = paciente.Apellido,
                    TipoDocumento = paciente.TipoDocumento,
                    Documento = paciente.Documento,
                    Correo = paciente.Correo,
                    NumeroContacto = paciente.NumeroContacto,
                    Eps = paciente.Eps
                };

                return Ok(response);
            }
            catch (ExcepcionNoEncontrada ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Add([FromBody] PacienteDto pacienteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paciente = new Paciente
            {
                Id = Guid.NewGuid(),
                Nombre = pacienteDto.Nombre,
                Apellido = pacienteDto.Apellido,
                TipoDocumento = pacienteDto.TipoDocumento,
                Documento = pacienteDto.Documento,
                Correo = pacienteDto.Correo,
                NumeroContacto = pacienteDto.NumeroContacto,
                Eps = pacienteDto.Eps
            };

            await _pacienteCommandService.CrearPaciente(paciente);
            return Created($"api/pacientes/{paciente.Id}", paciente.Id);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IHttpActionResult> Update(Guid id, [FromBody] PacienteDto pacienteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var paciente = new Paciente
                {
                    Id = id,
                    Nombre = pacienteDto.Nombre,
                    Apellido = pacienteDto.Apellido,
                    TipoDocumento = pacienteDto.TipoDocumento,
                    Documento = pacienteDto.Documento,
                    Correo = pacienteDto.Correo,
                    NumeroContacto = pacienteDto.NumeroContacto,
                    Eps = pacienteDto.Eps
                };

                await _pacienteCommandService.ModificarPaciente(paciente);
                return Ok();
            }
            catch (ExcepcionNoEncontrada ex)
            {
                return NotFound();
            }
        }

        // DELETE: api/medicos/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IHttpActionResult> Delete(Guid id)
        {
            try
            {
                var paciente = await _pacienteQueriesService.GetPacienteIdAsync(id);
                await _pacienteCommandService.EliminarPaciente(paciente);
                return Ok();
            }
            catch (ExcepcionNoEncontrada ex)
            {
                return NotFound();
            }
        }
    }
}
