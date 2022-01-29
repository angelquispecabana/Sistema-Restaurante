﻿using System;
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
        public double Precio { get; set; }
        public SubGrupo SubGrupo { get; set; }
        public bool Estado { get; set; }
    }
}
