using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCitas.Citas.Dominio.Modelos
{
    public class Cita
    {
        public Guid Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }
        public Guid PacienteId { get; set; } 
        public Guid MedicoId { get; set; } 
        public string Estado { get; set; } 
    }
}
