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
        IProveedorRepository Proveedores { get; }
        ITurnoRepository Turnos { get; }
        IGrupoRepository Grupos { get; }
        IPedidoRepository Pedidos { get; }
        IPedidoDetalleRepository PedidosDetalle { get; }
        IUsuarioRepository Usuarios { get; }
        IUsuarioRolRepository UsuarioRoles { get; }
        IClienteRepository Clientes { get; }
        ITipoDocumentoRepository TiposDocumento { get; }
        IMedioPagoRepository MediosPago { get; }
        IVentaRepository Ventas { get; }
    }
}
