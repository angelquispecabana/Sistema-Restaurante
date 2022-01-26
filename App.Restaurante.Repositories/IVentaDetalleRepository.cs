using App.Restaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Restaurante.Repositories
{
    public interface IVentaDetalleRepository : IRepository<VentaDetalle>
    {
        Task<IEnumerable<VentaCabecera>> Listar(int idVenta);
    }
}
