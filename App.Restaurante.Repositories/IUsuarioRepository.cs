using App.Restaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Restaurante.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> ValidarUsuario(string email, string password);
        Task<MensajeRetorno> CrearUsuario(Usuario usuario);
        Task<int> Eliminar(int idUsuario);
    }
}
