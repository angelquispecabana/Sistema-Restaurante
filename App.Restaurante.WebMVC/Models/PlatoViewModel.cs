using App.Restaurante.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Restaurante.WebMVC.Models
{
    public class PlatoViewModel
    {
        public Plato Plato { get; set; }
        public IEnumerable<SubGrupo> ListaSubGrupo { get; set; }
    }
}