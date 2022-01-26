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
    public class ProveedorRepository : Repository<Proveedor>, IProveedorRepository
    {
        public ProveedorRepository(string connectionString) : base(connectionString)
        {
        }
        public async Task<IEnumerable<Proveedor>> BuscarPorId(int idProveedor)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@idProveedor", idProveedor);
                return await connection.QueryAsync<Proveedor>("select IdProveedor, RazonSocial, RazonComercial, RUC from dbo.Proveedor " +
                                                    "where IdProveedor = @idProveedor", parameters,
                                                    commandType: System.Data.CommandType.Text);
            }
        }

        public async Task<int> Eliminar(int idProveedor)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@idProveedor", idProveedor);
                return await connection.ExecuteAsync("update from dbo.Proveedor " +
                                                "set Estado = false " +
                                                "where IdProveedor = @idProveedor", parameters,
                                                commandType: System.Data.CommandType.Text);
            }
        }

        public async Task<IEnumerable<Proveedor>> Listar(string razonSocial)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@razonSocial", razonSocial);
                return await connection.QueryAsync<Proveedor>("select IdProveedor, RazonSocial, RazonComercial, RUC from dbo.Proveedor " +
                                                    "where RazonSocial like '%@razonSocial%'", parameters,
                                                    commandType: System.Data.CommandType.Text);
            }
        }
    }
}
