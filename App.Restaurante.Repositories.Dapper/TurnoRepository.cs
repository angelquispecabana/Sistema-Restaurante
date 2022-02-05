using App.Restaurante.Models;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace App.Restaurante.Repositories.Dapper
{
    public class TurnoRepository : Repository<Turno>, ITurnoRepository
    {
        public TurnoRepository(string connectionString) : base(connectionString)
        {
        }
        public Task<IEnumerable<Turno>> BuscarPorId(int idTurno)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IdTurno", idTurno);
                return connection.QueryAsync<Turno>("usp_TurnoListarId", parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<Turno>> ListarAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Turno>("usp_TurnoListar", null, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public async Task<int> Apertura(Turno turno)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Descripcion", turno.Descripcion);
                parameters.Add("@TipoCambio", turno.TipoCambio);
                parameters.Add("@ImporteApertura", turno.ImporteApertura);
                parameters.Add("@IdUsuarioApertura", turno.IdUsuarioApertura);
                return await connection.ExecuteAsync("usp_TurnoApertura", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public async Task<int> Editar(Turno turno)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IdTurno", turno.IdTurno);
                parameters.Add("@Descripcion", turno.Descripcion);
                parameters.Add("@TipoCambio", turno.TipoCambio);
                parameters.Add("@ImporteApertura", turno.ImporteApertura);
                parameters.Add("@IdUsuarioCierre", turno.IdUsuarioCierre);
                return await connection.ExecuteAsync("usp_TurnoEditar", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
        public async Task<int> Cierre(int idTurno)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@IdTurno", idTurno);
                return await connection.ExecuteAsync("usp_TurnoCierre", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
