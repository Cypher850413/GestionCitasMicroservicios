using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCitas.Personas.Dominio.PersonasAgrupadas.Excepciones
{
    public class ExcepcionNoEncontrada : System.Exception
    {
        public ExcepcionNoEncontrada() 
        { 
        }
        public ExcepcionNoEncontrada(string msg) : base(msg) 
        { 
        
        }
    }
}
