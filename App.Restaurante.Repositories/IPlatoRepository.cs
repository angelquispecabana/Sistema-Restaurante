using App.Restaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Restaurante.Repositories
{
    public interface IPlatoRepository: IRepository<Plato>
    {
        Task<IEnumerable<Plato>> BuscarPorId(int idPlato);
        Task<IEnumerable<Plato>> Listar(string descripcion);
        Task<int> Eliminar(int idPlato);
        Task<int> Insertar(Plato plato);
    }
}
