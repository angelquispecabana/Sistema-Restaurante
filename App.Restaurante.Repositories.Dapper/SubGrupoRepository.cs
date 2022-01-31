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
                parameters.Add("@IdSubGrupo", idSubGrupo);
                return await connection.QueryAsync<SubGrupo>("usp_BuscarSubGrupo", parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<int> Eliminar(int idSubGrupo)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@idSubGrupo", idSubGrupo);
                return await connection.ExecuteAsync("update dbo.SubGrupo " +
                                                "set Estado = 0 " +
                                                "where IdSubGrupo = @idSubGrupo", parameters,
                                                commandType: System.Data.CommandType.Text);
            }
        }

        public async Task<int> Insertar(SubGrupo subGrupo)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Descripcion", subGrupo.Descripcion);
                parameters.Add("@IdGrupo", subGrupo.IdGrupo);
                parameters.Add("@Estado", subGrupo.Estado);
                return await connection.ExecuteAsync("dbo.usp_InsertarSubGrupo", parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<SubGrupo>> Listar(string descripcion)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Descripcion", descripcion);
                return await connection.QueryAsync<SubGrupo>("usp_ListarSubGrupos", parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
