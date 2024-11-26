using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GestionCitas.Citas.Api.Models;
using GestionCitas.Citas.Dominio.Servicios;
using GestionCitas.Citas.Dominio.Modelos;
using GestionCitas.Citas.Dominio.Excepciones;
using System.Threading.Tasks;

namespace GestionCitas.Citas.Api.Controllers
{
    [RoutePrefix("api/citas")]
    public class CitaController : ApiController
    {
        private readonly ICitaCommandService _citaCommandService;
        private readonly ICitaQueriesService _citaQueriesService;

        public CitaController(ICitaCommandService citaCommandService, ICitaQueriesService citaQueriesService)
        {
            _citaCommandService = citaCommandService;
            _citaQueriesService = citaQueriesService;
        }

        [HttpGet]
        [Route("ObtenerCitas")]
        public async Task<IHttpActionResult> ObtenerCitas()
        {
            var cita = await _citaQueriesService.GetAllAsyncCita();
            var response = cita.Select(m => new CitaResponseDto
            {
                Id = m.Id,
                Fecha = m.Fecha,
                Lugar = m.Lugar,
                PacienteId = m.PacienteId,
                MedicoId = m.MedicoId,
                Estado = m.Estado
            });

            return Ok(response);
        }

        [HttpGet]
        [Route("ObtenerCitasPorId/{id:guid}")]
        public async Task<IHttpActionResult> ObtenerCitasPorId(Guid id)
        {
            try
            {
                var cita = await _citaQueriesService.GetCitaIdAsync(id);
                var response = new CitaResponseDto
                {
                    Id = cita.Id,
                    Fecha = cita.Fecha,
                    Lugar = cita.Lugar,
                    PacienteId = cita.PacienteId,
                    MedicoId = cita.MedicoId,
                    Estado = cita.Estado
                };

                return Ok(response);
            }
            catch (ExcepcionNoEncontrada ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("CrearCita")]
        public async Task<IHttpActionResult> CrearCita([FromBody] CitaDto citaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cita = new Cita
            {
                Id = Guid.NewGuid(),
                Fecha = citaDto.Fecha,
                Lugar = citaDto.Lugar,
                PacienteId = citaDto.PacienteId,
                MedicoId = citaDto.MedicoId,
                Estado = citaDto.Estado
            };

            await _citaCommandService.CrearCita(cita);
            return Created($"api/citas/{cita.Id}", cita.Id);
        }

        [HttpPut]
        [Route("ActualizarCitasPorId/{id:guid}")]
        public async Task<IHttpActionResult> ActualizarCitasPorId(Guid id, [FromBody] CitaDto citaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var cita = new Cita
                {
                    Id = id,
                    Fecha = citaDto.Fecha,
                    Lugar = citaDto.Lugar,
                    PacienteId = citaDto.PacienteId,
                    MedicoId = citaDto.MedicoId,
                    Estado = citaDto.Estado
                };

                await _citaCommandService.ActualizarCita(cita);
                return Ok();
            }
            catch (ExcepcionNoEncontrada ex)
            {
                return NotFound();
            }
        }

        
        [HttpDelete]
        [Route("EliminarCitasPorId/{id:guid}")]
        public async Task<IHttpActionResult> EliminarCitasPorId(Guid id)
        {
            try
            {
                var cita = await _citaQueriesService.GetCitaIdAsync(id);
                await _citaCommandService.EliminarCita(cita);
                return Ok();
            }
            catch (ExcepcionNoEncontrada ex)
            {
                return NotFound();
            }
        }
    }
}
