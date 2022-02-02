using App.Restaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Restaurante.Repositories
{
    public interface IVentaRepository : IRepository<Venta>
    {
        Task<IEnumerable<Venta>> BuscarPorId(int idVenta);
        Task<IEnumerable<Venta>> Listar(DateTime fechaInicial, DateTime fechaFinal);
        Task<int> Eliminar(int idVenta);
    }
}
