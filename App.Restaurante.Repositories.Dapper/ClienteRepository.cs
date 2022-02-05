using App.Restaurante.Models;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace App.Restaurante.Repositories.Dapper
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(string connectionString) : base(connectionString)
        {
        }
        public async Task<IEnumerable<Cliente>> ListarAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Cliente>("dbo.usp_ClienteListar", null, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
