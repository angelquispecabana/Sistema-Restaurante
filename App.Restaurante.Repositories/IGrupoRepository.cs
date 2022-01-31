using App.Restaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Restaurante.Repositories
{
    public interface IGrupoRepository : IRepository<Grupo>
    {
        Task<IEnumerable<Grupo>> BuscarPorId(int idGrupo);
        Task<int> Eliminar(int idGrupo);
        Task<int> Insertar(Grupo grupo);
    }
}
