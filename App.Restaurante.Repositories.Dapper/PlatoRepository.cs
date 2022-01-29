using App.Restaurante.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Restaurante.Repositories.Dapper
{
    public class PlatoRepository: Repository<Plato>, IPlatoRepository
    {
        public PlatoRepository(string connectionString) : base(connectionString)
        {
        }
        public Task<IEnumerable<Plato>> BuscarPorId(int idPlato)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IdPlato", idPlato);
                return connection.QueryAsync<Plato>("dbo.usp_BuscarPlato", parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public Task<IEnumerable<Plato>> Listar(string descripcion)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Descripcion", descripcion);
                return connection.QueryAsync<Plato, SubGrupo, Plato>("dbo.usp_ListarPlatos", (objPlato, objSubGrupo) => { objPlato.SubGrupo = objSubGrupo; return objPlato; }, parameters,                                                    
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public Task<int> Eliminar(int idPlato)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@idPlato", idPlato);
                return connection.ExecuteAsync("update from dbo.Plato " +
                                                "set Estado = false " +
                                                "where IdPlato = @idPlato", parameters,
                                                commandType: System.Data.CommandType.Text);
            }
        }
    }
}
