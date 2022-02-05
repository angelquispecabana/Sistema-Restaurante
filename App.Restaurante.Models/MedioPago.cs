using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace App.Restaurante.Models
{
    public class MedioPago
    {
        [ExplicitKey]
        public int IdMedioPago { get; set; }
        public string Descripcion { get; set; }
    }
}
