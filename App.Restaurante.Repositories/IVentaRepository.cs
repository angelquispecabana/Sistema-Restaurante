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
        Task<int> Eliminar(int idVenta);
        Task<int> Pagar(Venta venta);
    }
}
