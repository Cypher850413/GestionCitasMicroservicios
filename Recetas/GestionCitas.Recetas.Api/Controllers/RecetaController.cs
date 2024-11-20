using GestionCitas.Recetas.Api.Controllers.Dtos;
using GestionCitas.Recetas.Dominio.Servicios;
using GestionCitas.Recetas.Dominio.Modelos;
using GestionCitas.Recetas.Dominio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Drawing;

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
        [Route("")]
        public async Task<IHttpActionResult> GetAll()
        {
            var recetas = await _recetaQueriesService.GetAllAsyncReceta();
            var response = recetas.Select(m => new RecetaResponseDto
            {
                Id = m.Id,
                Codigo = m.Codigo,
                Descripcion  = m.Descripcion,
                PacienteId = m.PacienteId,
                Estado = m.Estado
            });

            return Ok(response);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IHttpActionResult> GetById(Guid id)
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
        [Route("")]
        public async Task<IHttpActionResult> Add([FromBody] RecetaDto recetaDto)
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
        [Route("{id:guid}")]
        public async Task<IHttpActionResult> Update(Guid id, [FromBody] RecetaDto recetaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var receta = new Receta
                {
                    Id = Guid.NewGuid(),
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

        // DELETE: api/medicos/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IHttpActionResult> Delete(Guid id)
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
