using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCitas.Personas.Dominio.PersonasAgrupadas.Modelos
{
    public abstract class Persona
    {
        public Guid Id { get; set; }
        public string Nombre  {get; set;}
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public string Documento { get; set; }
        public  string Correo {  get; set; }
        public string NumeroContacto { get; set; }
    }
}
