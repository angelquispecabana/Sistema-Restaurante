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
    public class SubGrupoRepository : Repository<SubGrupo>, ISubGrupoRepository
    {
        public SubGrupoRepository(string connectionString) : base(connectionString)
        {
        }
        public async Task<IEnumerable<SubGrupo>> BuscarPorId(int idSubGrupo)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@idSubGrupo", idSubGrupo);
                return await connection.QueryAsync<SubGrupo>("select IdSubGrupo, Descripcion from dbo.SubGrupo " +
                                                    "where IdSubGrupo = @idSubGrupo", parameters,
                                                    commandType: System.Data.CommandType.Text);
            }
        }

        public async Task<int> Eliminar(int idSubGrupo)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@idSubGrupo", idSubGrupo);
                return await connection.ExecuteAsync("update from dbo.SubGrupo " +
                                                "set Estado = false " +
                                                "where IdSubGrupo = @idSubGrupo", parameters,
                                                commandType: System.Data.CommandType.Text);
            }
        }

        public async Task<IEnumerable<SubGrupo>> Listar(string descripcion)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@descripcion", descripcion);
                return await connection.QueryAsync<SubGrupo>("usp_ListarSubGrupos", parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
