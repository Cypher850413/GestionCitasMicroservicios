using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionCitas.Recetas.Api.Controllers.Dtos
{
    public class RecetaDto
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public Guid PacienteId { get; set; }
        public string Estado { get; set; } // "Activa", "Vencida", "Entregada
    }
}