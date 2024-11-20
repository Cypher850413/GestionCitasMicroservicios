using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionCitas.Recetas.Dominio.Excepciones;
using GestionCitas.Recetas.Dominio.Modelos;
using GestionCitas.Recetas.Dominio.Repositorios;

namespace GestionCitas.Recetas.Dominio.Servicios.Impl
{
    public class RecetaCommandService : IRecetaCommandService
    {
        private readonly IRecetaRepository _recetaRepository;
        public RecetaCommandService(IRecetaRepository recetaRepository)
        {
            _recetaRepository = recetaRepository;
        }
        public async Task CrearReceta(Receta receta)
        {
            await _recetaRepository.CrearReceta(receta);
        }

        public async Task ActualizarReceta(Receta receta)
        {
            var BuscarReceta = await _recetaRepository.GetRecetaIdAsync(receta.Id);

            if (BuscarReceta is null)
            {
                throw new ExcepcionNoEncontrada($"La receta con id: {receta.Id} no fue encontrada.");
            }

            await _recetaRepository.ActualizarReceta(receta);
        }

        public async Task EliminarReceta(Receta receta)
        {
            var BuscarReceta = await _recetaRepository.GetRecetaIdAsync(receta.Id);

            if (BuscarReceta is null)
            {
                throw new ExcepcionNoEncontrada($"La receta con id: {receta.Id}  no fue encontrada.");
            }

            await _recetaRepository.EliminarReceta(receta);
        }
    }
}
