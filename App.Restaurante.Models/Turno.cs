using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace App.Restaurante.Models
{
    public class Turno
    {
        [ExplicitKey]
        public int IdTurno { get; set; }
        public string Descripcion { get; set; }
        public double TipoCambio { get; set; }
        public int IdUsuarioApertura { get; set; }
        public DateTime FechaHoraApertura { get; set; }
        public double ImporteApertura { get; set; }
        public int IdUsuarioCierre { get; set; }
        public DateTime FechaHoraCierre { get; set; }
        public double ImporteCierre { get; set; }
        public Boolean Estado { get; set; }

        public ICollection<Pedido> PedidoCabecera { get; set; }
    }
}
