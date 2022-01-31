using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Restaurante.Models;

namespace App.Restaurante.WebMVC.Models
{
    public class PlatoPedido: Plato
    {
        public decimal Cantidad { get; set; }
    }
}