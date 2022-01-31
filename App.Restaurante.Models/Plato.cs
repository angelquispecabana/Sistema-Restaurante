using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Restaurante.Models
{
    public class Plato
    {
        [ExplicitKey]
        public int IdPlato { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int IdSubGrupo { get; set; }
        [Computed]
        public string Descripcion_SubGrupo { get; set; }
        public bool Estado { get; set; }
        [Computed]
        public IEnumerable<SubGrupo> ListaSubGrupo { get; set; }
        [Computed]
        public string SubGrupo { get; set; }
        [Computed]
        public virtual ICollection<PedidoDetalle> PedidoDetalle { get; set; }
    }
}
