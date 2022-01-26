using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Restaurante.Models
{
    public class Proveedor
    {
        public int IdProveedor { get; set; }
        public string RazonSocial { get; set; }
        public string RazonComercial { get; set; }
        public string RUC { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
