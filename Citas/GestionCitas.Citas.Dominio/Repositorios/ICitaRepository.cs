using GestionCitas.Citas.Dominio.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionCitas.Citas.Dominio.Repositorios
{
    public interface ICitaRepository
    {
        Task<IEnumerable<Cita>> GetAllAsyncCita();
        Task<Cita> GetCitaIdAsync(Guid id);
        Task CrearCita(Cita cita);
        Task ActualizarCita(Cita cita);
        Task EliminarCita(Cita cita);
    }
}
