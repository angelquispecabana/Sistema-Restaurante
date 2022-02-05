using App.Restaurante.Repositories;
using App.Restaurante.Repositories.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Restaurante.UnitOfWork
{
    public class RestauranteUnitOfWork: IUnitOfWork
    {
        public RestauranteUnitOfWork(string connectionString)
        {
            Platos = new PlatoRepository(connectionString);
            Proveedores = new ProveedorRepository(connectionString);
            SubGrupos = new SubGrupoRepository(connectionString);
            Turnos = new TurnoRepository(connectionString);
            Grupos = new GrupoRepository(connectionString);
            Pedidos = new PedidoRepository(connectionString);
            PedidosDetalle = new PedidoDetalleRepository(connectionString);
            Usuarios = new UsuarioRepository(connectionString);
            UsuarioRoles = new UsuarioRolRepository(connectionString);
            Clientes = new ClienteRepository(connectionString);
            TiposDocumento = new TipoDocumentoRepository(connectionString);
            MediosPago = new MedioPagoRepository(connectionString);
            Ventas = new VentaRepository(connectionString);
        }
        public IPlatoRepository Platos
        {
            get;
            private set;
        }
        public IProveedorRepository Proveedores
        {
            get;
            private set;
        }
        public ISubGrupoRepository SubGrupos
        {
            get;
            private set;
        }
        public ITurnoRepository Turnos
        {
            get;
            private set;
        }
        public IGrupoRepository Grupos
        {
            get;
            private set;
        }
        public IPedidoRepository Pedidos
        {
            get;
            private set;
        }
        public IPedidoDetalleRepository PedidosDetalle
        {
            get;
            private set;
        }
        public IUsuarioRepository Usuarios {
            get;
            private set;
        }

        public IUsuarioRolRepository UsuarioRoles
        {
            get;
            private set;
        }
        public IClienteRepository Clientes
        {
            get;
            private set;
        }
        public ITipoDocumentoRepository TiposDocumento
        {
            get;
            private set;
        }
        public IVentaRepository Ventas
        {
            get;
            private set;
        }
        public IMedioPagoRepository MediosPago
        {
            get;
            private set;
        }
    }
}
