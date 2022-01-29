using App.Restaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Restaurante.Repositories
{
    public interface ISubGrupoRepository : IRepository<SubGrupo>
    {
        Task<IEnumerable<SubGrupo>> BuscarPorId(int idSubGrupo);
        Task<IEnumerable<SubGrupo>> Listar(string descripcion);
        Task<int> Eliminar(int idSubGrupo);
    }
}
