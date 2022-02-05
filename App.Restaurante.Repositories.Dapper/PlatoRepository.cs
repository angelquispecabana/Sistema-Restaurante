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
        public async Task<IEnumerable<Plato>> BuscarPorId(int idPlato)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IdPlato", idPlato);
                return await connection.QueryAsync<Plato>("dbo.usp_BuscarPlato", parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<Plato>> Listar(string descripcion)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Descripcion", descripcion);
                return await connection.QueryAsync<Plato>("dbo.usp_ListarPlatos", parameters,                                                    
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public async Task<int> Eliminar(int idPlato)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@idPlato", idPlato);
                return await connection.ExecuteAsync("update dbo.Plato " +
                                                    "set Estado = 0 " +
                                                    "where IdPlato = @idPlato", parameters,
                                                    commandType: System.Data.CommandType.Text);
            }
        }

        public async Task<int> Insertar(Plato plato)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Descripcion", plato.Descripcion);
                parameters.Add("@Precio", plato.Precio);
                parameters.Add("@IdSubGrupo", plato.IdSubGrupo);
                parameters.Add("@Estado", plato.Estado);
                return await connection.ExecuteAsync("dbo.usp_InsertarPlato", parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public async Task<Plato> BuscarPorCodigo(int idPlato)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IdPlato", idPlato);
                return await connection.QueryFirstAsync<Plato>("dbo.usp_BuscarPlato", parameters,
                commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
