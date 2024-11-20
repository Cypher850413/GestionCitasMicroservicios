using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionCitas.Citas.Api.Controllers.Dtos
{
    public class CitaResponseDto
    {
        public Guid Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }
        public Guid PacienteId { get; set; }
        public Guid MedicoId { get; set; }
        public string Estado { get; set; }
    }
}