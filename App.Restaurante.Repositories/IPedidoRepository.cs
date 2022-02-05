using App.Restaurante.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Restaurante.Repositories
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<IEnumerable<Pedido>> BuscarPorId(int idPedido);
        Task<IEnumerable<Pedido>> ListarAll(string Desde, string Hasta);
        Task<int> Borrar(int idPedido);
        Task<int> Crear(Pedido pedido);
        int UltimoId();
    }
}
