using App.Restaurante.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Restaurante.UnitOfWork
{
    public interface IUnitOfWork
    {
        IPlatoRepository Platos { get; }
        ISubGrupoRepository SubGrupos { get; }
        //IVentaCabeceraRepository VentasCabecera { get; }
        IProveedorRepository Proveedores { get; }
    }
}
