using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionCitas.Recetas.Api.Models
{
    public class RecetaResponseDto
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public Guid PacienteId { get; set; }
        public string Estado { get; set; }
    }
}