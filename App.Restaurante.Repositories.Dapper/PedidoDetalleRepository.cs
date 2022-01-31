using App.Restaurante.Models;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace App.Restaurante.Repositories.Dapper
{
    public class PedidoDetalleRepository : Repository<PedidoDetalle>, IPedidoDetalleRepository
    {
        public PedidoDetalleRepository(string connectionString) : base(connectionString)
        {
        }
        public Task<IEnumerable<PedidoDetalle>> BuscarPorId(int idPedido)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IdPedido", idPedido);
                return connection.QueryAsync<PedidoDetalle>("usp_PedidoListarId", parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<PedidoDetalle>> ListarAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<PedidoDetalle>("usp_PedidoListar", null, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<int> Crear(PedidoDetalle pedidoDetalle)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IdPedido", pedidoDetalle.IdPedido);
                parameters.Add("@IdPlato", pedidoDetalle.IdPlato);
                parameters.Add("@Cantidad", pedidoDetalle.Cantidad);
                parameters.Add("@Descuento", pedidoDetalle.Descuento);
                parameters.Add("@Precio", pedidoDetalle.Precio);
                return await connection.ExecuteAsync("dbo.usp_PedidoDetalleCrea", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<int> Borrar(int idPedido)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@idPedido", idPedido);
                return await connection.ExecuteAsync("usp_PedidoCierre", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
