using App.Restaurante.Models;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace App.Restaurante.Repositories.Dapper
{
    public class TipoDocumentoRepository : Repository<TipoDocumento>, ITipoDocumentoRepository
    {
        public TipoDocumentoRepository(string connectionString) : base(connectionString)
        {
        }
        public async Task<IEnumerable<TipoDocumento>> ListarAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<TipoDocumento>("dbo.usp_TipoDocumentoListar", null, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
