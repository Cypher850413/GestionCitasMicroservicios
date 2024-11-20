using GestionCitas.Citas.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCitas.Citas.Dominio.Servicios
{
    public interface ICitaCommandService
    {
        Task CrearCita(Cita cita);
        Task ActualizarCita(Cita cita);
        Task EliminarCita(Cita cita);
    }
}
