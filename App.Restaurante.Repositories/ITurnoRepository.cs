using App.Restaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Restaurante.Repositories
{
    public interface ITurnoRepository: IRepository<Turno>
    {
        Task<IEnumerable<Turno>> BuscarPorId(int idTurno);
        Task<IEnumerable<Turno>> ListarAll();
        IEnumerable<Turno> ListarSinTask();
        Task<int> Cierre(int idTurno);
        Task<int> Apertura(Turno turno);
    }
}
