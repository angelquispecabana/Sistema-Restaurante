using App.Restaurante.Models;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace App.Restaurante.Repositories.Dapper
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(string connectionString) : base(connectionString)
        {
        }
        public Task<IEnumerable<Pedido>> BuscarPorId(int idPedido)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IdPedido", idPedido);
                return connection.QueryAsync<Pedido>("dbo.usp_PedidoListarId", parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Pedido>> ListarAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Pedido>("dbo.usp_PedidoListar", null, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<int> Crear(Pedido pedido)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IdTurno", pedido.IdTurno);
                parameters.Add("@Descripcion", pedido.Descripcion);
                parameters.Add("@Fecha", pedido.Fecha);
                parameters.Add("@IdUsuario", pedido.IdUsuario);
                return await connection.ExecuteAsync("dbo.usp_PedidoCrea", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<int> Borrar(int idPedido)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@idPedido", idPedido);
                return await connection.ExecuteAsync("dbo.usp_PedidoCierre", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public int UltimoId()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                int Id = connection.QueryFirst<int>("dbo.usp_PedidoUltimoId", null, commandType: System.Data.CommandType.StoredProcedure);
                return Id;
            }
        }
    }
}
