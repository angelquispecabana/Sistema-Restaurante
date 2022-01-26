using App.Restaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Restaurante.Repositories
{
    public interface IVentaCabeceraRepository : IRepository<VentaCabecera>
    {
        Task<IEnumerable<VentaCabecera>> BuscarPorId(int idVenta);
        Task<IEnumerable<VentaCabecera>> Listar(DateTime fechaInicial, DateTime fechaFinal);
        Task<int> Eliminar(int idVenta);
    }
}
