using App.Restaurante.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Restaurante.Repositories.Dapper
{
    public class VentaRepository : Repository<Venta>, IVentaRepository
    {
        public VentaRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<int> Pagar(Venta venta)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IdPedido", venta.IdPedido);
                parameters.Add("@IdCliente", venta.IdCliente);
                parameters.Add("@IdMedioPago", venta.IdMedioPago);
                parameters.Add("@IdTipoDocumento", venta.IdTipoDocumento);
                parameters.Add("@NumeroDocumento", venta.NumeroDocumento);
                return await connection.ExecuteAsync("dbo.usp_VentaPagar", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Venta>> BuscarPorId(int idVenta)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IdVenta", idVenta);

                return await connection.QueryAsync<Venta>("dbo.usp_BuscarVentaCabecera",
                    parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public Task<int> Eliminar(int idVenta)
        {
            throw new NotImplementedException();
        }

    }
}
