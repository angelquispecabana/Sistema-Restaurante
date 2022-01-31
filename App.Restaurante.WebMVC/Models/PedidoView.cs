using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Restaurante.Models;

namespace App.Restaurante.WebMVC.Models
{
    public class PedidoView
    {
        public TurnoPedido Turnos { get; set; }
        public PedidoDetalle Titulos { get; set; }
        public List<PlatoPedido> Platos { get; set; }
    }
}