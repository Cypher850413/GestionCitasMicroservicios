using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCitas.Recetas.Dominio.Modelos
{
    public class Receta
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; } 
        public string Descripcion { get; set; }
        public Guid PacienteId { get; set; } 
        public string Estado { get; set; } // "Activa", "Vencida", "Entregada
    }
}
