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
    public class UsuarioRolRepository : Repository<UsuarioRol>, IUsuarioRolRepository
    {
        public UsuarioRolRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<IEnumerable<UsuarioRol>> ListarRolesporUsuario(string email)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Email", email);
                return await connection.QueryAsync<UsuarioRol>("usp_ListarRolesporUsuario", parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
