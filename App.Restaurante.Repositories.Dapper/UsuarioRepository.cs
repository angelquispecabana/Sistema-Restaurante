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
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(string connectionString) : base(connectionString)
        {
        }
        public async Task<MensajeRetorno> CrearUsuario(Usuario usuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string message = "";
                var parameters = new DynamicParameters();
                parameters.Add("@Nombres", usuario.Nombres);
                parameters.Add("@Apellidos", usuario.Apellidos);
                parameters.Add("@Email", usuario.Email);
                parameters.Add("@Password", usuario.@Password);
                parameters.Add("@OMensaje", message, System.Data.DbType.String, System.Data.ParameterDirection.Output);

                var usuarioCreado = await connection.QueryFirstOrDefaultAsync<Usuario>("dbo.usp_CrearUsuario",
                    parameters, commandType: System.Data.CommandType.StoredProcedure);

                message = parameters.Get<string>("@OMensaje");

                return new MensajeRetorno { Objeto = usuarioCreado, Mensaje = message };

            }
        }

        public async Task<Usuario> ValidarUsuario(string email, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Email", email);
                parameters.Add("@Password", password);

                var user = await connection.QueryFirstOrDefaultAsync<Usuario>("dbo.usp_ValidarUsuario",
                    parameters, commandType: System.Data.CommandType.StoredProcedure);

                return user;
            }
        }

        public async Task<int> Eliminar(int idUsuario)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@idUsuario", idUsuario);
                return await connection.ExecuteAsync("update dbo.Usuario " +
                                                "set Estado = 0 " +
                                                "where IdUsuario = @idUsuario", parameters,
                                                commandType: System.Data.CommandType.Text);
            }
        }
    }
}
