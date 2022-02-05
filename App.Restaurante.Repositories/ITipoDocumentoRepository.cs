using App.Restaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Restaurante.Repositories
{
    public interface ITipoDocumentoRepository: IRepository<TipoDocumento>
    {
        Task<IEnumerable<TipoDocumento>> ListarAll();
    }
}
