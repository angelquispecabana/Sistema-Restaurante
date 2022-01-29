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
    public class TurnoRepository: Repository<Turno>, ITurnoRepository
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

        public Task<int> Apertura(Turno turno)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Descripcion", turno.Descripcion);
                parameters.Add("@TipoCambio", turno.TipoCambio);
                parameters.Add("@IdUsuarioApertura", turno.IdUsuarioApertura);
                parameters.Add("@Estado", turno.Estado);
                return connection.ExecuteAsync("usp_TurnoApertura", parameters, commandType: System.Data.CommandType.StoredProcedure);
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
