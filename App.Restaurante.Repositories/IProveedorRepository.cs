using App.Restaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Restaurante.Repositories
{
    public interface IProveedorRepository : IRepository<Proveedor>
    {
        Task<IEnumerable<Proveedor>> BuscarPorId(int idProveedor);
        Task<IEnumerable<Proveedor>> Listar(string razonSocial);
        Task<int> Eliminar(int idProveedor);
    }
}
