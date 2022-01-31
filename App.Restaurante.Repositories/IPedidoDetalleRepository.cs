using App.Restaurante.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Restaurante.Repositories
{
    public interface IPedidoDetalleRepository : IRepository<PedidoDetalle>
    {
        Task<IEnumerable<PedidoDetalle>> BuscarPorId(int idPedido);
        Task<IEnumerable<PedidoDetalle>> ListarAll();
        Task<int> Borrar(int idPedido);
        Task<int> Crear(PedidoDetalle pedidoDetalle);
    }
}
