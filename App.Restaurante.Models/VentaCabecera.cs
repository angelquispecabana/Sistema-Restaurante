using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Restaurante.Models
{
    public class VentaCabecera
    {
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public int IdTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public int IdFormaPago { get; set; }
        public string FormaPago { get; set; }
        public int IdEstado { get; set; }
        public decimal ImporteBruto { get; set; }
        public decimal ImporteIGV { get; set; }
        public decimal ImporteTotal { get; set; }
        public int IdPedido { get; set; }
    }
}
