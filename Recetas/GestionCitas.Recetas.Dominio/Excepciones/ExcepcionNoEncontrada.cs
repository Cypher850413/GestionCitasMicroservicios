using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCitas.Recetas.Dominio.Excepciones
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
