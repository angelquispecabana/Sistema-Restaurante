using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace App.Restaurante.Models
{
    public class Cliente
    {
        [ExplicitKey]
        public int IdCliente { get; set; }
        public string Descripcion { get; set; }
    }
}
