using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace App.Restaurante.Models
{
    public class Pedido
    {
        [ExplicitKey]
        public int IdPedido { get; set; }
        public int IdTurno { get; set; }
        public string Descripcion { get; set; }
        public int IdEstado { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }

        public virtual Turno Turno { get; set; }
        public ICollection<PedidoDetalle> PedidoDetalle { get; set; }

    }
}
