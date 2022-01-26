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
    public class VentaCabeceraRepository : Repository<VentaCabecera>, IVentaCabeceraRepository
    {
        public VentaCabeceraRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<IEnumerable<VentaCabecera>> BuscarPorId(int idVenta)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IdVenta", idVenta);

                return await connection.QueryAsync<VentaCabecera>("dbo.usp_BuscarVentaCabecera",
                    parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public Task<int> Eliminar(int idVenta)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VentaCabecera>> Listar(DateTime fechaInicial, DateTime fechaFinal)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@FechaInicial", fechaInicial);
                parameters.Add("@FechaFinal", fechaFinal);

                return await connection.QueryAsync<VentaCabecera>("dbo.usp_ListarVentasCabecera",
                    parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
