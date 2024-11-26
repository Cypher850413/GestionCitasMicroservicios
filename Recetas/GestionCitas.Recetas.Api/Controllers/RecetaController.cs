using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GestionCitas.Recetas.Api.Models;
using GestionCitas.Recetas.Dominio.Servicios;
using GestionCitas.Recetas.Dominio.Modelos;
using GestionCitas.Recetas.Dominio.Excepciones;
using System.Threading.Tasks;

namespace GestionCitas.Recetas.Api.Controllers
{
    [RoutePrefix("api/recetas")]
    public class RecetaController : ApiController
    {
        private readonly IRecetaCommandService _recetaCommandService;
        private readonly IRecetaQueriesService _recetaQueriesService;

        public RecetaController(IRecetaCommandService recetaCommandService, IRecetaQueriesService recetaQueriesService)
        {
            _recetaCommandService = recetaCommandService;
            _recetaQueriesService = recetaQueriesService;
        }

        [HttpGet]
        [Route("ObtenerRecetas")]
        public async Task<IHttpActionResult> ObtenerRecetas()
        {
            var receta = await _recetaQueriesService.GetAllAsyncReceta();
            var response = receta.Select(m => new RecetaResponseDto
            {
                Id = m.Id,
                Codigo = m.Codigo,
                Descripcion = m.Descripcion,
                PacienteId = m.PacienteId,
                Estado = m.Estado
            });

            return Ok(response);
        }

        [HttpGet]
        [Route("ObtenerRecetasPorId/{id:guid}")]
        public async Task<IHttpActionResult> ObtenerRecetasPorId(Guid id)
        {
            try
            {
                var receta = await _recetaQueriesService.GetRecetaIdAsync(id);
                var response = new RecetaResponseDto
                {
                    Id = receta.Id,
                    Codigo = receta.Codigo,
                    Descripcion = receta.Descripcion,
                    PacienteId = receta.PacienteId,
                    Estado = receta.Estado
                };

                return Ok(response);
            }
            catch (ExcepcionNoEncontrada ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("CrearReceta")]
        public async Task<IHttpActionResult> CrearRecta([FromBody] RecetaDto recetaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var receta = new Receta
            {
                Id = Guid.NewGuid(),
                Codigo = recetaDto.Codigo,
                Descripcion = recetaDto.Descripcion,
                PacienteId = recetaDto.PacienteId,
                Estado = recetaDto.Estado
            };

            await _recetaCommandService.CrearReceta(receta);
            return Created($"api/recetas/{receta.Id}", receta.Id);
        }

        [HttpPut]
        [Route("ActualizarRecetasPorId/{id:guid}")]
        public async Task<IHttpActionResult> ActualizarRecetasPorId(Guid id, [FromBody] RecetaDto recetaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var receta = new Receta
                {
                    Id = id,
                    Codigo = recetaDto.Codigo,
                    Descripcion = recetaDto.Descripcion,
                    PacienteId = recetaDto.PacienteId,
                    Estado = recetaDto.Estado
                };

                await _recetaCommandService.ActualizarReceta(receta);
                return Ok();
            }
            catch (ExcepcionNoEncontrada ex)
            {
                return NotFound();
            }
        }


        [HttpDelete]
        [Route("EliminarRecetasPorId/{id:guid}")]
        public async Task<IHttpActionResult> EliminarRecetasPorId(Guid id)
        {
            try
            {
                var receta = await _recetaQueriesService.GetRecetaIdAsync(id);
                await _recetaCommandService.EliminarReceta(receta);
                return Ok();
            }
            catch (ExcepcionNoEncontrada ex)
            {
                return NotFound();
            }

        }
    }
}
