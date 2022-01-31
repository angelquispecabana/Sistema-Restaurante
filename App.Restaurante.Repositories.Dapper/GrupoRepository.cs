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
    public class GrupoRepository : Repository<Grupo>, IGrupoRepository
    {
        public GrupoRepository(string connectionString) : base(connectionString)
        {
        }

        public async Task<IEnumerable<Grupo>> BuscarPorId(int idGrupo)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@idGrupo", idGrupo);
                return await connection.QueryAsync<Grupo>("select IdGrupo, Descripcion from dbo.Grupo " +
                                                    "where IdGrupo = @idGrupo", parameters,
                                                    commandType: System.Data.CommandType.Text);
            }
        }

        public async Task<int> Eliminar(int idGrupo)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@idGrupo", idGrupo);
                return await connection.ExecuteAsync("update from dbo.Grupo " +
                                                "set Estado = 0 " +
                                                "where IdGrupo = @idSubGrupo", parameters,
                                                commandType: System.Data.CommandType.Text);
            }
        }

        public async Task<int> Insertar(Grupo grupo)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Descripcion", grupo.Descripcion);
                return await connection.ExecuteAsync("dbo.usp_InsertarGrupo", parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
