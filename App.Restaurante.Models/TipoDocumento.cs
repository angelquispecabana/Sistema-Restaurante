using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;

namespace App.Restaurante.Models
{
    public class TipoDocumento
    {
        [ExplicitKey]
        public int IdTipoDocumento { get; set; }
        public string Descripcion { get; set; }
    }
}
