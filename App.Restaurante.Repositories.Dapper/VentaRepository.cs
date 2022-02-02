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

        public async Task<IEnumerable<Venta>> Listar(DateTime fechaInicial, DateTime fechaFinal)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FechaInicial", fechaInicial);
                parameters.Add("@FechaFinal", fechaFinal);

                return await connection.QueryAsync<Venta>("dbo.usp_ListarVentasCabecera",
                    parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
