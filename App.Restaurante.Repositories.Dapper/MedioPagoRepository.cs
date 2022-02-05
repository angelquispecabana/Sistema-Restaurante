using App.Restaurante.Models;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace App.Restaurante.Repositories.Dapper
{
    public class MedioPagoRepository : Repository<MedioPago>, IMedioPagoRepository
    {
        public MedioPagoRepository(string connectionString) : base(connectionString)
        {
        }
        public async Task<IEnumerable<MedioPago>> ListarAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<MedioPago>("dbo.usp_MedioPagoListar", null, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
