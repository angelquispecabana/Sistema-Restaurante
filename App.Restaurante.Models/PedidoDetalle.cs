using Dapper.Contrib.Extensions;
using System;

namespace App.Restaurante.Models
{
    public class PedidoDetalle
    {
        [ExplicitKey]
        public int IdPedidoDetalle { get; set; }
        public int IdPedido { get; set; }
        public int IdPlato { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Descuento { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }

        public virtual Pedido Pedido { get; set; }
        public virtual Plato Plato { get; set; }
    }
}
