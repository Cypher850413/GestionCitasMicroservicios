using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionCitas.Personas.Api.Models
{
    public class MedicoDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public string Correo { get; set; }
        public string NumeroContacto { get; set; }
        public string Especialidad { get; set; }
    }
}